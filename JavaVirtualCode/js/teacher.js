
$(document).ready(function(e){
    /*************教师登陆页面的脚本**********/
    $("#btnSubmit").click(function(){
        var ln = $("#ln").val();
        var pw = $("#pw").val();
        if(ln == "" || pw == ""){
             alert("账号密码不能为空！");
             return ;
        }
        var submitParam = '{ln:"'+ln+'",pw:"'+pw+'"}';
        $.ajax({
             type:"post",
            aysnc:false,
            url:"teacLogin.aspx/login",
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            data:submitParam
        }).done(function(data){
                var json = eval("("+data.d+")");
                var info = "";
                if(json=="1"){
                    location.href="teacher.aspx";
                }else if(json=="-1"){
                    info += "输入有误\n";
                }else if(json=="-2"){
                    info += "账号不存在\n";
                }else{//-3
                    info += "密码错误\n";
                }
                if(info != "")
                    alert(info);
           })
          .fail(function(error){
                alert("登陆失败");
          });
    });
    /***********************/
    $("#regMng").click(function(){
        //加载待审批的账号 
        getPendingLns();
        //隐藏分页按钮组
        $(".pageBtnGroup").fadeOut();
    });
    $("#classMng").click(function(){
         //加载班级管理选项
         classMng();
         //隐藏分页按钮组
         $(".pageBtnGroup").fadeOut();
    });
    $("#messageMng").click(function(){
         //加载学生留言
         loadMessages();
         //显示分页按钮组
         $(".pageBtnGroup").fadeIn();
    });
    
    ////init
    $("#classMng").click();
});

//加载学生留言
function loadMessages(){
    var pageSize = 5;
    
    var rsString = "";
//    rsString += "<p style='color:Red;'>注意事项如下：</p>";
//    rsString += "<p style='color:Red;'>* 请确保ie浏览器模式在IE8以上，文档模式在IE9标准以上</p>";
//    rsString += "<p style='color:Red;'>* 请确保ie浏览器开启了ActiveX插件的相关选项（不能有禁用项）</p>";
//    rsString += "<p style='color:Red;'>* Excel操作请保证一次只操作一个Excel</p>";
//    rsString += "<p style='color:Red;'>* 同步Excel数据到页面前请先保存Excel内容</p>";

    $("#left_nav").html(rsString);
    $("#main").html("");
    var submitParam = '{pageSize:"'+pageSize+'"}'
    $.ajax({
            type:"post",
            aysnc:false,
            url:"teacher.aspx/loadMessages",
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            data:submitParam
            }).done(function(data){
                    var json = eval("("+data.d+")");
                    //构造分页对象
                    var msgPageTool = new pageTool(json,pageSize,5);
                    //初始化
                    msgPageTool.init($("#main"),getOneDataHtml,initPerPageAction);
                })
              .fail(function(error){
                    alert("get data error in getPendingLns!");
                });
}
//取得一页留言html字符串
function getOneDataHtml(Data){
    var htmlStr = "";
    for(var i = 0;i < Data.length; i++){
         htmlStr += "<div class=\"messageList \">";
         htmlStr +=     "<img class=\"messageList_img "+(Data[i][1].Type=="to_tec"?"blue_border":"red_border")+"\" src=\""+(Data[i][1].Type=="to_tec"?"img/student_head.png":"img/teacher_head.png")+"\" />";
         htmlStr +=     "<span class=\"messageList_uname\">"+(Data[i][1].Type=="to_tec"?Data[i][0]:Data[i][2])+"</span>";
         htmlStr +=     "<span class =\"messageList_content\">"+(Data[i][1].Type=="to_tec"?"":"回复 <code>"+Data[i][0]+"</code> ")+""+Data[i][1].Content+"</span>";
         htmlStr +=     "<div class=\"replyContainer\">"
         htmlStr +=         "<span class=\"messageList_time\">"+Data[i][1].Time+"</span>";
       if(Data[i][1].Type=="to_tec"){
         htmlStr +=         "<a class=\"messageList_reply\" href=\"javascript:void(0);\" to=\""+Data[i][1].Stu_id+"\">回复</a>";
         htmlStr +=         "<div class=\"div_reply\" style=\"display:none\">";
         htmlStr +=             "<textarea style=\"width:100%;height:100px;\" placeholder=\"回复 "+Data[i][0]+"\"></textarea>";
         htmlStr +=             "<div class=\"btn btn-info btn_reply\" style=\"width:100%\" to=\""+Data[i][1].Stu_id+"\">回复</div>";
         htmlStr +=         "</div>";
       }
         htmlStr +=     "</div>";
         htmlStr += "</div>";
    }
    return htmlStr;
}
//初始化每页留言动作
function initPerPageAction(pgTool){
    var pagingAreaDomObj = pgTool.pagingAreaDomObj;
    //回复块快关按钮
    pagingAreaDomObj.find(".messageList_reply").click(function(){
        $(this).next(".div_reply").slideToggle();
    });
    //回复提交按钮
    pagingAreaDomObj.find(".btn_reply").click(function(){
        var to_id =  $(this).attr("to");
        var content = $(this).prev("textarea").val();
        var submitParam = '{to_id:"'+to_id+'",content:"'+content+'"}';
        $.ajax({
            type:"post",
            aysnc:false,
            url:"teacher.aspx/submitReplyMsg",
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            data:submitParam
            }).done(function(data){
                    var json = eval("("+data.d+")");
                      if(json=="1"){
                        alert("回复成功！");
                        loadMessages();//刷新显示
                    }
                })
              .fail(function(error){
                    alert("reply message fail!");
                });
    });
}

