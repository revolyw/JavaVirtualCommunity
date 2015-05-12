window=getQueryString("message");
function getQueryString(name)
{
	var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)");
	var r = window.location.search.substr(1).match(reg);
	if(!r)
	{
	}else{
		alert(decodeURI(r[2]));
		window.location.search="";
	}
}

//$(document).ready(function(){
//$.ajax({              
//            type: "post", //要用post方式                 
//            url: "home.aspx/SayHello",//方法所在页面和方法名
//            contentType: "application/json; charset=utf-8",     
//            dataType: "json",     
//            success: function(data) {
//                alert(data.d);//返回的数据用data.d获取内容
//            },
//            error: function(err) {     
//                alert(err);     
//            }     
//        });
//});