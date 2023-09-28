using System.Collections.Generic;
public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {

        //1 Adjacency List
        Dictionary<int, List<double []>> adjacencyList = new Dictionary<int, List<double[]>>();
        int counter = 0;
        foreach(var pair in edges) {
            if(!adjacencyList.ContainsKey(pair[1])){
                List<double[]> listNodes = new List<double[]>();
                listNodes.Add(new double []  {pair[1], succProb[counter]});
                adjacencyList.Add(pair[0],listNodes);
            }else{
                 adjacencyList[pair[0]].Add(new double []  {pair[1], succProb[counter]});
            }
           
            counter++;
        }

        PriorityQueue<int, double> pr = new PriorityQueue<int, double>();
        List<int []> path = new List<int[]>();

        Dictionary<int, double> computedProb = new Dictionary<int, double>();
        computedProb.Add(start_node,1);

        pr.Enqueue(start_node,1);
        while(pr.Count > 0) {
            var current_node = pr.Dequeue();
            var children = adjacencyList[current_node];
            foreach(var child in children) {
                if(computedProb.ContainsKey((int)child[0])) {
                    
                } else {
                    computedProb.Add([(int)child[0]], child[1] * computedProb[current_node]); 
                }
                 pr.Enqueue(current_node, )

                 //node       other node, weight
            // }
        }

        
       


        //add start node to queue
        // while queue is not empty{
        //     currentNode = largest thing in the priority queue
        //     go throough edges and keep track of probability in our queue
        //     check if node is the end node
        // }
        
        return 0.0;
    }
}