using System.Collections;

namespace problem
{
    public class Node
    {
        public int[] position {get;set;}
        public List<int[]> track {get;set;};

        public Node(int[] startingPosition) {
            position = startingPosition;
            track.Add(startingPosition);
        }
    }
    public class Problem
    {
        int[][] grid = {
            {0,0,0,0,0,0,0},
            {0,1,0,0,0,0,0},
            {0,1,0,0,1,0,0},
            {0,1,0,0,1,0,0},
            {0,0,0,0,1,0,0},
            {0,0,0,0,1,0,0},
        };
        int[] startingPos = [0, 0];
        int[] finalPos = [7, 5]


        int[][] posibleSteps = {
            {1,1},
            {1,0},
            {1,-1},
            {0,1},
            {0,-1},
            {-1,1},
            {-1,0},
            {-1,-1},
            };

        public int[] shortPath(){
            HashMap<string, int[][]> track = new HashMap<string, int[][]>();//[[0,1],[2,3]]
        HashSet<string> visited = new HashSet<string>();//"3,4"
        Queue<Node> queue = new Queue<Node>(); //bfs
        
        Node start = new Node([0,0])
        queue.Enqueue(start);
        while(queue.Count != 0){
            Node currentNode = queue.Dequeue();
            foreach (var step in posibleSteps)
            {
                int[] potentialStep = {step[0]+currentNode.position[0],step[1]+currentNode.position[1]};
                if(potentialStep[0] >= 0 && potentialStep[1] >= 0 
                    && potentialStep[1] < grid.length 
                    && potentialStep[0] < grid[0].length
                    && grid[potentialStep[0]][potentialStep[1]] == 0) {
                        Node newNode = new Node(potentialStep);
                        newNode.track.Add(currentNode.position);
                        queue.Enqueue(newNode);
                        if(newNode.position == finalPos) {
                            return newNode.track;
                        }
                }
                
            }
        }

        }

        

    }
}