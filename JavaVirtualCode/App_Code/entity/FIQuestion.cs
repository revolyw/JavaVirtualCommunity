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
///FIQuestion 的摘要说明
/// </summary>
public class FIQuestion
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
    private string answerNum;

    public string AnswerNum
    {
        get { return answerNum; }
        set { answerNum = value; }
    }
    private string answer;

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }

	public FIQuestion(string id,string content,string answerNum,string answer)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        this.id = id;
        this.content = content;
        this.answerNum = answerNum;
        this.answer = answer;
	}
}
