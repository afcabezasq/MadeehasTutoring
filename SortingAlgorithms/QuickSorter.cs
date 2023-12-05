public class QuickSorter{
    //              <-// -> 
    //[2,8,7,12,19,20,43,50]
    //           

    //[2,8,12,43,19,54,7,20]
    //        |           |
    //        l           r
    //if(arr[left]> pivot && arr[right] < pivot) {
    //    swap;
    // }
    // rightIndex == end  left < pivot 
    // increase leftIndex
    // if left < pivot and right element > pivot
    // increase right index

    public static int[] sort(){
        return new int[2];
    }


    public static int[] quickSort(int[] arr, int beginning, int end){

        int pivot = arr[end];
        int leftIndex = 0;
        int rightIndex = 1;
        int pivotIndex = end;
        
    }
}