//加载待审批的账号
function getPendingLns(){
    $("#left_nav").html("");
    $("#main").html("");
    $.ajax({
            type:"post",
            aysnc:false,
            url:"teacher.aspx/getPendingLns",
            contentType:"application/json; charset=utf-8",
            dataType:"json"
            }).done(function(data){
                    var json = eval("("+data.d+")");
                    var htmlStr = "";
                    if(json==""){
                        htmlStr += "<h1>暂无未审批账号！</h1>";
                         $("#main").html(htmlStr);  
                         return ;
                    }
                    htmlStr += "<h1>未审批学生名单如下</h1>";
                    htmlStr += "<table class=\"table_pendingLns\">";
                    htmlStr += "<tr><td>#</td><td>姓名</td><td>账号</td><td>学号</td><td>班级</td><td>注册时间</td><td>操作</td></tr>";
                    for(var i = 0; i<json.length;i++){
                        htmlStr += "<tr><td>"+(i+1)+"</td><td>"+json[i].Name+"</td><td>"+json[i].Ln+"</td><td>"+json[i].No+"</td><td>"+(json[i].Cls==""?"无":json[i].Cls)+"</td><td>"+json[i].Reg_date+"</td><td><a class='a_ok' id='"+json[i].Id+"' href='javascript:void(0);'>√</a><a class='a_no' id='"+json[i].Id+"' href='javascript:void(0);'>×</a></td></tr>";
                    }
                    htmlStr += "</table>";
                    $("#main").html(htmlStr);        
                    
                    //审批账号
                    approveLn();     
                })
              .fail(function(error){
                    alert("get data error in getPendingLns!");
                });
}

//审批账号
function approveLn(){
    $(".table_pendingLns td a").click(function(){
        var flag = $(this).attr("class");
        var id = $(this).attr("id");
        var submitParam = '{flag:"'+flag+'",id:"'+id+'"}';
        $.ajax({
            type:"post",
            aysnc:false,
            url:"teacher.aspx/approveLn",
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            data:submitParam
            }).done(function(data){
                    var json = eval("("+data.d+")");
                    if(json=="1"){
                        //刷新数据
                        getPendingLns();
                    }else{
                        alert("操作失败！");
                    }
                })
              .fail(function(error){
                    alert("get data error in approve!");
                });
    });     
}

//加载班级管理选项
function classMng(){
    //插入左侧选项
    var rsString = "</br>";

    rsString += '<div class="btn-group-vertical" role="group" aria-label="...">';
//    rsString +=     '<button id="nav2_createXls" type="button" class="btn btn-default">创建学生文件(xls)</button>';
    rsString +=     '<button id="nav2_choiseXls" type="button" class="btn btn-success">选择学生文件(xls)</button>';
    rsString += '</div>';
    rsString += '</br></br>';
    rsString += "<p style='color:Red;'>注意事项如下：</p>";
    rsString += "<p style='color:Red;'>* 请确保ie浏览器模式在IE8以上，文档模式在IE9标准以上</p>";
    rsString += "<p style='color:Red;'>* 请确保ie浏览器开启了ActiveX插件的相关选项（不能有禁用项）</p>";
    rsString += "<p style='color:Red;'>* Excel操作请保证一次只操作一个Excel</p>";
    rsString += "<p style='color:Red;'>* 同步Excel数据到页面前请先保存Excel内容</p>";
    
    
    $("#left_nav").html(rsString);
    
    //创建班级文件
//    createXls();
    //选择学生Excel
    choiseExcel();
}

