
$(document).ready(function(e){
    $.ajax({              
            type: "post",            
            url: "evaluation.aspx/getTests",
            contentType: "application/json; charset=utf-8",
            dataType: "json",     
            success: function(data) {    
                var json = eval("("+data.d+")"); //将json字符串转换成json对象
                catalogue(json);
            },
            error: function(err) {     
                alert("error");     
            }     
    });
    function catalogue(json){   
        i=0;
        var rsString ='';//<div class="top_img"></div>
        rsString += "<ul class='nav sidenav nav-tabs nav-stacked'>";
        var tmp_num = 0;                
        for(i = 0;i<json.length;i++){
            var id = json[i].Id;
            var sectionId = json[i].SectionId;
            var sectionTitle = json[i].SectionTitle;
            rsString += "<li class=''><a id='#"+id+"'href='javascript:void(0);'>第<span id=\"sectionId\">"+sectionId+"</span>章 <span id=\"sectionTitle\">"+sectionTitle+"</span></a></li>";
        }
        $("#toc").html(rsString);
        $(".top_img").css("background","url(img/top_xxpj.jpg) no-repeat");
        $(".top_img").css("background-size","100% 100%");
    
        //目录交互效果
        $("ul.sidenav li").click(function(){
            $("#toc li").each(function(){
                $(this).removeClass("active");
            });
            $(this).addClass("active");
        });
        
        //生成试卷
        $(".sidenav li").click(function(){
            var secId=$(this).find("span#sectionId").html();
            var secTitle=$(this).find("span#sectionTitle").html();
            $.ajax({
                type:"post",
                url:"evaluation.aspx/getOneTest",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{"sectionId":"'+secId+'"}',
                success: function(data) {    
                    var json = eval("("+data.d+")"); //将json字符串转换成json对象
                    content_frame_init(secId,secTitle);
                    xuanze(json[0]);
                    tiankong(json[1]);
                    var tail = "<div id=\"answer\" class=\"btn btn-success\">提交试卷</div>";
                    $("#content_frame").append(tail);
                    answer(json);
                },
                error: function(err) {     
                    $("#content_frame").html("<h4>获取数据错误！</h4>");   
                }     
            });
        });
        
        $(".sidenav li").first().click();
    }
    
    
    function content_frame_init(secId,secTitle){
        var initStr = "<li><a href=\"home.aspx\">首页</a> </li>"+
                      "<li><a href=\"evaluation.aspx\">学习评价</a> </li>"+
                      "<li class=\"active\">第"+secId+"章 "+secTitle+"</li>";
        $(".breadcrumb").html(initStr);
        initStr = "<div class=\"dividing\">"+
                    "<h2>"+
                        "<label class=\"skew\">"+
                        "<i>第"+secId+"章 "+secTitle+"</i></label></h2>"+
                  "</div>"+
                  "<div id=\"content\"></div>";
        $("#content_frame").html(initStr);
    }
    //选择题
    function xuanze(rs){
        var mcquestionStr = "<blockquote class=\"question_title\">选择题</blockquote>";
        for(var i =0 ;i<rs.length;i++){
            mcquestionStr +="<table>"+
                            "<tbody>"+
                                "<tr>"+
                                    "<th>"+
                                        (i+1)+"."+rs[i].Content+
                                    "</th>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td>"+
                                        "<input name=\"name_"+(i+1)+"\" type=\"radio\" /><label>"+rs[i].OptA+"</label>"+
                                    "</td>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td class=\"oushu\">"+
                                        "<input name=\"name_"+(i+1)+"\" type=\"radio\" /><label>"+rs[i].OptB+"</label>"+
                                    "</td>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td>"+
                                        "<input name=\"name_"+(i+1)+"\" type=\"radio\" /><label>"+rs[i].OptC+"</label>"+
                                    "</td>"+
                                "</tr>"+
                                "<tr>"+
                                    "<td class=\"oushu\">"+
                                        "<input name=\"name_"+(i+1)+"\" type=\"radio\" /><label>"+rs[i].OptD+"</label>"+
                                    "</td>"+
                                "</tr>"+
                            "</tbody>"+
                        "</table>";
        }
        mcquestionStr+="<br/><br/>";
        $("#content").append(mcquestionStr);
    }
    //填空题
    function tiankong(rs){
        var fiquestion = "<blockquote class=\"question_title\">填空题</blockquote>";
        for(var i =0 ;i<rs.length;i++){
             fiquestion += 
                        "<ul class=\"ul_tiankong\">"+
                            "<li class=\"li_tiankong_question\">"+(i+1)+"."+rs[i].Content+"</li>"+
                            "<li class=\"li_tiankong_answer\">回答：<input name=\"tiankong_"+(i+1)+"\" type=\"text\" /></li>"+
                        "</ul>";
        }
        fiquestion += "<br/>";
        $("#content_frame").append(fiquestion);
    }
    //提交试卷批改
    function answer(json){
        $("#answer").click(function(){
            var answerStr = "";
            answerStr +="***选择题***\n";

            for(var i = 0; i<json[0].length;i++){
                var right_answer = "";
                switch(json[0][i].Answer){
                    case "A":right_answer=json[0][i].OptA;break;
                    case "B":right_answer=json[0][i].OptB;break;
                    case "C":right_answer=json[0][i].OptC;break;
                    case "D":right_answer=json[0][i].OptD;break;
                    default:break;
                }
                answerStr += "第"+(i+1)+"题：";
                if($("input[name=\"name_"+(i+1)+"\"]:checked").val()==undefined)
                    answerStr += "未填写答案\n";
                else if($("input[name=\"name_"+(i+1)+"\"]:checked").next().html()==right_answer)
                    answerStr += "对\n";
                else
                    answerStr += "错。答案："+json[0][i].Answer+"."+right_answer+"\n";
            }
            
            answerStr += "***填空题***\n"
            for(var i = 0; i<json[1].length;i++){
                var right_answer = json[1][i].Answer;
                answerStr += "第"+(i+1)+"题：";
                if($("input[name=\"tiankong_"+(i+1)+"\"]").val().trim() == "")
                    answerStr += "未填写答案\n";
                else if($("input[name=\"tiankong_"+(i+1)+"\"]").val().trim()==right_answer)
                    answerStr += "对\n";
                else
                    answerStr += "错。答案："+right_answer+"\n";
            }
            
            alert(answerStr);
        });
    }
});
