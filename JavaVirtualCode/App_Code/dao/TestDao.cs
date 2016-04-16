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
using System.Data.Odbc;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///TestDao 的摘要说明
/// </summary>
public class TestDao
{
    private static TestDao instance = new TestDao();

    private TestDao() { }

    public static TestDao getInstance() {
        return instance;
    }

    public OdbcDataReader getTests()
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from questioncatalogue";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    /// <summary>
    /// 返回一章试卷
    /// </summary>
    /// <param name="sectionId">章节号</param>
    /// <returns>一个list，包含一个选择题对象和一个填空题对象</returns>
    public List<OdbcDataReader> getOneTest(string sectionId) {
        List<OdbcDataReader> list = new List<OdbcDataReader>();

        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from mcquestion where id in ( select qid from relationshipforquestion where qtype='xuanze' and sectionId = '"+ sectionId +"')";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();
        list.Add(rs);
        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        conn = DBConnection.getInstance();
        sql = "select * from fiquestion where id in ( select qid from relationshipforquestion where qtype='tiankong' and sectionId = '" + sectionId + "')";
        obcm = new OdbcCommand(sql, conn);
        rs = obcm.ExecuteReader();
        list.Add(rs);
        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return list;
    }
}
