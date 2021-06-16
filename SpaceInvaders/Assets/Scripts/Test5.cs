using System;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class Test5 : MonoBehaviour
    {
        private void Start()
        {
            int V = 4;
            int[,] edges =
            {
                {0, 1}, {1, 2},
                {3, 0}, {3, 2},
                {2, 0}
            };
            int u = 1, v = 3;

            if (GFG.existPath(V, edges, u, v))
                Debug.LogError("True");
            else
                Debug.LogError("Fales");
        }

        class GFG
        {

            static readonly int X = 6;
            static readonly int Z = 2;

// Function to find if there is a
// path between two vertices in a
// directed graph
            public static bool existPath(int V, int[,] edges,
                int u, int v)
            {

                // mat matrix
                bool[,] mat = new bool[V, V];

                // set mat[i,j]=true if there is
                // edge between i to j
                for (int i = 0; i < X; i++)
                    mat[edges[i, 0], edges[i, 1]] = true;

                // Check for all intermediate vertex
                for (int k = 0; k < V; k++)
                {
                    for (int i = 0; i < V; i++)
                    {
                        for (int j = 0; j < V; j++)
                        {
                            mat[i, j] = mat[i, j] ||
                                        mat[i, k] &&
                                        mat[k, j];
                        }
                    }
                }

                // If vertex is invalid
                if (u >= V || v >= V)
                {
                    return false;
                }

                // If there is a path
                if (mat[u, v])
                    return true;
                return false;
            }

        }
    }
}