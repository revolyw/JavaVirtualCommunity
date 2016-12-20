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
using System.Collections.Generic;

public partial class onDemand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session["userName"] = null;
        }
        if (Session["userName"] != null)
        {
            s_u_name.Text = Session["userName"].ToString();
            display_lg_off.CssClass = "show-off";
            display_lg_on.CssClass = "show-on";
        }
        else
        {
            //***
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
        Session["u_id"] = null;
        Session["userName"] = null;
        Session.Abandon();
        Response.Write("<script> alert("+Session["u_id"].ToString()+Session["userName"].ToString()+");</script>");
        //清除浏览器缓存
        //Response.Buffer = true;
        //Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        //Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        //Response.Expires = 0;
        //Response.CacheControl = "no-cache";
        //Response.Cache.SetNoStore(); 
        Response.Redirect("onDemand.aspx");
    }

    [WebMethod]
    public static string getVideos()
    {
        var rs = VideoDao.getInstance().getVideos();
        List<Video> videos = new List<Video>();
        Video video = null;
        //用户检测是否存在
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                string id = rs["id"].ToString();
                string level = rs["level"].ToString();
                string super_level = "super_level";
                if (rs["super_level"] == System.DBNull.Value)
                    super_level = null;
                else
                    super_level = rs["super_level"].ToString();
                string sub_num = rs["sub_num"].ToString();
                string number = rs["number"].ToString();
                string video_name = rs["video_name"].ToString();
                string description = rs["description"].ToString();
                string link_url = rs["link_url"].ToString();
                video = new Video(id, level, super_level, sub_num, number, video_name, description, link_url);
                videos.Add(video);
            }
        }
        return new JavaScriptSerializer().Serialize(videos);
    }

    [WebMethod]
    public static string getTeachers()
    {
        var rs = UserDao.getInstance().getTeachers();
        List<Teacher> teachers = new List<Teacher>();
        Teacher teacher = null;

        while (rs.Read())
        {
            if (rs.HasRows)
            {
                string id = rs["id"].ToString();
                string ln = rs["ln"].ToString();
                string role = rs["role"].ToString();
                string name = rs["name"].ToString();
                string sex = rs["sex"].ToString();
                string professional = rs["professional"].ToString();
                string degree = rs["degree"].ToString();
                string phone = rs["phone"].ToString();
                string email = rs["email"].ToString();
                string address = rs["address"].ToString();
                string introduce = rs["introduce"].ToString();
                teacher = new Teacher(id, ln, role, name, sex, professional, degree, phone, email, address, introduce);
                teachers.Add(teacher);
            }
        }
        return new JavaScriptSerializer().Serialize(teachers);
    }

    /// <summary>
    /// 提交留言 (学生给老师 type="to_tec")
    /// </summary>
    /// <param name="u_id"></param>
    /// <param name="teacherId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    [WebMethod]
    public static string submitMessage(string teacherId, string message)
    {
        string type = "to_tec";
        int rs = 0;

        if (HttpContext.Current.Session["u_id"] == null)
            rs = -1;
        else
        {
            string u_id = HttpContext.Current.Session["u_id"].ToString();
            rs = MessageDao.getInstance().insertMessage(u_id, teacherId, type, message);
        }

        return new JavaScriptSerializer().Serialize(rs.ToString());
    }

    /// <summary>
    /// 取得所有的留言
    /// </summary>
    /// <param name="teachId"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [WebMethod]
    public static string getMessages(string teachId, string pageSize)
    {
        //string u_id = "";
        if(HttpContext.Current.Session["u_id"]==null)
            return new JavaScriptSerializer().Serialize("");
        string u_id = HttpContext.Current.Session["u_id"].ToString();
        var rs = MessageDao.getInstance().getMessages(teachId, u_id);

        List<Object> list = new List<object>();
        List<Object> listX = null;
        List<Object> listY = null;
        Message message = null;
        int i = 0;

        while (rs.Read())
        {
            if (rs.HasRows)
            {

                if (i % int.Parse(pageSize) == 0)
                    listX = new List<object>();

                string id = rs["id"].ToString();
                string stu_id = rs["stu_id"].ToString();
                string teac_id = rs["teac_id"].ToString();
                string type = rs["type"].ToString();
                string content = rs["content"].ToString();
                string time = rs["uploadTime"].ToString();
                message = new Message(id, stu_id, teac_id, type, content, time);

                string s_name = rs["s_name"].ToString();
                string t_name = rs["t_name"].ToString();
                listY = new List<object>();
                listY.Add(s_name);
                listY.Add(message);
                listY.Add(t_name);

                listX.Add(listY);
                if (++i % int.Parse(pageSize) == 0)
                    list.Add(listX);
            }
        }
        if (listX != null && listX.Count != int.Parse(pageSize))//X不等于pageSize则说明最后一页未添加进list，若为pageSize说明最后一页恰好填满
            list.Add(listX);

        return new JavaScriptSerializer().Serialize(list);
    }
    
}
