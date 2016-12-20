using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public partial class evaluation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session["userName"] = null;
        }
        if (Session["userName"] != null)
        {
            s_u_name.Text = Session["userName"].ToString();
            display_lg_off.CssClass = "show-off";
            display_lg_on.CssClass = "show-on";
        }
        else
        {
            //***
            Session["u_id"] = null;
            Session["userName"] = null;
            Session.Abandon();
            //***
            display_lg_off.CssClass = "show-on";
            display_lg_on.CssClass = "show-off";
        }
    }
    protected void loginOff_Click(object sender, EventArgs e)
    {
        //***
        Session["u_id"] = null;
        Session["userName"] = null;
        Session.Abandon();
        //***
        //清除浏览器缓存
        //Response.Buffer = true;
        //Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        //Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        //Response.Expires = 0;
        //Response.CacheControl = "no-cache";
        //Response.Cache.SetNoStore(); 
        Response.Redirect("home.aspx");
    }

    [WebMethod]
    public static string getTests()
    {
        var rs = TestDao.getInstance().getTests();
        List<Test> tests = new List<Test>();
        Test test = null;
        //用户检测是否存在
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                string id = rs["id"].ToString();
                string sectionId = rs["sectionId"].ToString();
                string sectionTitle = rs["sectionTitle"].ToString();
                test = new Test(id, sectionId, sectionTitle);
                tests.Add(test);
            }
        }
        return new JavaScriptSerializer().Serialize(tests);
    }

    [WebMethod]
    public static string getOneTest(string sectionId)
    {
        var rs = TestDao.getInstance().getOneTest(sectionId);
        var xuanze = rs[0];
        var tiankong = rs[1];
        List<Object> oneTest = new List<Object>();
        List<MCQuestion> mcQuestions = new List<MCQuestion>();
        List<FIQuestion> fiQuestions = new List<FIQuestion>();
        MCQuestion mcQuestion = null;
        FIQuestion fiQuestion = null;
        ////选择题
        while (xuanze.Read())
        {
            if (xuanze.HasRows)
            {
                string id = xuanze["id"].ToString();
                string content = xuanze["content"].ToString();
                string answer = xuanze["answer"].ToString();
                string optA = xuanze["optA"].ToString();
                string optB = xuanze["optB"].ToString();
                string optC = xuanze["optC"].ToString();
                string optD = xuanze["optD"].ToString();
                mcQuestion = new MCQuestion(id, content, answer, optA, optB, optC, optD);
                mcQuestions.Add(mcQuestion);
            }
        }
        //填空题
        while (tiankong.Read())
        {
            if (tiankong.HasRows)
            {
                string id = tiankong["id"].ToString();
                string content = tiankong["content"].ToString();
                string answerNum = tiankong["answerNum"].ToString();
                string answer = tiankong["answer"].ToString();
                fiQuestion = new FIQuestion(id, content, answerNum, answer);
                fiQuestions.Add(fiQuestion);
            }
        }
        oneTest.Add(mcQuestions);
        oneTest.Add(fiQuestions);
        return new JavaScriptSerializer().Serialize(oneTest);
    }
}
