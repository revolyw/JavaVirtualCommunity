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
///Knowledge_Content 的摘要说明
/// </summary>
public class Knowledge_Content
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string content;

    public string Content
    {
        get { return content; }
        set { content = value; }
    }
	public Knowledge_Content(string id,string content)
	{
        this.id = id;
        this.content = content;
	}
}
