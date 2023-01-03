using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsporte.HandlerServices.Services.Handlers
{
    public static class StringNormalizeHandler
    {
        /// <summary>
        /// В названиях могут быть лишние пробелы, табуляции, могу ошибочно проставляться заглавные буквы или пропущена заглавная буква 
        /// в начале имени, все имена собственные могут быть заполнены в кириллице или латинице, в случае кириллицы считать 
        /// одним и тем же буквы (е - ё) и (и - й). Необходимо учитывать эти исключение в поисках дублей.
        /// </summary>
        /// <param name="item">Валидируемая строка</param>
        /// <returns></returns>
        public static string NormalizeName(this string? validizeItem)
        {
            if (validizeItem is not null) {
                validizeItem = validizeItem.Trim();

                validizeItem = validizeItem.ToLowerInvariant();

                validizeItem = validizeItem.Replace("ё", "е");

                validizeItem = validizeItem.Replace("й", "и");

                validizeItem = char.ToUpper(validizeItem[0]) + validizeItem.Substring(1);

                return validizeItem;
            }
           
            return String.Empty;
        }
    }
}
