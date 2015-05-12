/* 
 * @name : 分页对象
 * @construction : 1.数据集 2.每张页面的数据数量 3.显示出来的页标偏移量（相对当前页）
 * @author : yw
 * @date : 2015.04.21
 * @version : 1.1
 * @update : 2015.04.22(第一次达到功能要求)
 * @update : 2015.04.23(进一步封装，现在使用对象只需如下两行代码)
             //构造分页对象
			  *list为后台传来的数据结果集,它应当是一个数组，其中每一个元素代表一页数据，
			  而每一页数据也应当是数组，至于每个数据可按需要分装，解析函数也可通过扩展函数传入分页对象从而执行
             var pageTool = new pageTool(list,pageSize,indexOffset);
              //初始化(支持扩展函数)
               *containerTag为装载分页区域的容器
               *Func_getOneDateHtml为获得一页数据的html字符串
               *expandFuncs待扩展的执行函数(组) *须注意函数必须传入分页对象(_this)
             pageTool.init(containerTag,Func_getOneDataHtml,expandFuncs);
 *
 * 缺陷：需要后台一次传入所有需分页的数据，对于数据量非常大的数据集不适合
 */
(function () {
    //list:数据集 pageSize:每页显示数
    function pageTool(list,pageSize,indexOffset) {//支持带参和不带参两种构造方式
        var _this = {};
        _this.list = list;
        _this.pageSize = pageSize;
        _this.crtPage = 0;
        _this.pageNum = list==undefined?0:list.length;//页面数量
        _this.indexOffset = indexOffset;//页标左右偏移量
        _this.pagingAreaDomObj = null; //分页显示区域容器的Dom对象
        
         //初始分页htmlDom
        _this.init = function(containerTag,Func_oneDateHtml,expandFuncs){
            if(_this.list == undefined || _this.list.length == 0 || _this.list == null)//如果没有数据则返回
                return ;
            var htmlStr = "";
            htmlStr += '<div class="pagingArea">';
                htmlStr += '<div class="pagingArea_content">';
                htmlStr += '</div>';
                htmlStr += '<div class="pagingArea_index">';
                    htmlStr += '<div class="pageBtnGroup">'+
                                    '<a class="btnPage" name="top"  href="javascript:void(0);">首页</a>'+
                                    '<a class="btnPage" name="last" href="javascript:void(0);">上一页</a>'+
                                    '<div class="pageIndexBlock"></div>'+
                                    '<a class="btnPage" name="next" href="javascript:void(0);">下一页</a>'+
                                    '<a class="btnPage" name="tail" href="javascript:void(0);">尾页</a>'+
                                '</div>';
                htmlStr += '</div>';
            htmlStr += '</div>';
            containerTag.html(htmlStr);
            _this.pagingAreaDomObj = containerTag.children(".pagingArea");//对容器赋值
            
            //绑定页标点击事件
            _this.pagingAreaDomObj.find(".btnPage").click(function(){
                var Data = null;
                switch($(this).attr("name")){
                    case "top": Data = _this.getTopData(); break;//首页
                    case "last": Data = _this.getLastData(); break;//上一页
                    case "next": Data = _this.getNextData(); break;//下一页
                    case "tail": Data = _this.getTailData(); break;//尾页
                    default:break;
                }
                //获得并且装入一页数据
                var htmlStr = Func_oneDateHtml(Data);
                _this.pagingAreaDomObj.find(".pagingArea_content").html(htmlStr);
                //第一次显示分页标
                _this.updatePageIndex();
                //绑定分页标点击事件
                pageIndexClick(Func_oneDateHtml,expandFuncs);
                //执行扩展函数(组)
                if(expandFuncs == undefined){}
                else if(expandFuncs instanceof Array){
                    for(var i = 0;i<expandFuncs.length;i++){
                        expandFuncs[i](_this);
                    }
                }else{
                    expandFuncs(_this);
                }
            });
            //点击第一页
            _this.pagingAreaDomObj.find(".btnPage[name='top']").click();//加载第一页数据
        }
        
        //绑定分页标点击事件
        function pageIndexClick(Func_oneDateHtml,expandFuncs){
            _this.pagingAreaDomObj.find(".pageIndexBlock a").click(function(){
        	    var pageIndex = $(this).html() - 1;
        	    var Data = _this.getOneData(pageIndex);
        	    if(Data == false)
        	        return false;
                var htmlStr = Func_oneDateHtml(Data);
                _this.pagingAreaDomObj.find(".pagingArea_content").html(htmlStr);
                //更新分页标
                _this.updatePageIndex();
                //绑定分页标点击事件(递归)
                pageIndexClick(Func_oneDateHtml,expandFuncs);
                //执行扩展函数(组)
                if(expandFuncs == undefined){}
                else if(expandFuncs instanceof Array){
                    for(var i = 0;i<expandFuncs.length;i++){
                        expandFuncs[i](_this);
                    }
                }else{
                    expandFuncs(_this);
                }
        	});
        }
        
        //刷新页标显示
        _this.updatePageIndex = function(){
            var pageIndexStr = "";
            var loopLeft,loopRight;
            //确定循环起始条件
            if(_this.crtPage - _this.indexOffset <= 0){
                loopLeft = 0;
            }else{//_this.crtPage - _this.indexOffset > 0
                loopLeft = _this.crtPage - _this.indexOffset;
            }
            //确定循环结束条件
            if(_this.crtPage + _this.indexOffset >= _this.pageNum - 1){
                loopRight = _this.pageNum - 1;
            }else{//_this.crtPage + _this.indexOffset < _this.pageNum - 1
                loopRight = _this.crtPage + _this.indexOffset;
            }
            //构造页标字符串
            if(_this.crtPage - _this.indexOffset > 0)
                pageIndexStr += "...";
            for(var i = loopLeft; i<= loopRight; i++){
                 if(i == _this.crtPage)
                        pageIndexStr += "<a class=\"crtPage\" href=\"javascript:void(0);\" name=\"anyPage\">"+(i+1)+"</a>";
                    else
                        pageIndexStr += "<a href=\"javascript:void(0);\" name=\"anyPage\">"+(i+1)+"</a>";
            }
            if(_this.crtPage + _this.indexOffset < _this.pageNum - 1)
                pageIndexStr += "...";
            //刷新页面分页页标
            _this.pagingAreaDomObj.find(".pageIndexBlock").html(pageIndexStr);
        }
         
        //设置数据集
        _this.setList = function(list){
            _this.crtPage = 0;
            _this.list = list;
            _this.pageNum = list.length;
        }
        //获得页面数量
        _this.getPageNum = function(){
            return _this.pageNum;
        }
        //返回当前页
        _this.getCrtPage = function (){
            return _this.crtPage;
        }
        //返回上一页
        _this.getLastPage = function (){
            if(_this.crtPage == 0)
                return 0;
            return _this.crtPage - 1;
        }
        //返回下一页
        _this.getNextPage = function (){
            if(_this.crtPage == _this.pageNum - 1)
                return _this.pageNum - 1;
            return _this.crtPage + 1;
        }
        
        //返回某页数据
        _this.getOneData = function (page){
            if(page < 0 || page > _this.pageNum - 1)
                return false;
            _this.crtPage = page;
            return list[page]; 
        }
        //返回当前页数据
        _this.getCrtData = function (){
            return _this.list[_this.crtPage];
        }
        //返回上一页数据
        _this.getLastData = function (){
            _this.crtPage = _this.getLastPage();
            return _this.list[_this.crtPage];
        }
        //返回下一页数据
        _this.getNextData = function (){
            _this.crtPage = _this.getNextPage();
            return _this.list[_this.crtPage];
        }
        //返回首页数据
        _this.getTopData = function (){
            _this.crtPage = 0;
            return _this.list[_this.crtPage];
        }
        //返回尾页数据
        _this.getTailData = function (){
            _this.crtPage = _this.pageNum - 1;
            return _this.list[_this.crtPage];
        }
        //返回构造对象
        return _this;
    }
    window.pageTool = pageTool;//暴露对象给顶层窗口
}());