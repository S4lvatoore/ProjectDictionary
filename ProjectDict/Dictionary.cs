using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DictionaryMAin
{
    public class Dictionary
    {
        public string Name { get; set; }
        public string LanguageFrom { get; set; }
        public string LanguageTo { get; set; }
        public Dictionary<string, List<string>> Words { get; set; }

        public Dictionary()
        {
            Words = new Dictionary<string, List<string>>();
        }
    }
}

