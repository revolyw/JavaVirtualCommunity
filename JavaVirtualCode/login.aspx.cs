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
using System.Data.Odbc;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
		string message = "";
		//用户登录状态检测 by session
		if (Session["u_id"] != null)
		{
			message = "您已经登录！";
		}
		else
		{
            var rs = UserDao.getInstance().getStudents();
			//用户检测是否存在
			char checkFlag = 'x';
			string ln = "";
			string pw = "";
			while (rs.Read())
            {
                if (rs.HasRows)
                {
                    ln = rs["ln"].ToString();
                    pw = rs["pw"].ToString();
                    if (ln == userName.Value)
                    {
                        if (pw == passWord.Value)
                        {
                            Session["u_id"] = rs["id"].ToString();
                            Session["userName"] = rs["name"].ToString();
                            checkFlag = 'y';
                            break;
                        }
                        else
                        {
                            checkFlag = 'f';
                            break;
                        }
                    }
                }
			}
			if (checkFlag == 'x')
				message = "用户不存在！";
			else if (checkFlag == 'f')
				message = "密码错误！";
			else if (checkFlag == 'y')
				message = "登录成功！";
		} 
		Response.Redirect("home.aspx?message=" + message);
    }
}
