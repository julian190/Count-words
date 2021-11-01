using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_words
{
    internal class WordCounter
    {
        public WordCounter(string word, int count)
        {
            this.word = word;
            this.count = count;
        }

        public string word { get; set; }
        public int count { get; set; }
    }
}
