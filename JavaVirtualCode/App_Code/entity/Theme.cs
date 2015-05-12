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
///Theme 的摘要说明
/// </summary>
public class Theme
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    private string content;

    public string Content
    {
        get { return content; }
        set { content = value; }
    }
    private string u_id;

    public string U_id
    {
        get { return u_id; }
        set { u_id = value; }
    }
    private string uname;

    public string Uname
    {
        get { return uname; }
        set { uname = value; }
    }
    private string hot_index;

    public string Hot_index
    {
        get { return hot_index; }
        set { hot_index = value; }
    }
    private string time;

    public string Time
    {
        get { return time; }
        set { time = value; }
    }
	public Theme(string id,string title,string content,string u_id,string uname,string hot_index,string time){
        this.id = id;
        this.title = title;
        this.content = content;
        this.u_id = u_id;
        this.uname = uname;
        this.hot_index = hot_index;
        this.time = time;
    }
}
