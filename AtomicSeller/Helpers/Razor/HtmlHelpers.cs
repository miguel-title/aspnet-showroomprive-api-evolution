using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomicSeller.Helpers.Razor
{
    public static class HtmlHelpers
    {
        public static HtmlString Concat(params HtmlString[] items)
        {
            var builder = new StringBuilder();
            foreach (var item in items.Where(i => i != null))
                builder.Append(item);
            return new HtmlString(builder.ToString());
        }

        public static int GetMaxLength(ViewDataDictionary<object> ViewData)
        {
            var additionalValues = ViewData.ModelMetadata.AdditionalValues;

            return additionalValues.ContainsKey("StringLength")
                ? (int)additionalValues["StringLength"]
                : -1;
        }

        public static HtmlString AnonymousObjectToHTMLString(object htmlAttributes)
        {
            var dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return DictionaryToHTMLString(dictionary);
        }

        public static HtmlString DictionaryToHTMLString(IDictionary<string, object> dictionary)
        {
            return new HtmlString(dictionary.Aggregate("", (current, item) => current + (item.Key + "=\"" + item.Value + "\" ")));
        }

        public static double ToJavascriptDate(DateTime? dateTime)
        {
            return dateTime.HasValue
                ? dateTime.Value.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds
                : -1;
        }
    }
}
