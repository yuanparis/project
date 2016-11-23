using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new Route("UrlRewrite.html", new ReWriteUrl("~/UrlRewrite.aspx")));//地址重写
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public class ReWriteUrl : IRouteHandler
        {
            public string UrlRote
            {
                get;
                private set;
            }
            public ReWriteUrl(string sUrlRote)
            {
                UrlRote = sUrlRote;
            }
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return BuildManager.CreateInstanceFromVirtualPath(UrlRote, typeof(IHttpHandler)) as IHttpHandler;
            }
        }
    }
}