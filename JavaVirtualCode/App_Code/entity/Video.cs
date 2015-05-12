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
///Video 的摘要说明
/// </summary>
public class Video
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
    private string video_name;

    public string Video_name
    {
        get { return video_name; }
        set { video_name = value; }
    }
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private string link_url;

    public string Link_url
    {
        get { return link_url; }
        set { link_url = value; }
    }

    public Video(string id, string level, string super_level, string sub_num, string number, string video_name, string description, string link_url)
    {
        //TODO: 在此处添加构造函数逻辑
        this.id = id;
        this.level = level;
        this.super_level = super_level;
        this.sub_num = sub_num;
        this.number = number;
        this.video_name = video_name;
        this.description = description;
        this.link_url = link_url;
    }
}
