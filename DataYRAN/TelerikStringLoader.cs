using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core;

namespace DataYRAN
{
    class TelerikStringLoader : IStringResourceLoader
    {
        public string GetString(string key)
        {
            switch (key)
            {
                case "And":
                    return "И";
                case "ClearFilter":
                    return "Очистить фильт";
                case "Contains":
                    return "Содержит";
                case "DoesNotContain":
                    return "Не содержит";
                case "Filter":
                    return "Фильтр";
                case "Or":
                    return "Или";
                case "StartsWith":
                    return "Начинается с";
                case "DragToGroup":
                    return "Таблица данных";
                case "Apply":
                    return "Применить";
                default:
                    return null;
            }
        }
    }
}
