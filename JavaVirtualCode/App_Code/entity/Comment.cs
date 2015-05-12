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
///Comment 的摘要说明
/// </summary>
public class Comment
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string theme_id;

    public string Theme_id
    {
        get { return theme_id; }
        set { theme_id = value; }
    }
    private string u_id;

    public string U_id
    {
        get { return u_id; }
        set { u_id = value; }
    }
    private string content;

    public string Content
    {
        get { return content; }
        set { content = value; }
    }
    private string reply_num;

    public string Reply_num
    {
        get { return reply_num; }
        set { reply_num = value; }
    }

    private string time;

    public string Time
    {
        get { return time; }
        set { time = value; }
    }
	public Comment(string id ,string theme_id,string u_id,string content,string reply_num,string time)
	{
        this.id = id;
        this.theme_id = theme_id;
        this.u_id = u_id;
        this.content = content;
        this.reply_num = reply_num;
        this.time = time;
	}
}
