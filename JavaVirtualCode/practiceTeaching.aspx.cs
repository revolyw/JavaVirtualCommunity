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

public partial class practiceTeaching : System.Web.UI.Page
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
        Response.Redirect("home.aspx");
    }

    /// <summary>
    /// 获得实验记录
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public static string getPractices(string pageSize)
    {
        int pgSize = int.Parse(pageSize);
        var rs = PracticeDao.getInstance().getPractices();

        List<Object> list = new List<object>();
        List<Practice> onePagePractice = null;
        Practice practice = null;

        int i = 0;
        //用户检测是否存在
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                if (i % pgSize == 0)
                    onePagePractice = new List<Practice>();
                string id = rs["id"].ToString();
                string title = rs["title"].ToString();
                string description = rs["description"].ToString();
                string type = rs["type"].ToString();
                string img_url = rs["img_url"].ToString();
                string link_url = rs["link_url"].ToString();
                string uploadTime = rs["uploadTime"].ToString();
                practice = new Practice(id, title, description, type, img_url, link_url, uploadTime);
                onePagePractice.Add(practice);

                if (++i % pgSize == 0)
                    list.Add(onePagePractice);
            }
        }
        if (onePagePractice != null && onePagePractice.Count != pgSize)
            list.Add(onePagePractice);

        return new JavaScriptSerializer().Serialize(list);
    }
}
