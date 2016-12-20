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

public partial class courseIntrod : System.Web.UI.Page
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
        Response.AddHeader("Refresh", "0");
    }
}
