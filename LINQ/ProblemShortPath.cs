using System.Collections;

namespace problem
{
    public class Node
    {
        public int[] position {get;set;}
        public List<int[]> track {get;set;}

        public Node(int[] startingPosition) {
            track = new List<int[]>();
            position = startingPosition;
            track.Add(position);
        }
        public override string ToString(){
            return $"{position[0]},{position[1]}";
        }
    }
    public class Problem
    {
        int[][] grid = {
           new int[] {0,0,0,0,0,0,0},
           new int[] {0,1,0,0,0,0,0},
           new int[] {0,1,0,0,1,0,0},
           new int[] {0,1,0,0,1,0,0},
           new int[] {0,0,0,0,1,0,0},
           new int[] {0,0,0,0,1,0,0},
        };
        int[] startingPos = {0, 0};
        int[] finalPos = {5, 5};
        // Dictionary<string,List[int[]]> trackMap = new Dictionary<string, List[int[]]>();


        int[][] posibleSteps = {
           new int[] {1,1},
           new int[] {1,0},
           new int[] {1,-1},
           new int[] {0,1},
           new int[] {0,-1},
           new int[] {-1,1},
           new int[] {-1,0},
           new int[] {-1,-1},
        };

        public List<int[]> shortPath(){
            // Dictionary<string,List< int[]>> track = new Dictionary<string, int[][]>();//[[0,1],[2,3]]
            HashSet<string> visited = new HashSet<string>();//"3,4"
            Queue<Node> queue = new Queue<Node>(); //bfs
        
            Node start = new Node(this.startingPos);
            queue.Enqueue(start);
            // trackMap.Add(start.ToString(),start.track);
            while(queue.Count != 0){
                Node currentNode = queue.Dequeue();
                visited.Add(currentNode.ToString());
                // currentTrack = trackMap[currentNode.ToString()];
                
                //Console.WriteLine($"{currentNode.position[0]}, {currentNode.position[1]}");
                foreach (var step in posibleSteps)
                {
                    int[] potentialStep = {step[0]+currentNode.position[0],step[1]+currentNode.position[1]};
                    Node newNode = new Node(potentialStep);
                    if(potentialStep[0] >= 0 && potentialStep[1] >= 0 
                        && potentialStep[0] < grid.Length 
                        && potentialStep[1] < grid[0].Length
                        && grid[potentialStep[0]][potentialStep[1]] == 0 
                        && !visited.Contains(newNode.ToString())) {
                            
                            newNode.track = new List<int[]>(currentNode.track);
                            
                            newNode.track.Add(currentNode.position);
                            queue.Enqueue(newNode);
                            visited.Add(newNode.ToString());
                            
                            if(newNode.position[0] == finalPos[0] && newNode.position[1] == finalPos[1]) {
                                return newNode.track;
                            }
                    }
                    
                }
            }
            return new List<int[]>(){ 
                new int[]{-1,-1}
            };

        }

        public void displayShortestPath() {
             List<int[]> solution = this.shortPath();
            foreach (var pos in solution) {
                grid[pos[0]][pos[1]] = 2;
            }
            foreach (var row in solution) {
                 foreach (var pos in row) {
                    Console.Write(pos);
                 }
                 Console.WriteLine();
             }

            foreach (var row in grid) {
                foreach (var pos in row) {
                    Console.Write(pos + "  "); 
                }
                Console.WriteLine();
            }

        }
        

    }
}