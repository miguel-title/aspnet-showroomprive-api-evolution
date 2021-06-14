using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class Extensions
    {
        public static HtmlString NoDataMessage(this HtmlHelper helper, string message = "Aucune donnée.", string icon = "mdi-package-variant")
        {
            return new HtmlString("<p class=\"info-message--huge\"><i class=\"mdi " + icon + "\"></i> " + message + "</p>");
        }
    }
}
