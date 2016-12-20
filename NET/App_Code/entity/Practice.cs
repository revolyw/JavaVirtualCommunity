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
///Practice 的摘要说明
/// </summary>
public class Practice
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
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private string type;

    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    private string img_url;

    public string Img_url
    {
        get { return img_url; }
        set { img_url = value; }
    }
    private string link_url;

    public string Link_url
    {
        get { return link_url; }
        set { link_url = value; }
    }
    private string uploadTime;

    public string UploadTime
    {
        get { return uploadTime; }
        set { uploadTime = value; }
    }

    public Practice(string id, string title, string description, string type, string img_url, string link_url, string uploadTime)
    {
        //TODO: 在此处添加构造函数逻辑
        this.id = id;
        this.title = title;
        this.description = description;
        this.type = type;
        this.img_url = img_url;
        this.link_url = link_url;
        this.uploadTime = uploadTime;
    }
}
