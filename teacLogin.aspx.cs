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

public partial class teacLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session["isTeacher"] = null;
        }
        if (Session["isTeacher"] != null)
        {
            Response.Redirect("~/teacher.aspx");
        }
    }

    [WebMethod]
    public static string login(string ln,string pw) { 
        int rs = 1;
        if (ln.Equals("") || pw.Equals(""))
            rs = -1;
        else
        {
            var data = UserDao.getInstance().checkTeacLn(ln);
            if (data.Read())
            {
                if (data.HasRows)
                {
                    string data_pw = data["pw"].ToString();
                    if (data_pw.Equals(pw))
                    {
                        rs = 1;
                        HttpContext.Current.Session["u_id"] = data["id"].ToString();
                        HttpContext.Current.Session["teacName"] = data["name"].ToString();
                        HttpContext.Current.Session["isTeacher"] = "1";
                    }
                    else
                    {
                        rs = -3;
                    }
                }
            }
            else
            {
                rs = -2;
            }
        }

        return new JavaScriptSerializer().Serialize(rs.ToString());
    }
}
