using System;
public enum Movement
{
    clockwise,
    cClockwise
}
public class Relationships
{

    Dictionary<char, Dictionary<char, int[]>> relationships { get; set; }
    Dictionary<char, char[]> order { get; set; }

    public Relationships(char front)
    {
        relationships = new Dictionary<char, Dictionary<char, int[]>>();
        relationships.Add('r', new Dictionary<char, int[]>{
            {'g', new int[]{0,3,6}},
            {'y', new int[]{6,7,8}},
            {'b', new int[]{2,5,8}},
            {'w', new int[]{0,1,2}}
            });
        relationships.Add('g', new Dictionary<char, int[]>{
            {'o', new int[]{0,3,6}},
            {'y', new int[]{8,5,2}},
            {'r', new int[]{2,5,8}},
            {'w', new int[]{2,5,8}}
            });
        SetOrder();
    }

    private void SetOrder()
    {
        order = new Dictionary<char, char[]>();
        order.Add('r', new char[] { 'g', 'y', 'b', 'w' });
        order.Add('g', new char[] { 'o', 'y', 'r', 'w' });
    }
    public Cube RotateFace(Cube cube, Movement m)
    {
        var frontFace = cube.frontFace;
        Relationships r = new Relationships(frontFace);
        var sides = r.relationships[frontFace];

        if (m == Movement.clockwise)
        {
            var faceOrder = order[frontFace];
            var shiftedFaceOrder = shiftedClockwise(faceOrder);
            // Dictionary<char, char[]> 
            foreach (var face in faceOrder)
            {
                var currentFace = cube.faces[face];
                sideCreator(faceOrder, shiftedFaceOrder, currentFace, frontFace);
            }
            // 51-66
            // inputs and outputs
            // inputs: faceOrder, shiftedFaceOrder, currentFace, frontFace
            // outputs: char[] side

            // 63-65
            //inputs: copyFaceTo, indecesTo, completeFaceFrom, indecesFrom
            //output: char[] rotatedFace
        }


    
        return new Cube();
    }


/// <summary>
/// Paste colors from a face to the one target when rotating our cube
/// </summary>
/// <param name="cft"></param>
/// <param name="cff"></param>
/// <param name="it"></param>
/// <param name="inf"></param>
/// <returns></returns>
private char[] rotator(char[] cft, char[] cff, int[] it, int[] inf)
{
    for (int j = 0; j < 3; j++)
    {
        cft[it[j]] = cff[inf[j]];
    }
    return cft;
}

private char[] sideCreator(
    char[] faceOrder,
    char[] shiftedFaceOrder,
    Dictionary<char, char[]> currentFace,
    char frontFace)
{
    char[] side = new char[9];
    for (int i = 0; i < 4; i++) // 4 times 
    {
        char faceFrom = faceOrder[i];
        char faceTo = shiftedFaceOrder[i];

        char[] completeFaceFrom = currentFace[faceFrom]; //starting char array [a b, c, d]
        char[] completeFaceTo = currentFace[faceTo]; //where each array will change to [d,c,b,a]
        char[] copyFaceTo = (char[])completeFaceTo.Clone();

        var indecesFrom = relationships[frontFace][faceFrom]; //values for completefacefrom
        var indecesTo = relationships[frontFace][faceTo]; //values for completefaceto

        side = rotator(copyFaceTo, completeFaceFrom, indecesTo, indecesFrom); 
    }// last one 
    return side;
}

public char[] shiftedClockwise(char[] colors)
{ //[g,y,b,w] []
    var newOrder = new char[4];
    newOrder[0] = colors[colors.Length - 1];
    for (int i = 1; i < colors.Length; i++)
    {
        newOrder[i] = colors[i - 1];
    }
    return newOrder;
}
public char[] shiftedCClockwise(char[] colors)
{ //[g,y,b,w] [y,b,w,g]
    var newOrder = new char[4];
    newOrder[newOrder.Length - 1] = colors[0];
    for (int i = 0; i < colors.Length; i++)
    {
        newOrder[i] = colors[i + 1];
    }
    return newOrder;
}
}