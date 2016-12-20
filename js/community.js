$(document).ready(function(){
    //导航交互
    $("#top ul li").click(function(){
        $("#top ul li").each(function(){
            $(this).removeClass("active");
        });
        $(this).addClass("active");
    });
    
    //看帖模块
    $("#nav_kantie").click(function(){
        var pageSize = 5;
        var submitParam = '{pageSize:"'+pageSize+'"}';
        $.ajax({
            type:"post",
            cache:false,
            url:"community.aspx/getThemes",
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            data:submitParam,
            success:function(data){
                var json = eval(data.d);
                if(json==""||null==json||undefined==json){
                    $("#bottom").html("暂时没有帖子，您可以尝试第一个发帖！");
                    return;
                }
                //构造分页对象
                var msgPageTool = new pageTool(json,pageSize,5);
                //初始化
                msgPageTool.init($("#bottom"),getOnePageTiezi,openOneTiezi);
            },
            error:function(error){
                alert("error");
            }
        });
    });
    
    //发帖模块
    $("#nav_fatie").click(function(){
        var htmlStr  = "<div class=\"div_fatie\">";
        htmlStr     +=  "<h1>发帖</h1>";
        htmlStr     +=  "<input id=\"fatie_title\" type=\"text\" placeholder=\"标题\" />";
        htmlStr     +=  "<textarea id=\"fatie_content\" rows=\"10\" placeholder=\"帖子内容\" ></textarea>";
        htmlStr     +=  "<div id=\"btn_fatie\" class=\"btn btn-primary\">发帖</div>";
        htmlStr     += "</div>";
        $("#bottom").html(htmlStr);
        $("#btn_fatie").click(function(){
            var title = $("#fatie_title").val();
            var content = $("#fatie_content").val();
            $.ajax({
                type:"post",
                url:"community.aspx/fatie",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data:"{title:\""+title+"\",content:\""+content+"\"}",
                success: function(data) {    
                    var json = eval("("+data.d+")"); //将json字符串转换成json对象
                    if(json == "1"){
                        $("#nav_kantie").click();
                    }else if(json == "-1"){
                        alert("请先登陆");
                    }else{
                        alert("发送失败");
                    }
                },
                error: function(err) {     
                   alert("error"); 
                }     
            });
        });
    });
    //个人动态模块
    $("#nav_dongtai").click(function(){
    });
    
    //默认显示看帖模块
    $("#nav_kantie").click();
    
    //启用具体帖子中的三个功能按钮
    btnClick();
    
});

//看具体贴块的交互效果
function opacityToggleClass(){
    $(".opacity").toggleClass("reversal"); 
    $(".view_tiezi").toggleClass("displayNone");
//    $(".scrollToTop").toggleClass("displayNone");
    $(".view_tiezi_liuyan").toggleClass("displayNone");
    $(".view_tiezi_back").toggleClass("displayNone");
}

//获得一页帖子
function getOnePageTiezi(Data){
    var htmlStr = "<ul>";
    for(var i = 0;i < Data.length; i++){
             htmlStr += "<li>"+
                            "<div class=\"tie_left\">"+
                                "<div class=\"hot\">"+
                                    "<span class=\"hot_txt\">"+Data[i].Hot_index+"</span>"+
                                "</div>"+
                            "</div>"+
                            "<div class=\"tie_center\">"+
                                "<div class=\"tie_center_top\">"+
                                    "<span id=\"title_txt\"><a class=\"linkTo_title\" linkId=\""+Data[i].Id+"\">"+Data[i].Title+"</a></span>"+
                                "</div>"+
                                "<div class=\"tie_center_bottom\">"+
                                    "<span id=\"tie_main\">"+Data[i].Content+"</span>"+
                                "</div>"+
                            "</div>"+
                            "<div class=\"tie_right\">"+
                                "<div class=\"tie_right_top\">"+
                                    "<span id=\"user_txt\">"+Data[i].Uname+"</span>"+
                                "</div>"+
                                "<div class=\"tie_right_bottom\">"+
                                    "<span id=\"time_txt\">"+Data[i].Time+"</span>"+
                                "</div>"+
                            "</div>"+
                        "</li>";
    }
    htmlStr += "</ul>";
    return htmlStr;
}
//打开具体帖子
function openOneTiezi(pagingTool){
        var pagingAreaDomObj = pagingTool.pagingAreaDomObj;
        pagingAreaDomObj.find(".linkTo_title").click(function(){
            opacityToggleClass();
            currentTieziId = $(this).attr("linkId");
            LinkToDiezi(currentTieziId);
        });
}

