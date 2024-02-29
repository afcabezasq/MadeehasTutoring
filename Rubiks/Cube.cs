public class Cube {

    public string rubixCube { get; set; }

    public char frontFace { get; set; }  

    public Dictionary<char, Dictionary<char, char[]>> faces { get; set; } = new Dictionary<char, Dictionary<char, char[]>>();

    public Cube() {
        rubixCube = "rrrrrrrrrgggggggggyyyyyyyyybbbbbbbbbbwwwwwwwwwooooooooo";
        setFaces();
    }

    public Cube(string state) {
        rubixCube = state;
        setFaces();
    }

    private void setFaces() {
        faces.Add('r', new Dictionary<char, char[]>
        {
            {'g', rubixCube.Substring(9,17).ToCharArray()},
            {'w', rubixCube.Substring(36,44).ToCharArray()},
            {'b', rubixCube.Substring(27,35).ToCharArray()},
            {'y', rubixCube.Substring(18,26).ToCharArray()}
        });
    }

    private void setFrontFace() {
        //Subsring(startindex, endIndex)
        frontFace = rubixCube[4];
    }

    public void move(Movements moveType) {
        var currentFace = rubixCube[..8];
        char[] newArray = new char[9];
        var charArray = currentFace.ToCharArray();
        switch(moveType) {
            case Movements.f:
                for(int i = 0; i < 9; i ++) {
                    newArray[i] = charArray[cClockwiseFrontTransformation(i)];
                }
                break;
            case Movements.F:
                for(int i = 0; i < 9; i ++) {
                    newArray[i] = charArray[cClockwiseFrontTransformation(i)];
                }
                break;


        }


    }

    private int cClockwiseFrontTransformation(int index) {
        switch(index) {
            case 0:
                return 6;
            case 1:
                return 3;
            case 2:
                return 0;
            case 3:
                return 7;
            case 4:
                return 4;
            case 5:
                return 1;
            case 6:
                return 8;
            case 7:
                return 5;
            case 8:
                return 2;
        }
        return -1;
    }

    private int clockwiseFrontTransformation(int index) {
        switch(index) {
            case 0:
                return 2;
            case 1:
                return 5;
            case 2:
                return 8;
            case 3:
                return 1;
            case 4:
                return 4;
            case 5:
                return 7;
            case 6:
                return 0;
            case 7:
                return 3;
            case 8:
                return 6;
        }
        return -1;
    }
}