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

public partial class reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void Unnamed1_Click(object sender, EventArgs e)
	{
        string ln_s = ln.Value;
        string pw_s = pw.Value;
        string _pw_s = _pw.Value;
        string no_s = no.Value;
        string name_s = name.Value;

        var rs = UserDao.getInstance().getStudents();
        //检测账户和学号是否已存在
        string lnc = "";
        string noc = "";
        bool checkFlag = true;

        while (rs.Read())
        {
            if (rs.HasRows)
            {
                lnc = rs["ln"].ToString();
                noc = rs["no"].ToString();
                if (lnc == ln_s || noc == no_s)
                {   
                    checkFlag = false;
                    break;
                }
            }
        }

        int rsCode = 0;
        if(checkFlag == true){
            rsCode = UserDao.getInstance().addStudent(ln_s, pw_s, no_s, "student", name_s, "", "", "", "", "", "", "", "", "", "-1", "", "");
        }

        if (rsCode == 1)
            Response.Redirect("home.aspx?message=注册成功");
        else
            Response.Redirect("home.aspx?message=注册失败");
	}
}
