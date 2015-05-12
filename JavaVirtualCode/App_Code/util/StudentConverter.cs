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

/// <summary>
///StudentConverter 的摘要说明
/// </summary>
public class StudentConverter:Newtonsoft.Json.Converters.CustomCreationConverter<Student>
{
        //重写abstract class CustomCreationConverter<T>的Create方法  
        public override Student Create(Type objectType)  
        {  
            return new Student();  
        }  
}
