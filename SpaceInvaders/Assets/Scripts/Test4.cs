using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class Test4 : MonoBehaviour
    {
        private void Start()
        {
            int[] a = new int[] {0, 1, 2, 3, 3};
            int[] b = new int[] {1, 2, 0, 2, 0};
            Debug.LogError(solution(4, a, b));
        }

        public bool solution(int N, int[] A, int[] B)
        {
            List<int> tempA = A.ToList();
            List<int> tempB = B.ToList();

            tempA.Sort();
            tempB.Sort();
            
            Graph g = new Graph(N);
            for (int i = 0; i < A.Length; i++)
            {
                g.addEdge(tempA[i] - 1, tempB[i] - 1);
            }

            return g.isReachable(1, N - 1);
            // write your code in C# 6.0 with .NET 4.5 (Mono)
        }

        public class Graph
        {
            private int V; // No. of vertices
            private LinkedList<int>[] adj; //Adjacency List

            // Constructor
            public Graph(int v)
            {
                V = v;
                adj = new LinkedList<int>[v];
                for (int i = 0; i < v; ++i)
                    adj[i] = new LinkedList<int>();
            }

            // Function to add an edge into the graph
            public void addEdge(int v, int w)
            {
                adj[v].AddLast(w);
            }

            // prints BFS traversal from a given source s
            public bool isReachable(int s, int d)
            {
                // LinkedList<int> temp = new LinkedList<int>();

                // Mark all the vertices as not visited(By default set
                // as false)
                bool[] visited = new bool[V];

                // Create a queue for BFS
                LinkedList<int> queue = new LinkedList<int>();

                // Mark the current node as visited and enqueue it
                visited[s] = true;
                queue.AddLast(s);

                // 'i' will be used to get all adjacent vertices of a vertex
                IEnumerator i;
                while (queue.Count != 0)
                {

                    // Dequeue a vertex from queue and print it
                    s = queue.First.Value;
                    queue.RemoveFirst();
                    int n;
                    i = adj[s].GetEnumerator();

                    // Get all adjacent vertices of the dequeued vertex s
                    // If a adjacent has not been visited, then mark it
                    // visited and enqueue it
                    while (i.MoveNext())
                    {
                        n = (int) i.Current;

                        // If this adjacent node is the destination node,
                        // then return true
                        if (n == d)
                            return true;

                        // Else, continue to do BFS
                        if (!visited[n])
                        {
                            visited[n] = true;
                            queue.AddLast(n);
                        }
                    }
                }

                // If BFS is complete without visited d
                return false;
            }
        }
    }
}