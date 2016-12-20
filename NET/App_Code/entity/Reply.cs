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
///Reply 的摘要说明
/// </summary>
public class Reply
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string comment_id;

    public string Comment_id
    {
        get { return comment_id; }
        set { comment_id = value; }
    }
    private string from_uid;

    public string From_uid
    {
        get { return from_uid; }
        set { from_uid = value; }
    }
    private string to_uid;

    public string To_uid
    {
        get { return to_uid; }
        set { to_uid = value; }
    }
    private string content;

    public string Content
    {
        get { return content; }
        set { content = value; }
    }
    private string time;

    public string Time
    {
        get { return time; }
        set { time = value; }
    }
    private string from_name;

    public string From_name
    {
        get { return from_name; }
        set { from_name = value; }
    }
    private string to_name;

    public string To_name
    {
        get { return to_name; }
        set { to_name = value; }
    }

    public Reply(string id, string comment_id, string from_uid, string to_uid, string content, string time, string from_name, string to_name) {
        this.id = id;
        this.comment_id = comment_id;
        this.from_uid = from_uid;
        this.to_uid = to_uid;
        this.content = content;
        this.time = time;
        this.from_name = from_name;
        this.to_name = to_name;
    }
}
