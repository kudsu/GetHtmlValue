using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GHV.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GHV.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Net.WebClient wc1 = new System.Net.WebClient();
            wc1.Encoding.GetEncoder();
            string result = wc1.DownloadString(new Uri("http://www.sanwen.com/sanwen/917929.html"));
            //string html = HtmlHelper.GetHtmlCode("http://www.sanwen.com/sanwen/917929.html");

            //string resV1 = StringHelper.SubStrOne(html, "<div class=\"row-left\">", "<div class=\"row-article-like\">");


            //Regex rg = new Regex("(?<=<div class=\"row-article\">).+?(?=</div>)", RegexOptions.Multiline | RegexOptions.Singleline);
            //string NameText = rg.Match(html).Value;

            //SqlParameter sql = new SqlParameter("a",SqlDbType.NVarChar);

        }
    }
}