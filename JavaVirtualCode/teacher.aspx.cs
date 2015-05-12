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
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;


public partial class teacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Session["isTeacher"] = null;
        }
        if (Session["isTeacher"] == null)//未登陆转到登陆界面
        {
            Response.Redirect("~/teacLogin.aspx");
        }
    }

    [WebMethod]
    public static string insertStuByBatch(string json)
    {
        //自定义反序列化（json字符串转list<T>对象）
        List<Student> stus = JsonConvert.DeserializeObject<List<Student>>(json, new StudentConverter());

        UserDao instance = UserDao.getInstance();
        bool rs = instance.batchAddStudent(stus);

        return new JavaScriptSerializer().Serialize(rs.ToString());
    }

    /// <summary>
    /// 获取未审批的账号
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public static string getPendingLns() {
        UserDao instance = UserDao.getInstance();
        var rs = instance.getPendingLns();
        List<Student> stus = new List<Student>();
        Student stu = null;
        while (rs.Read()) {
            if (rs.HasRows) {
                string id = rs["id"].ToString();
                string ln = rs["ln"].ToString();
                string no = rs["no"].ToString();
                string cls = rs["cls"].ToString();
                string name = rs["name"].ToString();
                string reg_date = rs["reg_date"].ToString();
                stu = new Student();
                stu.setPendingLn(id,ln,no,cls,name,reg_date);
                stus.Add(stu);
            }
        }
        return new JavaScriptSerializer().Serialize(stus);
    }

    /// <summary>
    /// 审批账号
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public static string approveLn(string flag,string id)
    {
        UserDao instance = UserDao.getInstance();
        int rs = instance.approveLn(flag, id);
        return new JavaScriptSerializer().Serialize(rs.ToString());
    }

    /// <summary>
    /// 获取所有留言记录
    /// </summary>
    /// <param name="teachId"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [WebMethod]
    public static string loadMessages(string pageSize)
    {
        string teachId = HttpContext.Current.Session["u_id"].ToString();
        var rs = MessageDao.getInstance().getMessages(teachId,"-1");

        List<Object> list = new List<object>();
        List<Object> listX = null;
        List<Object> listY = null;
        Message message = null;
        var i = 0;

        while (rs.Read())
        {
            if (rs.HasRows)
            {

                if (i % int.Parse(pageSize) == 0)
                    listX = new List<object>();

                string id = rs["id"].ToString();
                string stu_id = rs["stu_id"].ToString();
                string teac_id = rs["teac_id"].ToString();
                string type = rs["type"].ToString();
                string content = rs["content"].ToString();
                string time = rs["uploadTime"].ToString();

                message = new Message(id, stu_id, teac_id,type, content, time);
                string s_name = rs["s_name"].ToString();
                string t_name = rs["t_name"].ToString();

                listY = new List<object>();
                listY.Add(s_name);
                listY.Add(message);
                listY.Add(t_name);

                listX.Add(listY);
                if (++i % int.Parse(pageSize) == 0)
                    list.Add(listX);
            }
        }
        if (listX != null && listX.Count != int.Parse(pageSize))//X不等于pageSize则说明最后一页未添加进list，若为pageSize说明最后一页恰好填满
            list.Add(listX);

        return new JavaScriptSerializer().Serialize(list);
    }

    [WebMethod]
    public static string submitReplyMsg(string to_id, string content)
    {
        string teac_id = HttpContext.Current.Session["u_id"].ToString();
        string type = "to_stu";
        int rs = MessageDao.getInstance().insertMessage(to_id, teac_id, type, content);
        return new JavaScriptSerializer().Serialize(rs.ToString());
    }
}

