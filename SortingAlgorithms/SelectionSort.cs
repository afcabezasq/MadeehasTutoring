/// 2,5,7,8,2,4,6 -> min value 2
/// 2,5,7,8,2,4,6 -> min value 2
/// 2,2,7,8,5,4,6 
/// var temp = arr[i];
// arr[i] = arr[j];
// arr[j] = temp;
/// </summary>

public class SelectionSort
{

    public static int[] sort(int[] arr)
    {
        int startIndex = 0;
        while (startIndex < arr.Length)
        {
            int minValue = arr[startIndex];
            int i = startIndex;
            int minIndex = startIndex;
            while (i < arr.Length)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    minIndex = i;
                }
                i++;
            }
            var temp = arr[startIndex];
            arr[startIndex] = minValue;
            arr[minIndex] = temp;
            startIndex++;
        }
        return arr;
    }
}