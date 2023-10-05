using System.Collections.Generic;

public class Solution
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
    {

        //1 Adjacency List
        Dictionary<int, List<double[]>> adjacencyList = new Dictionary<int, List<double[]>>();
        int counter = 0;
        foreach (var pair in edges)
        {
            if (!adjacencyList.ContainsKey(pair[0]))
            {
                //Console.WriteLine("new entry " + pair[0]);
                List<double[]> listNodes = new List<double[]>();
                listNodes.Add(new double[] { pair[1], succProb[counter] });
                adjacencyList.Add(pair[0], listNodes);
            }
            else
            {
                //Console.WriteLine("update " + pair[0]);
                adjacencyList[pair[0]].Add(new double[] { pair[1], succProb[counter] });
            }

            if (!adjacencyList.ContainsKey(pair[1]))
            {
                //Console.WriteLine("new entry " + pair[0]);
                List<double[]> listNodes = new List<double[]>();
                listNodes.Add(new double[] { pair[0], succProb[counter] });
                adjacencyList.Add(pair[1], listNodes);
            }

            counter++;
        }

        PriorityQueue<int, double> pr = new PriorityQueue<int, double>(); //node, weight -- what we are manipulating to find our answer
        List<int[]> path = new List<int[]>(); //path for each node (?)

        Dictionary<int, double> computedProb = new Dictionary<int, double>(); //computing new probability based on node -- this is where our answer will be
        computedProb.Add(start_node, -1);

        pr.Enqueue(start_node, -1);
        while (pr.Count > 0)
        {
            var current_node = pr.Dequeue();
            var curr_prop = computedProb[current_node];
            if (current_node == end_node) {
                return -computedProb[current_node];
            }

            var children = adjacencyList[current_node];
            foreach (var child in children)
            {
                double new_prob = child[1] * curr_prop;
                if (computedProb.ContainsKey((int)child[0]) && new_prob > computedProb[current_node]) 
                {
                    computedProb[(int)child[0]] = new_prob;
                }
                else
                {
                    computedProb.Add((int)child[0], new_prob);
                    pr.Enqueue((int)child[0], new_prob);
                }
                
                //we have now added/updated everything to our priority queue
            }

        }
        return 0.0;
    }
}