//        2,6,7,83,23,9,4,90,24
//      2,6,7,83      23,9,4,90,24
//      2,6,  7,83      23,9,4   90,24
//      2,6,7,83        4,9,23,24,90
// split
// merge function
public class MergeSorter
{

    public static int[] sort(int[] array)
    {
        if (array.Length == 1)
        {
            return array;
        }

        int midpoint = array.Length / 2;
        int[] left = array.Take(midpoint).ToArray();
        int[] right = array.Skip(midpoint).ToArray();
        left = sort(left);
        right = sort(right);

        return merge(left, right);
        // return new int[2];
    }

    public static int[] merge(int[] arr1, int[] arr2)
    {
        //have two pointers, one in each ar

        //compare the values of each array an to the new array, the pointer increments 
        int l = 0;
        int r = 0;
        // int pos = 0;
        int[] result = new int[arr1.Length + arr2.Length];

        for(int i=0;i<result.Length;i++){
            if(l == arr1.Length){
                result[i] = arr2[r];
                r++;
                continue;
            }
            if(r == arr2.Length){
                result[i] = arr2[l];
                l++;
                continue;
            }

            if(arr1[l] > arr2[r]){
                result[i] = arr2[r];
                r++;
            }else{
                result[i] = arr1[l];
                l++;
            }
        }

        // while (l < arr1.Length && r < arr2.Length)
        // {
        //     if (arr1[l] < arr2[r])
        //     { //taking from the left array, arr1
        //         result[pos] = arr1[l];
        //         l++;
        //     }
        //     else
        //     {
        //         result[pos] = arr2[r];
        //         r++;
        //     }
        //     pos++;
        // }
        // if(l < arr1.Length) {
        //     for(int i=l; i<arr1.Length; i++) {
        //         result[pos] = arr1[i];
        //         pos++;
        //     }
        // }
        // if(r < arr2.Length) {
        //     for(int i=r; i<arr2.Length; i++) {
        //         result[pos] = arr2[i];
        //         pos++;
        //     }
        // }


        
        return result;
        //whicever one gets sorted i                //whicever one gets sorted i        ya
    }
}

