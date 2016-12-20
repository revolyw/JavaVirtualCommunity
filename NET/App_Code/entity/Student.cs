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
///Student 的摘要说明
/// </summary>
public class Student
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
    private string no;

    public string No
    {
        get { return no; }
        set { no = value; }
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
    private string cls;

    public string Cls
    {
        get { return cls; }
        set { cls = value; }
    }
    private string birthday;

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    private string introduce;

    public string Introduce
    {
        get { return introduce; }
        set { introduce = value; }
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
    private string grp;

    public string Grp
    {
        get { return grp; }
        set { grp = value; }
    }
    private string learn_level;

    public string Learn_level
    {
        get { return learn_level; }
        set { learn_level = value; }
    }
    private string power;

    public string Power
    {
        get { return power; }
        set { power = value; }
    }
    private string is_used;

    public string Is_used
    {
        get { return is_used; }
        set { is_used = value; }
    }
    private string reg_date;

    public string Reg_date
    {
        get { return reg_date; }
        set { reg_date = value; }
    }
    private string pass_date;

    public string Pass_date
    {
        get { return pass_date; }
        set { pass_date = value; }
    }
	
    public Student() { }
    public Student(string ln, string pw, string no, string name)
    {
        this.ln = ln;
        this.pw = pw;
        this.no = no;
        this.name = name;
    }
    public void setPendingLn(string id,string ln, string no,string cls, string name,string reg_date)
    {
        this.id = id;
        this.ln = ln;
        this.no = no;
        this.cls = cls;
        this.name = name;
        this.reg_date = reg_date;
    }
}
