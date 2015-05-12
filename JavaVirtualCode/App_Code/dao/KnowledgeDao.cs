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

/// <summary>
///KnowledgeDap 的摘要说明
/// </summary>
public class KnowledgeDao
{
    private static KnowledgeDao instance = new KnowledgeDao();
    private KnowledgeDao(){}

    public static KnowledgeDao getInstance()
    {
        return instance;
    }

    public OdbcDataReader getKnowledgeTree() {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from knowledge";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    public OdbcDataReader getKnowledgeContent(string contentId)
    {

        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from knowledge_content where id = "+contentId;
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }
}
