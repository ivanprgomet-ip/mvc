using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.helpers
{
    public static class MyHtmlHelper
    {
        public static IHtmlString UpperCase(this HtmlHelper helper, string input)
        {
            return helper.Raw(input.ToString().ToUpper());
        }
    }
}