//////全局数据
var currentTieziId;//当前帖子
//获得具体帖子的信息
function LinkToDiezi(currentTieziId){
    var pageSize = 4;
//    $(".scrollToTop").click();    
    $.ajax({
        type:"post",
        url:"community.aspx/getOneTheme",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data:"{themeId:\""+currentTieziId+"\",pageSize:\""+pageSize+"\"}",
        success: function(data) {    
            var json = eval("("+data.d+")"); //json[0] 一个帖子对象 json[1]留言分页数据
            
            var htmlStr = "";
            htmlStr += "<ul>";
            htmlStr += "<li class=\"view_tiezi_head\"><span class=\"view_tiezi_head_title\" theme_id=\""+json[0].Id+"\">"+json[0].Title+"</span><div class=\"close\"></div></li>";
            htmlStr += "<li><div class=\"view_tiezi_content\">"+json[0].Content+"</div><a><img src=\"img/big_touxiang.jpg\"/><span class=\"view_tiezi_uname\">"+json[0].Uname+"</span></a><div class=\"view_tiezi_contentBottom\"><span class=\"view_tiezi_loushu\">1楼</span><span class=\"view_tiezi_time\">"+json[0].Time+"</span></li>";
            htmlStr += "</ul>";
            htmlStr += "<div class=\"view_tiezi_comments\"></div>"
            htmlStr += "<textarea class=\"viwe_tiezi_commentarea\" placeholder=\"评论\"></textarea><div class=\"btn btn-info btn_comment_submit\" style=\"width:100%\">提交</div>";
            $(".view_tiezi").html(htmlStr);
            
            //构造分页对象
            var pgt = new pageTool(json[1],pageSize,5);
            pgt.init($(".view_tiezi_comments"),getOnePageComments,onePageCommentsInit);
                        
            //评论提交
            commentSubmit();
            //关闭帖子视图按钮
            $(".close").click(function(){
                opacityToggleClass();
            });
            
            
        },
        error: function(err) {     
           $(".view_tiezi").html("get data error！！"); 
        }     
    });
}

//评论提交
function commentSubmit(){
    $(".btn_comment_submit").click(function(){
        var submitString= $(this).prev(".viwe_tiezi_commentarea").val();
        var theme_id = $(".view_tiezi_head_title").attr("theme_id");
        var parameter = "{theme_id:\""+theme_id+"\",submitString:\""+submitString+"\"}";
        $.ajax({
            type:"post",
            url:"community.aspx/commentSubmit",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data:parameter,
            success: function(data) {    
                var json = eval("("+data.d+")"); 
                if(json == "1"){//留言成功
                    LinkToDiezi(currentTieziId);//刷新留言列表
                    //刷新帖子热度信息（界面）
                    $("#bottom li").each(function(){
                        if($(this).children().find(".linkTo_title").attr("linkid") == theme_id){
                            var hotObject = $(this).children().find(".hot_txt");
                            var hotString = hotObject.html();
                            hotString = (parseInt(hotString)+1)+"";
                            hotObject.html(hotString);
                        }
                    });
                }else if(json == "-1"){
                    alert("请先登陆");
                }else{
                    alert("评论失败");
                }
            },
            error: function(err) {     
                alert("get data error！！"); 
            }
        });
    });
}

//获得一页评论html字符串
function getOnePageComments(Data){
    var htmlStr = "<ul>";
    var j = 0;
    for(var i = 0 ;i<Data.length;i++,j++){
        htmlStr += "<li comid=\""+Data[i][1].Id+"\">";
        htmlStr +=  "<div class=\"view_tiezi_content\">"+Data[i][1].Content+"</div>";
        htmlStr +=  "<a><img src=\"img/big_touxiang.jpg\"/><span class=\"view_tiezi_uname\">"+Data[i][0]+"</span></a>";
        htmlStr +=  "<div class=\"view_tiezi_contentBottom\">";
        htmlStr +=      "<span class=\"view_tiezi_loushu\">"+(j+2)+"楼</span><span class=\"view_tiezi_time\">"+Data[i][1].Time+"</span><a class=\"view_tiezi_reply\">回复<span>("+Data[i][1].Reply_num+")</span></a>";
        htmlStr +=      "<div style=\"display:none\" class=\"replys\">";
        htmlStr +=      "</div>";
        htmlStr +=  "</div>";
        htmlStr +=  "<div class=\"div_reply\" style=\"display:none\"><textarea style=\"width:100%;height:80px;\" to=\""+Data[i][1].U_id+"\" placeholder=\"回复 "+Data[i][0]+"\"></textarea><div class=\"btn btn-info btn_reply\" style=\"width:100%\">回复</div></div>";
        htmlStr += "</li>";
    }
    htmlStr += "</ul>";
    return htmlStr;
}

