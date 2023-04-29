using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disjoint_sets_Csharp;
public class DS_Arrays
{
    public int[] parent { get; private set; }
    public int[] rank { get; private set; }
    public DS_Arrays(int size)
    {
        parent = new int[size];
        rank = new int[size];

        for (int i = 0; i < size; i++)
        {
            parent[i] = -1;
            rank[i] = 0;
        }

    }
    public int Find(int x)
    {
        if (parent[x] == -1)
        {
            return x;
        }
        return parent[x] = Find(parent[x]);
    }
    public void Union(int x, int y)
    {
        int xset = Find(x);
        int yset = Find(y);
        if (xset == yset)
        {
            return;
        }

        if (rank[xset] < rank[yset])
        {
            parent[xset] = yset;
        }
        else if (rank[xset] > rank[yset])
        {
            parent[yset] = xset;
        }
        else
        {
            parent[xset] = yset;
            rank[yset]++;
        }
    }
}
