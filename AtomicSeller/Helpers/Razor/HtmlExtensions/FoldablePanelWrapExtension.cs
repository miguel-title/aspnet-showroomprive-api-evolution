﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;

namespace AtomicSeller.Helpers.Razor.HtmlExtensions
{
    public static class FoldablePanelWrapExtension
    {
        private class FoldablePanelWrapContainer : IDisposable
        {
            private readonly TextWriter writer;

            public FoldablePanelWrapContainer(TextWriter writer)
            {
                this.writer = writer;
            }

            public void Dispose()
            {
                writer.Write(
                    "    </div>" +
                    "</div>"
                );
            }
        }

        public enum ContentType
        {
            Table,
            Text,
            Raw
        }

        public static IDisposable FoldablePanelWrap(this HtmlHelper htmlHelper, string panelTitle, ContentType type = ContentType.Raw, string classes = "", bool primary = true, string classeTitle = "")
        {
            classes += " panel" + (primary ? " panel-primary" : "");
            var contentWrapClass = type.ToString().ToLowerInvariant() + "-wrap";
            if (type == ContentType.Text)
                contentWrapClass += " panel-body";

            var writer = htmlHelper.ViewContext.Writer;
            writer.WriteLine(
                "<div class=\"" + classes + "\">" +
                "    <div class=\"panel-heading "+ classeTitle +"\">" + panelTitle + "</div>" +
                "    <div class=\"" + contentWrapClass + "\">"
            );
            return new FoldablePanelWrapContainer(writer);
        }
    }
}
