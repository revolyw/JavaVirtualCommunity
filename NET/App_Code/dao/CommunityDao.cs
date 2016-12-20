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
///CommunityDao 的摘要说明
/// </summary>
public class CommunityDao
{
    private static CommunityDao instance = new CommunityDao();
	private CommunityDao(){}
    public static CommunityDao getInstance(){
        return instance;
    }
    
    /// <summary>
    /// 插入一条帖子记录
    /// </summary>
    /// <param name="u_id"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public int insertThemes(string u_id,string title,string content)
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "insert into theme (title,content,u_id,hot_index) values('"+title+"','"+content+"','"+u_id+"',0)";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        int rs = obcm.ExecuteNonQuery();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    /// <summary>
    /// 获取所有帖子记录
    /// </summary>
    /// <returns></returns>
    public OdbcDataReader getThemes()
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select T.id,T.title,T.content,T.u_id,S.name,T.hot_index,T.time from theme as T,students as S where T.u_id = S.id order by T.time desc;";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    /// <summary>
    /// 获取一条帖子记录
    /// </summary>
    /// <param name="themeId"></param>
    /// <returns></returns>
    public List<OdbcDataReader> getOneTheme(string themeId)
    {
        List<OdbcDataReader> list = new List<OdbcDataReader>();

        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select T.id,T.title,T.content,T.u_id,S.name,T.hot_index,T.time from theme as T,students as S where T.u_id = S.id and T.id='"+themeId+"'";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();
        list.Add(rs);
        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        conn = DBConnection.getInstance();
        sql = "select C.id,C.theme_id,C.u_id,S.name,C.content,C.reply_num,C.time from comment as C,students as S where C.theme_id = '" + themeId + "' and C.u_id = S.id";
        obcm = new OdbcCommand(sql, conn);
        rs = obcm.ExecuteReader();
        list.Add(rs);
        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return list;
    }

    /// <summary>
    /// 获取一条评论所有的回复
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns></returns>
    public OdbcDataReader getReplys(string commentId) {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select R.*,S1.name as from_name,S2.name as to_name from reply as R,(select S.id,R.id as s1Rid,S.name from students as S,reply as R where S.id = R.from_uid and R.comment_id = '" + commentId + "') as S1,(select S.id,R.id as s2Rid,S.name from students as S,reply as R where S.id = R.to_uid and R.comment_id = '" + commentId + "') as S2 where comment_id ='" + commentId + "'and  S1.id = R.from_uid and S2.id = R.to_uid and R.id = S1.s1Rid and R.id = S2.s2Rid order by R.time desc;";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    /// <summary>
    /// 插入一条评论记录
    /// </summary>
    /// <param name="u_id"></param>
    /// <param name="theme_id"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public int insertOneComment(string u_id, string theme_id, string content)
    {
        int rs = 0;

        string[] arrSql = new string[2];
        //插入一条留言
        arrSql[0] = "insert into comment (theme_id,u_id,content,reply_num) values('" + theme_id + "','" + u_id + "','" + content + "',0)";
        //更新留言所属帖的信息
        arrSql[1] = "update theme set hot_index = hot_index + 1 where id = "+theme_id;

        if(TransactionTool.doTransaction(arrSql))
            rs = 1;
        
        return rs;
    }

    /// <summary>
    /// 插入一条回复记录
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="toId"></param>
    /// <param name="commentId"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public int insertOneReply(string uid, string toId, string commentId,string content)
    {
        int rs = 0;

        string[] arrSql = new string[2];
        //插入一条回复
        arrSql[0] = "insert into reply (comment_id,from_uid,to_uid,content) values('" + commentId + "','" + uid + "','" + toId + "','" + content + "')";
        //更新回复所属评论的信息
        arrSql[1] = "update comment set reply_num = reply_num + 1 where id = " + commentId;

        if (TransactionTool.doTransaction(arrSql))
            rs = 1;

        return rs;
    }
}
