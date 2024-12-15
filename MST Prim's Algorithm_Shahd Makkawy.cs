using System;

class PrimMST
{
    static int V = 5; // Number of vertices in the graph

    // Function to find the vertex with minimum key value
    static int MinKey(int[] key, bool[] inMST)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
        {
            if (!inMST[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

    // Function to print the MST
    static void PrintMST(int[] parent, int[,] graph)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < V; i++)
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
    }

    // Function implementing Prim's Algorithm
    static void PrimAlgorithm(int[,] graph)
    {
        int[] parent = new int[V];   // Stores constructed MST
        int[] key = new int[V];      // Minimum key values
        bool[] inMST = new bool[V];  // Included vertices in MST

        for (int i = 0; i < V; i++) // Initialize all keys as infinite
            key[i] = int.MaxValue;

        key[0] = 0;     // Start from the first vertex
        parent[0] = -1; // Root node

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinKey(key, inMST); // Select vertex with minimum key value
            inMST[u] = true;

            // Update adjacent vertices' key values
            for (int v = 0; v < V; v++)
            {
                if (graph[u, v] != 0 && !inMST[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        PrintMST(parent, graph);
    }

    // Main method to execute the program
    public static void Main(string[] args)
    {
        int[,] graph = new int[,] {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        Console.WriteLine("Minimum Spanning Tree using Prim's Algorithm:");
        PrimAlgorithm(graph);
    }
}
