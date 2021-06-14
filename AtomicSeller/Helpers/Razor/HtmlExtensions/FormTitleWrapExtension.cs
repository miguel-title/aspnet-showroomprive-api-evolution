using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class FormTitleWrapExtension
    {
        private const HtmlConsts.DOM.H defaultLevel = HtmlConsts.DOM.H.H3;

        public static HtmlString FormTitleWrap(this HtmlHelper htmlHelper, string text, HtmlConsts.DOM.H level = defaultLevel)
        {
            var tag = level.ToString().ToLowerInvariant();

            return new HtmlString(
                "<div class=\"row\">" + 
                "    <div class=\"" + HtmlClasses.ControlOffset + "\">" +
                "        <" + tag + ">" + text + "</" + tag + ">" +
                "    </div>" +
                "</div>"
            );
        }
    }
}
