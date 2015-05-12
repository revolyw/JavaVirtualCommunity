
$(document).ready(function(e){
$.ajax({              
            type: "post",            
            url: "knowledge.aspx/getKnowledgeTree",
            contentType: "application/json; charset=utf-8",
            dataType: "json",     
            success: function(data) {    //待改进，一次数据量太大
                var json = eval("("+data.d+")"); //将json字符串转换成json对象
                catalogue(json);
            },
            error: function(err) {     
                alert("error");     
            }     
});
function catalogue(json){
//      var rsArray = new Array();
//    var supArray = new Array();
//    var subArray = new Array();

//    
//    var i = 0;
//    var j = 0;
//    //分离各级目录项
//    while(i<length){
//        if(json[i].Level == 1)
//            supArray.push(json[i]);
//        if(json[i].Level == 2)
//            subArray.push(json[i]);
//        i++;
//    }
//    var supLength = supArray.length;
//    var subLength = subArray.length;
//    
//    //排序(冒泡)
//    i = 0;
//    var tmp = null;
//    while(supLength > 1){
//        var exchange = false;
//        for(j = 0;j<supLength - 1;j++){
//            if(supArray[j].Number > supArray[j+1].Number){
//                exchange = true;
//                tmp = supArray[j];
//                supArray[j] = supArray[j+1];
//                supArray[j+1] = tmp;
//            }
//        }
//        if(!exchange)
//            break;
//        supLength--;
//    }
//    i = 0;
//    while(subLength > 1){
//        var exchange = false;
//        for(j = 0;j<subLength - 1;j++){
//            if(subArray[j].Number > subArray[j+1].Number){
//                exchange = true;
//                tmp = subArray[j];
//                subArray[j] = subArray[j+1];
//                subArray[j+1] = tmp;
//            }
//        }
//        if(!exchange)
//            break;
//        subLength--;
//    }
////  重新排序组织目录
//    i=0;
//    var sub_index = 0;
//    while(i<supArray.length){
//        rsArray.push(supArray[i]);
//        j=0;
//        while(j<supArray[i].Sub_num){
//            rsArray.push(subArray[sub_index]);
//            sub_index++;
//            j++;
//        }
//        i++;
//    }
    
    i=0;
    var rsString = "<ul class='nav sidenav sidenav nav-tabs nav-stacked'>";
    var tmp_num = 0;                
    for(i = 0;i<json.length;i++){
        var id = json[i].Id;
        var level = json[i].Level;
        var sup = json[i].Super_level;
        var sub_num = json[i].Sub_num;
        var number = json[i].Number;
        var description = json[i].Description;
        var content = json[i].Content;
        
        if(level == 1 && sub_num == 0){
            rsString += "<li class=''><a id='#"+id+"'href='javascript:void(0);'>"+description+"</a></li>";
        }else if(level == 1 && sub_num != 0){
            tmp_num = sub_num;
            rsString += "<li class=''><a id='#"+id+"'href='javascript:void(0);'>"+description+"</a><ul class='nav father'>";
        }else if(level == 2){
            rsString += "<li class='toLink'><a id='"+id+"' href='javascript:void(0);' target='_blank'>"+description+"</a><div class='hidenData' style='display:none'>"+content+"</div></li>";
            tmp_num--;
            if(tmp_num == 0){
                rsString +="</ul>";
            }
        }
    }
    rsString += "</ul>";
    $("#toc").html(rsString);
    
    //左侧目录交互效果
    $("#toc li").click(function(e){
      $("#toc li").removeClass("active");
      $(".father").each(function(){
        $(this).css("display","none");
      });
      $(this).children("ul.nav").css("display","block");
      $(this).addClass("active");
      return true;
    });
    
    $("li.toLink").click(function(){
        var string=$(this).children("div.hidenData").html();
        $.ajax({              
            type: "post",            
            url: "knowledge.aspx/getKnowledgeContent",
            contentType: "application/json; charset=utf-8",
            data:'{"contentId":"'+string+'"}',
            dataType: "json",     
            success: function(data) {    //待改进，一次数据量太大
                var json = eval("("+data.d+")"); //将json字符串转换成json对象
                $("#content_frame").html(json[0].Content);
            },
            error: function(err) {     
                alert("error");     
            }     
        });
    });
    $("li.toLink").first().click();//初始数据
}
});