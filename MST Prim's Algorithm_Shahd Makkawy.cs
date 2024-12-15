using System;

class PrimMST
{
    static int V = 5; 
    
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

    static void PrintMST(int[] parent, int[,] graph)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < V; i++)
        { Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}"); }
    }

    static void PrimAlgorithm(int[,] graph)
    {
        int[] parent = new int[V];   // stores constructed MST
        int[] key = new int[V];      // minimum key values
        bool[] inMST = new bool[V];  // included vertices in MST

        for (int i = 0; i < V; i++)
        { key[i] = int.MaxValue; }

        key[0] = 0;     
        parent[0] = -1; 

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinKey(key, inMST); 
            inMST[u] = true;
            
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
