using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq.Expressions;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class ReadOnlyForExtension
    {
        public static HtmlString ReadOnlyFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return (HtmlString)html.EditorFor(expression, new
            {
                @readonly = "readonly"
            });
        }
    }
}
