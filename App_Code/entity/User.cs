using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///User 的摘要说明
/// </summary>
public class User
{
    private string ln;
    private string pw;
	public User(){}
    public User(string ln, string pw) {
        this.ln = ln;
        this.pw = pw;
    }
    public void setLn(string ln){
        this.ln = ln;
    }
    public string getLn() {
        return this.ln;
    }
    public void setPw(string pw) {
        this.pw = pw;
    }
    public string getPw() {
        return this.pw;
    }
}
