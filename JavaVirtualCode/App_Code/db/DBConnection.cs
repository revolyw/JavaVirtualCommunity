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
///DBConnection 的摘要说明
/// </summary>
public class DBConnection
{
    //使用Connector/ODBC连接到MySQL
    private static OdbcConnection conn = new OdbcConnection("Dsn=mysql"); 
	private DBConnection()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static OdbcConnection getInstance(){
        if(conn.State == ConnectionState.Closed)//连接关闭则打开
            conn.Open();
        return conn;
    }
    public static void close(){
        conn.Close();
    }
}
