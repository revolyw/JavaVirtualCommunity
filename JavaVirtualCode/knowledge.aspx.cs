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

public partial class knowledge : System.Web.UI.Page
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
        Response.Redirect("home.aspx");
    }

    [WebMethod]
    public static string getKnowledgeTree()
    {
        var rs = KnowledgeDao.getInstance().getKnowledgeTree();
        List<Knowledge> knowledges = new List<Knowledge>();
        Knowledge knowledge = null;
        //用户检测是否存在
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                string id = rs["id"].ToString();
                string level = rs["level"].ToString();
                string super_level = "super_level";
                if (rs["super_level"] == System.DBNull.Value)
                    super_level = null;
                else
                    super_level = rs["super_level"].ToString();
                string sub_num = rs["sub_num"].ToString();
                string number = rs["number"].ToString();
                string description = rs["description"].ToString();
                string content = rs["content"].ToString();
                knowledge = new Knowledge(id, level, super_level, sub_num, number, description,content);
                knowledges.Add(knowledge);
            }
        }
        return new JavaScriptSerializer().Serialize(knowledges);
    }

    [WebMethod]
    public static string getKnowledgeContent(string contentId)
    {
        var rs = KnowledgeDao.getInstance().getKnowledgeContent(contentId);
        List<Knowledge_Content> knowledge_Contents = new List<Knowledge_Content>();
        Knowledge_Content knowledge_content = null;
        //用户检测是否存在
        while (rs.Read())
        {
            if (rs.HasRows)
            {
                string id = rs["id"].ToString();
                string content = rs["content"].ToString();
                knowledge_content = new Knowledge_Content(id, content);
                knowledge_Contents.Add(knowledge_content);
            }
        }
        return new JavaScriptSerializer().Serialize(knowledge_Contents);
    }
}