//创建班级Excel(xls)
//function createXls(){
//    var path = "";
//    $("#nav2_createXls").click(function(){
//        path = "C:\\Users\\Administrator\\Desktop\\students.xls";
//        var xlsApp_init = new ActiveXObject("Excel.Application");//获取Excel应用程序对象 
//        var xlsBooks_init = xlsApp_init.Workbooks.Add();//创建workbooks对象
//        var xlsSheet_init = xlsBooks_init.ActiveSheet; //获得workboos中活动的sheet
//        xlsSheet_init.SaveAs(path);
//        xlsSheet_init.Application.Visible = true;
//    });
//}

//选择班级Excel
var xlsApp;
var xlsBooks;
var xlsSheet;
var num = 0;
function choiseExcel(){
    //插入文件上传标签（隐藏）
    var rsString = "<input id=\"ExcelFile\" type=\"file\" style=\"position:absolute;z-index:-1000;\" ></input>";
    $("#main").html(rsString);
    rsString = "<h1>学生信息如下：</h1>";
    rsString += '<div class="btn-group" role="group" aria-label="...">';
    rsString +=     '<button type="button" class="btn btn-success btn_submitExcel">插入一行</button>';
    rsString +=     '<button type="button" class="btn btn-success btn_toExcel">同步数据到Excel</button>';
    rsString +=     '<button type="button" class="btn btn-success btn_toPage">同步数据到页面</button>';
    rsString +=     '<button type="button" class="btn btn-success btn_toServer">提交数据到服务器</button>';
    rsString += '</div>';
    $("#main").append(rsString);
    
    var tableStr = "<table id=\"dataTable\" class=\"table\" width=\"500\">"+
                        '<tr><td>序号</label></td><td>账号</td><td>密码</td><td>学号</td><td>姓名</td></tr>'+
                   "</table>";
    $("#main").append(tableStr);
   
     //插入一行
    $(".btn_submitExcel").click(function(){ insertOneCell(); });
    //同步数据到Excel
    $(".btn_toExcel").click(function(){ asyncDataToExcel(); });
    //同步数据到页面
    $(".btn_toPage").click(function(){ asyncDataToPage(); });
    //提交数据到服务器
    $(".btn_toServer").click(function(){ asyncDataToServer(); });
   
    //选择班级文件按钮
    $("#nav2_choiseXls").click(function(){
        $("#ExcelFile").click();
    });
    
    //获取文件url并打开 针对IE 9之后版本
    $("#ExcelFile").change(function(){
        var file_upl = document.getElementById("ExcelFile");
        file_upl.select();  
        file_upl.blur();   
        var filePath = document.selection.createRange().text;
        if(filePath == "")
            return null;
        xlsApp = new ActiveXObject("Excel.Application");//获取Excel应用程序对象 
        xlsBooks = xlsApp.Workbooks.Open(filePath);
        xlsSheet = xlsBooks.ActiveSheet; //获得workboos中活动的sheet
        xlsSheet.Application.Visible = true;
        getDataFromExcel();
    });
}

