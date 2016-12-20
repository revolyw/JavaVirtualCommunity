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
///Message 的摘要说明
/// </summary>
public class Message
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string stu_id;

    public string Stu_id
    {
        get { return stu_id; }
        set { stu_id = value; }
    }
    private string teac_id;

    public string Teac_id
    {
        get { return teac_id; }
        set { teac_id = value; }
    }
    private string type;

    public string Type
    {
        get { return type; }
        set { type = value; }
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

	public Message(string id,string stu_id,string teac_id,string type,string content,string time)
	{
        this.id = id;
        this.stu_id = stu_id;
        this.teac_id = teac_id;
        this.type = type;
        this.content = content;
        this.time = time;
	}
}
