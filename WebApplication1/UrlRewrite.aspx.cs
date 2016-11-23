using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UrlRewrite : System.Web.UI.Page
    {
        protected string StrUrl{get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Convert.ToString(Request["id"]);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            int i = 0;
            int.TryParse(id, out i);
            if (i == 0)
            {
                return;
            }

            //
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "id1");
            dic.Add(2, "id2");
            dic.Add(3, "id3");

            StrUrl = dic[i];
        }
    }
}