//从Excel获取数据
function getDataFromExcel(){
    num = 0;
    var tab = document.getElementById("dataTable");
    var i = 2;//数据从第二行开始取
    var hasRow = true; //是否还有行
    var rowCount = tab.rows.length;
    for(j=rowCount-1;j>0;j--){
        tab.deleteRow(j);
    }
    while(hasRow){//只要还有行(数据)就循环
        var newTr = tab.insertRow(tab.rows.length); //创建新行
        var value = "";
        //序号
        var idTd = newTr.insertCell(0);
        value = xlsSheet.Cells(i,1).Value==undefined?"":xlsSheet.Cells(i,1);
        idTd.innerHTML = "<input type='text' class='input_text form-control' id='txt_0"+i+"' value='"+value+"' />";
        //账号
        var lnTd = newTr.insertCell(1); 
        value = xlsSheet.Cells(i,2).Value==undefined?"":xlsSheet.Cells(i,2);
        lnTd.innerHTML = "<input type='text' class='input_text form-control' id='txt_1"+i+"' value='"+value+"' />";
        //密码
        var pwTd = newTr.insertCell(2); 
        value = xlsSheet.Cells(i,3).Value==undefined?"":xlsSheet.Cells(i,3);
        pwTd.innerHTML = "<input type='text' class='input_text form-control' id='txt_2"+i+"' value='"+value+"' />";
        //学号
        var noTd = newTr.insertCell(3); 
        value = xlsSheet.Cells(i,4).Value==undefined?"":xlsSheet.Cells(i,4);
        noTd.innerHTML = "<input type='text' class='input_text form-control' id='txt_3"+i+"' value='"+value+"' />";
        //姓名
        var nameTd = newTr.insertCell(4); 
        value = xlsSheet.Cells(i,5).Value==undefined?"":xlsSheet.Cells(i,5);
        nameTd.innerHTML = "<input type='text' class='input_text form-control' id='txt_4"+i+"' value='"+value+"' />";
        
        i++;
        num++;
        
        if(xlsSheet.Cells(i,1).Value == undefined){
            hasRow = false;
            break;
        }
    }
}

//插入一行
function insertOneCell(){
    var tab = document.getElementById("dataTable");
    var rowIndex = tab.rows.length;
    var newTr = tab.insertRow(rowIndex); //创建新行
    rowIndex++;
    num++;
    //序号
    var idTd = newTr.insertCell(0); 
    idTd.innerHTML = "<input type='text' id='txt_0"+rowIndex+"' class='input_text form-control' value='"+num+"' />";
    //账号
    var lnTd = newTr.insertCell(1); 
    lnTd.innerHTML = "<input type='text' id='txt_1"+rowIndex+"' class='input_text form-control' value='' />";
    //密码
    var pwTd = newTr.insertCell(2); 
    pwTd.innerHTML = "<input type='text' id='txt_2"+rowIndex+"' class='input_text form-control' value='' />";
    //学号
    var noTd = newTr.insertCell(3); 
    noTd.innerHTML = "<input type='text' id='txt_3"+rowIndex+"' class='input_text form-control' value='' />";
    //姓名
    var nameTd = newTr.insertCell(4); 
    nameTd.innerHTML = "<input type='text' id='txt_4"+rowIndex+"' class='input_text form-control' value='' />";
}
//删除一行
function delOneCell(){
}

//同步数据到Excel
function asyncDataToExcel(){
    var tab = document.getElementById("dataTable");
    for(i = 2;i<=tab.rows.length;i++){
        xlsSheet.Cells(i,1).Value = $("#txt_0"+i).val();
        xlsSheet.Cells(i,2).Value = $("#txt_1"+i).val();
        xlsSheet.Cells(i,3).Value = $("#txt_2"+i).val();
        xlsSheet.Cells(i,4).Value = $("#txt_3"+i).val();
        xlsSheet.Cells(i,5).Value = $("#txt_4"+i).val();
    }
}

//同步数据到页面
function asyncDataToPage(){
    getDataFromExcel();
}

//提交数据到服务器
function asyncDataToServer(){
    var tab = document.getElementById("dataTable");
    var rowIndex = tab.rows.length;
    var jsonStr = '{json:"[';
    for(var i = 2;i <= rowIndex;i++)
    {
        jsonStr += '{\\"ln\\":\\"'+$("#txt_1"+i).val()+'\\",\\"pw\\":\\"'+$("#txt_2"+i).val()+'\\",\\"no\\":\\"'+$("#txt_3"+i).val()+'\\",\\"name\\":\\"'+$("#txt_4"+i).val()+'\\"}';
        if(i!==rowIndex)
            jsonStr+=',';
    }
    jsonStr += ']"}';
    
    $.ajax({type:"post",url:"teacher.aspx/insertStuByBatch",contentType:"application/json; charset=utf-8",dataType: "json",data:jsonStr})
    .done(function(data){
        var json = eval("("+data.d+")");
        if(json=="False")
            alert("提交数据失败，请检查录入账号是否已经注册过，或学生学号已经被注册！");
        else
            alert("成功！");
    })
    .fail(function(error){
        alert("提交失败");
    });
}