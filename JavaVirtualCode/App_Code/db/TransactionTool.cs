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

/// <summary>
///TransactionTool 的摘要说明
/// </summary>
public class TransactionTool
{
	public TransactionTool(){}
    public static bool doTransaction(string[] arrSql)
    {
        OdbcConnection conn = null;
        OdbcTransaction tran = null; // 用于SQL的事务处理
        OdbcCommand obcm = null;
        try
        {
            conn = DBConnection.getInstance();
            tran = conn.BeginTransaction();
            obcm = conn.CreateCommand();
            obcm.Transaction = tran;

            foreach (string sql in arrSql)
            {
                obcm.CommandText = sql;
                obcm.CommandType = CommandType.Text;
                obcm.ExecuteNonQuery();
            }
            tran.Commit();
            return true;
        }
        catch (Exception e)
        {
            if (tran != null)
                tran.Rollback();
            return false;
        }
        finally
        {
            obcm.Dispose();//释放由 Component 占用的资源。
            conn.Close();//关闭数据库连接
        }
        return false;
    }
}
