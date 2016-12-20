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
///knowledge 的摘要说明
/// </summary>
public class Knowledge
{

    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string level;

    public string Level
    {
        get { return level; }
        set { level = value; }
    }
    private string super_level;

    public string Super_level
    {
        get { return super_level; }
        set { super_level = value; }
    }
    private string sub_num;

    public string Sub_num
    {
        get { return sub_num; }
        set { sub_num = value; }
    }
    private string number;

    public string Number
    {
        get { return number; }
        set { number = value; }
    }
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private string content;

    public string Content
    {
        get { return content; }
        set { content = value; }
    }

    public Knowledge(){}

    public Knowledge(string id, string level, string super_level, string sub_num,string number, string description,string content)
	{
		//TODO: 在此处添加构造函数逻辑
        this.id = id;
        this.level = level;
        this.super_level = super_level;
        this.sub_num = sub_num;
        this.number = number;
        this.description = description;
        this.content = content;
	}
    
}
