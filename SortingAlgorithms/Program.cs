// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
var testArr = new int[] {8, 2, 4, 34, 1};
var s1 = BubleSorter.sort(testArr);
var s2 = SelectionSort.sort(testArr);
var s3 = MergeSorter.sort(testArr);

for(int i = 0; i < testArr.Length; i++) {
    Console.WriteLine(s3[i]);
}