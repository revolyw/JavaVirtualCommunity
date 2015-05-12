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
///MessageDao 的摘要说明
/// </summary>
public class MessageDao
{
    private static MessageDao instance = new MessageDao();

    private MessageDao() { }

    public static MessageDao getInstance()
    {
        return instance;
    }

    public int insertMessage(string u_id, string teacherId, string type, string message)
    {
        int rs = 0;

        //插入一条留言
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "insert into message (stu_id,teac_id,type,content) values('" + u_id + "','" + teacherId + "','" + type + "','" + message + "')";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        rs = obcm.ExecuteNonQuery();
        obcm.Dispose();
        conn.Close();

        return rs;
    }

    public OdbcDataReader getMessages(string teac_id,string stu_id)
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select M.id,M.stu_id,S.name as s_name,T.name as t_name,M.teac_id,M.type,M.content,M.uploadTime from message as M,students as S,teachers as T where "+
            (stu_id.Equals("-1") ? "" : "M.stu_id = '" + stu_id + "' and") +
            " M.stu_id = S.id and M.teac_id = T.id and M.teac_id = " + teac_id + " order by M.uploadTime desc;";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }
}
