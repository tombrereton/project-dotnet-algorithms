using System;

namespace Tests
{
    internal class MinSpanningTree
    {
        public MinSpanningTree(int[] distance, int[] predecessor)
        {
            Distance = distance;
            Predecessor = predecessor;
        }

        public int[] Distance { get; set; }
        public int[] Predecessor { get; set; }
        public static MinSpanningTree CalculateMinimumSpanningTree(int[,] graph)
        {
            /**
             * Need:
             * dist[]
             * tight[]
             * pred[]
             *
             *
             * First set dist[A] = 0 and dist[i] = infinity for all i not A
             * While not all nodes are tight
             * Find the loose node i for which dist[i] is least
             * make node i tight
             * for each loose node j
             * if( dist[i] + edge[i,j] < dist[j])
             *   dist[j] = dist[i] + edge[i,j]
             *   pred[j] = i
             *
             */

            var numberOfNodes = (int)Math.Sqrt(graph.Length);
            var distance = new int[numberOfNodes];
            var predecessor = new int[numberOfNodes];
            var tightNodes = new bool[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                distance[i] = int.MaxValue;
                tightNodes[i] = false;
            }

            distance[0] = 0;

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                int closestNode = GetClosestNode(distance, tightNodes);
                tightNodes[closestNode] = true;

                for (int currentNode = 0; currentNode < numberOfNodes; currentNode++)
                {
                    if (IsValidNode(tightNodes, currentNode, graph, closestNode, distance) &&
                        IsPathThroughClosestNodeShorterToCurrentNode(distance, closestNode, graph, currentNode))
                    {
                        distance[currentNode] = distance[closestNode] + graph[closestNode, currentNode];
                        predecessor[currentNode] = closestNode;
                    }
                }
            }

            return new MinSpanningTree(distance, predecessor);
        }
        private static bool IsPathThroughClosestNodeShorterToCurrentNode(int[] dist, int closestNode, int[,] graph, int currentNode)
        {
            return dist[closestNode] + graph[closestNode, currentNode] < dist[currentNode];
        }

        private static bool IsValidNode(bool[] sptSet, int currentNode, int[,] graph, int closestNode, int[] dist)
        {
            return !sptSet[currentNode] && graph[closestNode, currentNode] != 0 && dist[closestNode] != int.MaxValue;
        }

        private static int GetClosestNode(int[] dist, bool[] sptSet)
        {
            var minDistance = int.MaxValue;
            var minIndex = -1;

            for (int i = 0; i < dist.Length; i++)
            {
                if (sptSet[i] == false && dist[i] < minDistance)
                {
                    minDistance = dist[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}