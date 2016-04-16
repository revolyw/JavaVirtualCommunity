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
using System.Collections.Generic;

/// <summary>
///UserDao 的摘要说明
/// </summary>
public class UserDao
{
    private static UserDao userDao = new UserDao();
	private UserDao(){}
    public static UserDao getInstance() {
        return userDao;
    }

    public OdbcDataReader checkTeacLn(string ln)
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select id,pw,name from teachers where ln = '" + ln + "';";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }


    /// <summary>
    /// 取得所有学生记录
    /// </summary>
    /// <returns></returns>
    public OdbcDataReader getStudents()
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from students";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    /// <summary>
    /// 学生注册
    /// </summary>
    /// <returns></returns>
    public int addStudent(string ln, string pw, string no, string role, string name, string sex, string cls, string birthday, string introduce, string phone, string email, string grp, string learn_level, string power, string is_used, string reg_date, string pass_date)
    {
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "insert into students (ln,pw,no,role,name,sex,cls,birthday,introduce,phone,email,grp,learn_level,power,is_used) values('"+ln+"','"+pw+"','"+no+"','"+role+"','"+name+"','"+sex+"','"+cls+"','"+birthday+"','"+introduce+"','"+phone+"','"+
email+"','"+grp+"','"+learn_level+"','"+power+"','"+is_used+"')";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        int rs = obcm.ExecuteNonQuery();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接
        return rs;
    }

    /// <summary>
    /// 批量注册账号
    /// </summary>
    /// <param name="stus">学生对象列表</param>
    /// <returns>注册结果true or false</returns>
    public bool batchAddStudent(List<Student> stus) {
        int stuNum = stus.Count;

        string[] arrSql =  new string[stuNum];
        for (int i = 0; i < stuNum; i++)
        {
            arrSql[i] = "insert into students (ln,pw,no,name) values ('"+stus[i].Ln+"','"+stus[i].Pw+"','"+stus[i].No+"','"+stus[i].Name+"')";
        }

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

    public OdbcDataReader getTeachers()
    {
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from teachers";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    public OdbcDataReader getPendingLns(){
        //取得数据库连接
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "select * from students where is_used = -1";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        OdbcDataReader rs = obcm.ExecuteReader();

        obcm.Dispose();//释放由 Component 占用的资源。
        conn.Close();//关闭数据库连接

        return rs;
    }

    public int approveLn(string flag,string id) {
        OdbcConnection conn = DBConnection.getInstance();
        string sql = "update students set is_used = '" + (flag.Equals("a_ok") ? "1" : "0") + "' where id = '" + id + "'";
        OdbcCommand obcm = new OdbcCommand(sql, conn);
        int rs = obcm.ExecuteNonQuery();

        obcm.Dispose();
        conn.Close();

        return rs;
    }
}
