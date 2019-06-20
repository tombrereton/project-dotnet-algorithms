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
        public void NChoose2ShouldReturn6()
        {
            int n = 4;
            var result = NChooseTwo(n);
            Assert.That(result, Is.EqualTo(6));
        }


        [TestCase("kkkk", 10)]
        [TestCase("abba", 4)]
        [TestCase("abcd", 0)]
        [TestCase("ifailuhkqq", 3)]
        [TestCase("cdcd", 5)]
        public void ShouldAnagramCounterShouldReturn10(string word, int expectedCount)
        {
            var count = CountAnagrams(word);
            Assert.That(count, Is.EqualTo(expectedCount));
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
            for (int i = 0; i < len; i++)
            {
                for (int j = 1; j + i <= len; j++)
                {
                    var ss = word.Substring(i, j);
                    ss = string.Concat(ss.OrderBy(c => c));

                    if (map.ContainsKey(ss))
                    {
                        map[ss] = map[ss] + 1;
                    }
                    else
                    {

                        map.Add(ss, 1);
                    }
                }
            }

            var matches = 0;
            foreach (var ssCount in map.Values)
            {
                matches += NChooseTwo(ssCount);
            }

            return matches;
        }

        private int Factorial(int i)
        {
            if (i <= 1)
            {
                return 1;
            }

            return i * Factorial(i - 1);
        }
        private int NChooseTwo(int o)
        {
            return Factorial(o) / (2 * Factorial(o - 2));
        }
    }
}