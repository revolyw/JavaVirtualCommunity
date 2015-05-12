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
using System.Collections;

/// <summary>
///Service 的摘要说明
/// </summary>
public class Service
{
    private static Service instance = new Service();
	private Service(){}
    
    public static Service getInstance() {
        return instance;
    }

    /*
    public ArrayList getUsers() {
        UserDao userDao = UserDao.getInstance();
        ArrayList users = userDao.getUsers();
        return users;
    }

    public ArrayList getKnowledge() {
        KnowledgeDao klgDao = KnowledgeDao.getInstance();
        ArrayList klgs = klgDao.getKnowledge();
        return klgs;
    }
     */

}
