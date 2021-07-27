using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DataTable dt = new DataTable();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int val, int val2)
        {
            return val + val2;
        }

        
        [WebMethod]
        public string TestDataTable()
        {
            dt.Columns.Add("TestColumn");
            dt.Columns.Add("TestColumn2");

            dt.Rows.Add("RandomVal", "RandomValForSecondColumn");

            return JsonConvert.SerializeObject(dt);
        }
    }
}
