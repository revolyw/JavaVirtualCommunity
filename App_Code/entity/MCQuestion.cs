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
///MCQuestion 的摘要说明
/// </summary>
public class MCQuestion
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
    private string answer;

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }
    private string optA;

    public string OptA
    {
        get { return optA; }
        set { optA = value; }
    }
    private string optB;

    public string OptB
    {
        get { return optB; }
        set { optB = value; }
    }
    private string optC;

    public string OptC
    {
        get { return optC; }
        set { optC = value; }
    }
    private string optD;

    public string OptD
    {
        get { return optD; }
        set { optD = value; }
    } 

	public MCQuestion(string id,string content,string answer,string optA,string optB,string optC,string optD)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this.id = id;
        this.content = content;
        this.answer = answer;
        this.optA = optA;
        this.optB = optB;
        this.optC = optC;
        this.optD = optD;
	}
}
