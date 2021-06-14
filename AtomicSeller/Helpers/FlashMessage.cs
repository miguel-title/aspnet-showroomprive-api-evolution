using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Linq;

namespace AtomicSeller.Helpers
{

    public class FlashMessage
    {
        private const string TempDataKey = "FlashMessages";

        public string Title { get; set; }
        public string Message { get; set; }
        public FlashMessageType Type { get; set; }
        public bool IsDebug { get; set; }

        public FlashMessage(string message, FlashMessageType type = FlashMessageType.Success, string title = null, bool debug = false)
        {
            Message = message;
            Title = title;
            Type = type;
            IsDebug = debug;
        }

        public string GetCSSClass()
        {
            return Type.ToString().ToLowerInvariant() + (IsDebug ? " debug" : "");
        }

        public static void Flash(ITempDataDictionary tempData, FlashMessage flashMessage)
        {
            if (!tempData.ContainsKey(TempDataKey))
                tempData[TempDataKey] = new List<FlashMessage>();

            ((List<FlashMessage>) tempData[TempDataKey]).Add(flashMessage);
        }

        private static bool HasMessages(ITempDataDictionary tempData)
        {
            return tempData.ContainsKey(TempDataKey) && ((List<FlashMessage>) tempData[TempDataKey]).Count > 0;
        }


        public static List<FlashMessage> GetMessages(ITempDataDictionary tempData)
        {
            var list = HasMessages(tempData)
                ? (List<FlashMessage>)tempData[TempDataKey]
                : new List<FlashMessage>();

            return list;
        }


    }

    public enum FlashMessageType
    {
        Success,
        Info,
        Error,
        Warning
    }
}
