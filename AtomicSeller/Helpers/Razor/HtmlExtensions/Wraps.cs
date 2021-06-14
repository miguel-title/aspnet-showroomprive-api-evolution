using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Linq.Expressions;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class Wraps
    {
        /* FieldWrap */
        public enum FieldWrapType
        {
            /**
             * Default mode (uses EditorFor)
             */
            Default,
            /**
             * TextAreaFor
             */
            TextArea,
            /**
             * DisplayFor
             */
            Display,
            /**
             * DisplayFor + HiddenFor
             */
            DisplayWithHidden
        }

        private static string getFieldWrapStart(HtmlString label)
        {
            return
                "<div class=\"form-group\">" +
                "    " + label +
                "    <div class=\"" + HtmlClasses.Control + "\">";
        }

        private static string getFieldWrapEnd()
        {
            return
                "    </div>" +
                "</div>";
        }

        public static HtmlString getEditor<TModel, TValue>(HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, FieldWrapType type)
        {
            var attrs = new
            {
                @class = HtmlClasses.Input
            };

            switch (type)
            {
                case FieldWrapType.TextArea:
                    return (HtmlString)html.TextAreaFor(expression, attrs);
                case FieldWrapType.Display:
                    return (HtmlString)html.DisplayFor(expression);
                case FieldWrapType.DisplayWithHidden:
                    return HtmlHelpers.Concat(
                        (HtmlString)html.DisplayFor(expression),
                        (HtmlString)html.HiddenFor(expression)
                    );
                case FieldWrapType.Default:
                default:
                    return (HtmlString)html.EditorFor(expression, attrs);
            }
        }

        /**
         * Standard FieldWrap (@Html.FieldWrap)
         */
        public static HtmlString FieldWrap<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, FieldWrapType type = FieldWrapType.Default)
        {
            var label = html.LabelFor(expression, new
            {
                @class = HtmlClasses.Label
            });
            var editor = getEditor(html, expression, type);

            return new HtmlString(
                getFieldWrapStart((HtmlString)label) +
                editor +
                getFieldWrapEnd()
            );
        }

        /* Disposable FieldWrap (using FieldWrapWrap) */
        public class FieldWrapWrapContainer : IDisposable
        {
            private readonly TextWriter writer;

            public FieldWrapWrapContainer(TextWriter writer)
            {
                this.writer = writer;
            }

            public void Dispose()
            {
                writer.Write(getFieldWrapEnd());
            }
        }

        public static IDisposable FieldWrapWrap(this HtmlHelper html, string labelText)
        {
            var writer = html.ViewContext.Writer;

            var label = html.Label("", labelText, new
            {
                @class = HtmlClasses.Label
            });
            writer.WriteLine(getFieldWrapStart((HtmlString)label));

            return new FieldWrapWrapContainer(writer);
        }
    }
}
