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
///teacher 的摘要说明
/// </summary>
public class Teacher
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string ln;

    public string Ln
    {
        get { return ln; }
        set { ln = value; }
    }
    private string pw;

    public string Pw
    {
        get { return pw; }
        set { pw = value; }
    }
    private string role;

    public string Role
    {
        get { return role; }
        set { role = value; }
    }
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string sex;

    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }
    private string professional;

    public string Professional
    {
        get { return professional; }
        set { professional = value; }
    }
    private string degree;

    public string Degree
    {
        get { return degree; }
        set { degree = value; }
    }
    private string phone;

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    private string introduce;

    public string Introduce
    {
        get { return introduce; }
        set { introduce = value; }
    }

    public Teacher(string id,string ln,string role,string name,string sex,string professional,string degree,string phone,string email,string address,string introduce)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this.id = id;
        this.ln = ln;
        this.role = role;
        this.name = name;
        this.sex = sex;
        this.professional = professional;
        this.degree = degree;
        this.phone = phone;
        this.email = email;
        this.address = address;
        this.introduce = introduce;
	}
}
