public class BubleSorter
{
    public static int[] sort(int[] arr)
    {
        bool haveSwapped = true;
        int lastIndex = arr.Length - 1;
        while (haveSwapped)
        {
            int i = 0;
            int j = i+1;
            haveSwapped = false;
            while (i < lastIndex && j <= lastIndex)
            {
                if (arr[i] > arr[j])
                {
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    haveSwapped = true;
                }
                i++;
                j++;
            }
            lastIndex--;
        }
        return arr;

    }

    // 

    public static int[] sort1(int[] arr)
    {
        int fillLastAvaible = arr.Length - 1;
        bool haveSwapped = true;
        while (haveSwapped)
        {
            haveSwapped = false;
            for (int i = 0; i < fillLastAvaible; i++)
            {
                int temp = arr[i];
                if (arr[i] > arr[i + 1])
                {
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    haveSwapped = true;
                }

            }
            fillLastAvaible--;

        }
        return arr;
    }
}