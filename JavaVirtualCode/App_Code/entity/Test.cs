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
///Test 的摘要说明
/// </summary>
public class Test
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    private string sectionId;

    public string SectionId
    {
        get { return sectionId; }
        set { sectionId = value; }
    }
    private string sectionTitle;

    public string SectionTitle
    {
        get { return sectionTitle; }
        set { sectionTitle = value; }
    }

	public Test(string id, string sectionId,string sectionTitle)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this.id = id;
        this.sectionId = sectionId;
        this.sectionTitle = sectionTitle;
	}
}
