using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Project.Algorithms
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test2()
        {
            int[,] graph = new int[,]
            {
                {0, 1, 7, 0, 0},
                {1, 0, 3, 3, 8},
                {7, 3, 0, 0, 12},
                {0, 3, 0, 0, 5},
                {0, 8, 12, 5, 0},
            };

            var nodeCount = Math.Sqrt(graph.Length);
            var dist = new List<int>();
            var tight = new List<bool>();
            var pred = new List<int>();

            for (int i = 0; i < nodeCount; i++)
            {
                dist.Add(int.MaxValue);
                tight.Add(false);
                pred.Add(int.MaxValue);
            }

            dist[0] = 0;

            while (tight.Exists(x => x == false))
            {
                // find closes node from dist
                var closestNodeIndex = -1;
                var closestNodeDist = int.MaxValue;

                for (int i = 0; i < nodeCount; i++)
                {
                    if (dist[i] < closestNodeDist && !tight[i])
                    {
                        closestNodeDist = dist[i];
                        closestNodeIndex = i;
                    }
                }

                tight[closestNodeIndex] = true;

                for (int i = 0; i < nodeCount; i++)
                {
                    if (!tight[i] && graph[closestNodeIndex,i] != 0 && dist[closestNodeIndex] + graph[closestNodeIndex,i] < dist[i])
                    {
                        dist[i] = dist[closestNodeIndex] + graph[closestNodeIndex, i];
                        pred[i] = closestNodeIndex;
                    }
                }
            }

            Assert.That(dist[4], Is.EqualTo(9));
            Assert.That(pred[4], Is.EqualTo(1));
        }

        [Test]
        public void Test1()
        {
            int[,] graph = new int[,]
            {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };
            var minSpanningTree = MinSpanningTree.CalculateMinimumSpanningTree(graph);

            Assert.That(minSpanningTree.Distance[8], Is.EqualTo(14));
        }

        [Test]
        public void ShouldShowNode1WithPredecessorNode0()
        {
            int[,] graph = new int[,]
            {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };

            var ss = "abc".Substring(1, 1);
            var minSpanningTree = MinSpanningTree.CalculateMinimumSpanningTree(graph);
            Assert.That(minSpanningTree.Predecessor[1], Is.EqualTo(0));
        }

        [Test]
        public void ShouldSHowNode4WithPredecessorNode5()
        {
            int[,] graph = new int[,]
            {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };
            var minSpanningTree = MinSpanningTree.CalculateMinimumSpanningTree(graph);
            Assert.That(minSpanningTree.Predecessor[4], Is.EqualTo(5));
        }
    }
}