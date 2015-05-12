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
///Video 的摘要说明
/// </summary>
public class VideoDao
{
    private static VideoDao instance = new VideoDao();
	private VideoDao()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static VideoDao getInstance()
    {
        return instance;
    }

    public OdbcDataReader getVideos()
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from video";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }
}
