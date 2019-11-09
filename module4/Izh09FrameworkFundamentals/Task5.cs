using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh09FrameworkFundamentals
{
    class Task5
    {
        private List<string> list = new List<string>();

        /// <summary>
        /// This method is reversed words.
        /// </summary>
        /// <param name="word">Input the string with spaces.</param>
        /// <returns>Updated string.</returns>
        public string ReverseWords(string word)
        {
            var result = new StringBuilder();

            this.AddString(word);

            for (int i = this.list.Count - 1; i >= 0; --i)
            {
                result.Append(this.list[i]);

                if (i != 0)
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }

        private void AddString(string word)
        {
            var temp = new StringBuilder();

            for (int i = 0; i < word.Length; ++i)
            {
                if (i == word.Length - 1)
                {
                    temp.Append(word[i]);
                    this.list.Add(temp.ToString());
                    temp.Clear();
                }
                else if (word[i] != ' ')
                {
                    temp.Append(word[i]);
                }
                else
                {
                    this.list.Add(temp.ToString());
                    temp.Clear();
                }
            }
        }
    }
}
