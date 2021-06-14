using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Text.RegularExpressions;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class Nl2brExtension
    {
        /* Nl2br */
        public static HtmlString Nl2br(this IHtmlHelper helper, string text)
        {
            if (string.IsNullOrEmpty(text))
                return new HtmlString(text);

            // Replace \r\n with \n, then \n with <br/>
            var html = helper.Encode(text);
            html = Regex.Replace(html, Environment.NewLine, "\n");
            html = Regex.Replace(html, "\n", "<br/>");

            return new HtmlString(html);
        }
    }
}
