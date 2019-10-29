using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh09FrameworkFundamentals
{
    class Task2
    {
        private HashSet<string> set = new HashSet<string>();
        private List<string> list = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Task2"/> class.
        /// </summary>
        public Task2()
        {
        }

        /// <summary>
        /// This method is to uptain a new updated string.
        /// </summary>
        /// <param name="minor">Minors to continue.</param>
        /// <param name="firstString">Original string.</param>
        /// <returns>The updated string.</returns>

        public string TitleCase(string minor, string firstString)
        {
            bool firstToken = true;
            minor = this.Filter(minor);
            firstString = this.Filter(firstString);
            this.AddToSet(minor);
            this.AddToList(firstString);

            var result = new StringBuilder();
            var toLower = new StringBuilder();

            for (int i = 0; i < this.list.Count; ++i)
            {
                if (i == this.list.Count - 1)
                {
                    if (this.set.Contains(this.list[i]))
                    {
                        result.Append(this.list[i]);
                    }
                    else
                    {
                        result.Append(this.list[i].First().ToString().ToUpper());
                        result.Append(this.list[i].Substring(1));
                    }
                }
                else if (this.set.Contains(this.list[i]))
                {
                    if (firstToken)
                    {
                        result.Append(this.list[i].First().ToString().ToUpper());
                        result.Append(this.list[i].Substring(1));
                        result.Append(' ');
                    }
                    else
                    {
                        result.Append(this.list[i]);
                        result.Append(' ');
                    }
                }
                else
                {
                    result.Append(this.list[i].First().ToString().ToUpper());
                    result.Append(this.list[i].Substring(1));
                    result.Append(' ');
                }
            }

            return result.ToString();
        }

        private void AddToSet(string minor)
        {
            var t = new StringBuilder();

            for (int i = 0; i < minor.Length; ++i)
            {
                if (i == minor.Length - 1)
                {
                    t.Append(minor[i]);
                    this.set.Add(t.ToString());
                    t.Clear();
                }
                else if (minor[i] != ' ')
                {
                    t.Append(minor[i]);
                }
                else
                {
                    this.set.Add(t.ToString());
                    t.Clear();
                }
            }
        }

        private void AddToList(string firstString)
        {
            var t = new StringBuilder();
            for (int i = 0; i < firstString.Length; ++i)
            {
                if (i == firstString.Length - 1)
                {
                    t.Append(firstString[i]);
                    this.list.Add(t.ToString());
                    t.Clear();
                }
                else if (firstString[i] != ' ')
                {
                    t.Append(firstString[i]);
                }
                else
                {
                    this.list.Add(t.ToString());
                    t.Clear();
                }
            }
        }

        private string Filter(string minor)
        {
            var s = new StringBuilder();
            var temp = new StringBuilder();
            for (int i = 0; i < minor.Length; ++i)
            {
                if (i == minor.Length - 1)
                {
                    temp.Append(minor[i]);
                    s.Append(temp.ToString().ToLower());
                    temp.Clear();
                }
                else if (minor[i] == ' ')
                {
                    temp.Append(' ');
                    s.Append(temp.ToString().ToLower());
                    temp.Clear();
                }
                else
                {
                    temp.Append(minor[i]);
                }
            }

            return s.ToString();
        }
    }
}
