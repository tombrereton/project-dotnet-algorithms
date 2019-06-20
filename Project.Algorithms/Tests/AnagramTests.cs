using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Execution;

namespace Project.Algorithms
{
    public class AnagramTests
    {
        [Test]
        public void ShouldAnagramCounterShouldReturn4()
        {
            string word = "abba";
            var count = CountAnagrams(word);
            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldAnagramCounterShouldReturn10()
        {
            string word = "kkkk";
            var count = CountAnagrams(word);
            Assert.That(count, Is.EqualTo(10));
        }

        private int CountAnagrams(string word)
        {
            // for char i loop
            // for char j loop
            // get substring(i,j) and sort alphabetically
            // insert in hashmap
            // if exists remove from hashmap and increase count
            var map = new Dictionary<string, int>();
            var len = word.Length;
            var count = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 1; j + i <= len; j++)
                {
                    var ss = word.Substring(i, j);
                    ss = string.Concat(ss.OrderBy(c => c));

                    if (map.ContainsKey(ss))
                    {
                        map[ss] = map[ss] + 1;
                        count = count + 1;
                    }
                    else
                    {

                        map.Add(ss, 1);
                    }
                }
            }

            return count;
        }
    }
}