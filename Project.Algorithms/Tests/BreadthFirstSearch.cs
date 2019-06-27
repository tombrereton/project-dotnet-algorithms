using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project.Algorithms
{

    //An Iterative Java program to do DFS traversal from 
    //a given source vertex. DFS(int s) traverses vertices 
    //reachable from s. 

    // This class represents a directed graph using adjacency 
    // list representation 
    public class BreadthFirstSearchGraph
    {
        static int V; //Number of Vertices 

        public List<int>[] Adj; // adjacency lists 

        //Constructor 
        public BreadthFirstSearchGraph(int v)
        {
            V = v;
            Adj = new List<int>[V];

            for (int i = 0; i < Adj.Length; i++)
            {
                Adj[i] = new List<int>();
            }

        }

        //To add an edge to graph 
        public void AddEdge(int v, int w)
        {
            Adj[v].Add(w); // Add w to v’s list. 
        }

        // prints all not yet visited vertices reachable from s 
        public void DFS(int s)
        {
            // Initially mark all vertices as not visited 
            var visited = new List<bool>(V);
            for (int i = 0; i < V; i++)
            {
                visited.Add(false);
            }

            // Create a stack for DFS 
            var queue = new Queue<int>();

            // Push the current source node 
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Pop a vertex from stack and print it 
                s = queue.Dequeue();

                // Stack may contain same vertex twice. So 
                // we need to print the popped item only 
                // if it is not visited. 
                if (visited[s] == false)
                {
                    Console.WriteLine(s + " ");
                    visited[s] = true;
                }

                // Get all adjacent vertices of the popped vertex s 
                // If a adjacent has not been visited, then puah it 
                // to the stack. 
                foreach (var vertextAdjacentToS in Adj[s])
                {
                    if (!visited[vertextAdjacentToS])
                    {
                        queue.Enqueue(vertextAdjacentToS);
                    }
                }
            }
        }
    }





    public class BreadFirstSearchTests
    {
        // Driver program to test methods of graph class 
        [Test]
        public void BreadFirstSearchTest()
        {
            // Total 5 vertices in graph 
            var g = new DepthFirstSearchGraph(5);

            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 1);
            g.AddEdge(0, 3);
            g.AddEdge(1, 4);

            Console.WriteLine("Following is the Depth First Traversal");
            g.DFS(0);
        }
    }
}
