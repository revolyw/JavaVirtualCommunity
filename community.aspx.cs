using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data.Odbc;
using System.Collections;
using System.Collections.Generic;

public partial class community : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session["u_id"] = null;
        }
        if (Session["u_id"] != null)
        {
            s_u_name.Text = Session["userName"].ToString();
            display_lg_off.CssClass = "show-off";
            display_lg_on.CssClass = "show-on";
        }
        else
        { //***
            Session["u_id"] = null;
            Session["userName"] = null;
            Session.Abandon();
            //***
            display_lg_off.CssClass = "show-on";
            display_lg_on.CssClass = "show-off";
        }
    }
    protected void loginOff_Click(object sender, EventArgs e)
    {
        //***
        Session["u_id"] = null;
        Session["userName"] = null;
        Session.Abandon();
        //***
        //清除浏览器缓存
        //Response.Buffer = true;
        //Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        //Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        //Response.Expires = 0;
        //Response.CacheControl = "no-cache";
        //Response.Cache.SetNoStore(); 
        Response.AddHeader("Refresh", "0");
    }

    /// <summary>
    /// 发帖
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <returns></returns>
    [WebMethod]
    public static string fatie(string title,string content)
    {
        int rs = 0;
        string u_id = null;
        if(HttpContext.Current.Session["u_id"] == null)
            rs = -1;
        else{
            u_id = HttpContext.Current.Session["u_id"].ToString();
            rs = CommunityDao.getInstance().insertThemes(u_id, title, content);
        }
        return new JavaScriptSerializer().Serialize(rs.ToString());
    }

    /// <summary>
    /// 获取所有帖子
    /// </summary>
    /// <param name="pageSize">页面显示数</param>
    /// <returns></returns>
    [WebMethod]
    public static string getThemes(string pageSize) {
        var rs = CommunityDao.getInstance().getThemes();
        List<Object> list = new List<object>();
        List<Theme> themes = new List<Theme>();
        Theme theme = null;
        int i = 0;
        //用户检测是否存在
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                string id = rs["id"].ToString();
                string title = rs["title"].ToString();
                string content = rs["content"].ToString();
                string u_id = rs["u_id"].ToString();
                string uname = rs["name"].ToString();
                string hot_index = rs["hot_index"].ToString();
                string time = rs["time"].ToString();
                theme = new Theme(id, title, content, u_id,uname, hot_index, time);
                themes.Add(theme);
                if (++i % int.Parse(pageSize) == 0) {
                    list.Add(themes);
                    themes = new List<Theme>();
                }
            }
        }
        if (themes.Count != int.Parse(pageSize))
            list.Add(themes);
        return new JavaScriptSerializer().Serialize(list);
    }

    /// <summary>
    /// 获取一个帖子
    /// </summary>
    /// <param name="themeId"></param>
    /// <returns>list{{一个帖子对象},{多个留言对象}}</returns>
    [WebMethod]
    public static string getOneTheme(string themeId, string pageSize)
    {
        var rs = CommunityDao.getInstance().getOneTheme(themeId);//return List<OdbcDataReader>
        var oneTiezi = rs[0];
        var commentsRs = rs[1];

        List<Object> list = new List<object>();
        Theme theme = null;
        List<Object> listX = new List<object>();
        List<Object> listY = null;
        List<Object> oneComment = null;
        Comment comment = null;
        int i = 0;
        //一个帖子
        if (oneTiezi.Read())
        {
            if (oneTiezi.HasRows)
            {
                string id = oneTiezi["id"].ToString();
                string title = oneTiezi["title"].ToString();
                string content = oneTiezi["content"].ToString();
                string u_id = oneTiezi["u_id"].ToString();
                string uname = oneTiezi["name"].ToString();
                string hot_index = oneTiezi["hot_index"].ToString();
                string time = oneTiezi["time"].ToString();
                theme = new Theme(id, title, content, u_id, uname, hot_index, time);
            }
        }

        //帖子所含留言
        while (commentsRs.Read())
        {
            if (commentsRs.HasRows)
            {
                if (i % int.Parse(pageSize) == 0)
                    listY = new List<object>();

                string id = commentsRs["id"].ToString();
                string theme_id = commentsRs["theme_id"].ToString();
                string u_id = commentsRs["u_id"].ToString();
                string content = commentsRs["content"].ToString();
                string reply_num = commentsRs["reply_num"].ToString();
                string time = commentsRs["time"].ToString();
                comment = new Comment(id, theme_id, u_id, content, reply_num, time);
                string uname = commentsRs["name"].ToString();

                oneComment = new List<object>();
                oneComment.Add(uname);
                oneComment.Add(comment);
                listY.Add(oneComment);

                if (++i % int.Parse(pageSize) == 0)
                    listX.Add(listY);
            }
        }
        if (listY != null && listY.Count != int.Parse(pageSize))
            listX.Add(listY);

        list.Add(theme);
        if (listX.Count != 0)
            list.Add(listX);
        return new JavaScriptSerializer().Serialize(list);
    }

    /// <summary>
    /// 提交评论
    /// </summary>
    /// <param name="theme_id">帖子主键</param>
    /// <param name="submitString">评论内容</param>
    /// <returns></returns>
    [WebMethod]
    public static string commentSubmit(string theme_id, string submitString)
    {
        int rs = 0;
        if (HttpContext.Current.Session["u_id"] == null)
            rs = -1;
        else
        {
            string u_id = HttpContext.Current.Session["u_id"].ToString();
            rs = CommunityDao.getInstance().insertOneComment(u_id, theme_id, submitString);
        }
            return new JavaScriptSerializer().Serialize(rs.ToString());
    }

    /// <summary>
    /// 获取一条评论所有的回复
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns></returns>
    [WebMethod]
    public static string getReplys(string commentId,string pageSize)
    {
        OdbcDataReader rs = CommunityDao.getInstance().getReplys(commentId);
        List<Object> list = new List<object>();
        List<Object> onePageList = null;
        Reply reply = null;
        int i = 0;
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                if (i % int.Parse(pageSize) == 0)
                    onePageList = new List<object>();
                string id = rs["id"].ToString();
                string comment_id = rs["comment_id"].ToString();
                string from_uid = rs["from_uid"].ToString();
                string to_uid = rs["to_uid"].ToString();
                string content = rs["content"].ToString();
                string time = rs["time"].ToString();
                string from_name = rs["from_name"].ToString();
                string to_name = rs["to_name"].ToString();
                reply = new Reply(id, comment_id, from_uid, to_uid, content, time, from_name, to_name);
                onePageList.Add(reply);
                if (++i % int.Parse(pageSize) == 0)
                    list.Add(onePageList);
            }
        }
        if (onePageList != null && onePageList.Count != int.Parse(pageSize))
            list.Add(onePageList);

        return new JavaScriptSerializer().Serialize(list);
    }

    /// <summary>
    /// 回复
    /// </summary>
    /// <param name="toId"></param>
    /// <param name="commentId"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    [WebMethod]
    public static string reply(string toId,string commentId,string content) {
        int rs = 0;
        if (HttpContext.Current.Session["u_id"] == null)
            rs = -1;
        else
        {
            string u_id = HttpContext.Current.Session["u_id"].ToString();
            rs = CommunityDao.getInstance().insertOneReply(u_id, toId, commentId, content);
        }
        return new JavaScriptSerializer().Serialize(rs.ToString());
    }
}
