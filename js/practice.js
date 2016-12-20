$(document).ready(function(e){
    var pageSize = 6;
    var submitParam = '{pageSize:"'+pageSize+'"}';
    var div_pgArea = $("#LastContent1");
    $.ajax({         
        type: "post",            
        url: "practiceTeaching.aspx/getPractices",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data:submitParam,     
        success: function(data) {    
            var json = eval("("+data.d+")"); //将json字符串转换成json对象
            
            var pgObj = new pageTool(json,pageSize,5);
            pgObj.init(div_pgArea,getOnePagePrc,initPerPgAction);
        },
        error: function(err) {     
            alert("error");     
        }     
    });
});

//获取一页实验教学内容
function getOnePagePrc(Data){
    i=0;
    var htmlStr = '<ul id="big_ulist">';
    var tmp_num = 0;                
    for(i = 0;i<Data.length;i++){
        var id = Data[i].Id;
        var title = Data[i].Title;
        var description = Data[i].Description;
        var type = Data[i].Type;
        var img_url = Data[i].Img_url;
        var link_url = Data[i].Link_url;
        var uploadTime = Data[i].UploadTime;
        htmlStr += "<li>"
                        +"<div class='li-up'><a href='resource/practice/"+link_url+"' target='_blank'><img src='resource/practice/"+img_url+"'><div class='uinfo'><strong>"+title+"</strong><br><span class='gray'>上传时间</span>"+uploadTime+"</div></a></div>"
                        +"<div class='li-down'>"+description+"</div>"+
                    "</li>";
    }
    htmlStr += "</ul>";
    return htmlStr;
}
//初始化每页的交互效果及操作
function initPerPgAction(pgTool){/*换成css控制
    var pgAreaObj = pgTool.pagingAreaDomObj;
    pgAreaObj.find("#big_ulist li").mouseover(function(){
        $(this).css("background","#6CD9AA");
        $(this).css("color","#fff");
    });
    pgAreaObj.find("#big_ulist li").mouseout(function(){
        $(this).css("background","#fff");
        $(this).css("color","#09935F");
    });*/
}