//每页评论的初始化工作
function onePageCommentsInit(pagingTool){
    var pagingAreaDomObj = pagingTool.pagingAreaDomObj;
    //加载每条评论的回复
    pagingAreaDomObj.find(".replys").each(function(){
        var commentId = $(this).closest("li").attr("comid");
        loadReplys(commentId,$(this));
    });
    //回复块交互效果
    replyInterAction(pagingAreaDomObj);
}

//加载一条评论所有回复
function loadReplys(commentId,div_replysArea){
    var pageSize = 3;
    var submitParam = '{commentId:"'+commentId+'",pageSize:"'+pageSize+'"}';
    $.ajax({
        type:"post",
        async:false,
        url:"community.aspx/getReplys",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data:submitParam,
        success: function(data) {    
            var json = eval("("+data.d+")");
            var pgt = new pageTool(json,pageSize,5);
            pgt.init(div_replysArea,getOnePageReplys,listeningReply);
        },
        error: function(err) {     
            alert("get data error！！"); 
        }
    });
}
//获取一页回复的html字符串
function getOnePageReplys(Data){
    var htmlStr = "";
    htmlStr +="<ul>";
    for(var i = 0 ;i < Data.length;i++){
        htmlStr += "<li><a><img src=\"img/small_touxiang.jpg\"/><span>"+Data[i].From_name+"</span></a><code>回复 "+Data[i].To_name+"：</code><span>"+Data[i].Content+"</span><span class=\"reply_tail_time\">"+Data[i].Time+"</span><span class=\"reply_tail_btn\" to=\""+Data[i].From_uid+"\">回复</span></li>";
    }
    htmlStr +="</ul>";
    return htmlStr;
}
//对回复当前页中的每个回复按钮监听
function listeningReply(pageTool){
    var pagingAreaDomObj = pageTool.pagingAreaDomObj;
    var commentId = pagingAreaDomObj.closest("li").attr("comid");
    //此处pagingAreaDomObj为每个回复区域的容器即replys
    pagingAreaDomObj.find(".reply_tail_btn").click(function(){
        var to_uid = $(this).attr("to");
        var to_uname = $(this).siblings("a").children("span").html();
        $(this).closest(".view_tiezi_contentBottom").next(".div_reply").find("textarea").attr("to",to_uid);
        $(this).closest(".view_tiezi_contentBottom").next(".div_reply").find("textarea").attr("placeholder","回复 "+to_uname);//修改回复框中的提示信息
    });
    
}
//回复块交互
function replyInterAction(pagingAreaDomObj){
    pagingAreaDomObj.find(".view_tiezi_reply").click(function(event){
        event.stopPropagation();
        $(this).next().slideToggle();
        $(this).parent().next().slideToggle();
        $(this).toggleClass("view_tiezi_replyClicked");
    });
    //回复操作
    pagingAreaDomObj.find(".btn_reply").click(function(){
        var toId = $(this).prev().attr("to");
        var commentId = $(this).closest("li").attr("comid");
        var textArea = $(this).prev();
        var content = textArea.val();
        var div_replysArea = $(this).parent().prev().find(".replys");
        var submitParam = '{toId:"'+toId+'",commentId:"'+commentId+'",content:"'+content+'"}';
        $.ajax({
            type:"post",
            url:"community.aspx/reply",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data:submitParam,
            success: function(data) {    
                var json = eval("("+data.d+")"); 
                if(json == "1"){//回复成功
                    loadReplys(commentId,div_replysArea);//刷新回复列表
                }else if(json=="-1"){
                    alert("请先登陆");
                }
                else{
                    alert("回复失败!");
                }
                textArea.val("");//清空输入框
            },
            error: function(err) {     
                alert("get data error！！"); 
            }
        });
    });
}


//固定在右下角的三个按钮
function btnClick(){
    //去底部留言
    $(".view_tiezi_liuyan").click(function(){
        $(".view_tiezi").animate({
            scrollTop:"+="+$(".view_tiezi").height(),
        },500);
        window.scrollTo(0,($("body").height() - $(".viwe_tiezi_commentarea").height()));
    });
    //回顶部
    $(".scrollToTop").click(function(){
        $("body").animate({
            scrollTop:0,
        },500);
    });
    //关闭按钮
    $(".view_tiezi_back").click(function(){
        $(".close").click();
    });
}

