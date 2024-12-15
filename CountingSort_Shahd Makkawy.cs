using System;

class CountingSort
{
    // Function to perform Counting Sort
    public static void PerformCountingSort(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Find the maximum value in the array
        int max = FindMaxValue(arr);

        // Step 2: Create and initialize count array
        int[] count = new int[max + 1];
        for (int i = 0; i <= max; i++)
            count[i] = 0;

        // Step 3: Count the occurrences of each element
        for (int i = 0; i < n; i++)
            count[arr[i]]++;

        // Step 4: Modify count array to store cumulative sums
        for (int i = 1; i <= max; i++)
            count[i] += count[i - 1];

        // Step 5: Create output array
        int[] output = new int[n];

        // Step 6: Place elements into output array in sorted order
        for (int i = n - 1; i >= 0; i--)
        {
            output[count[arr[i]] - 1] = arr[i];
            count[arr[i]]--;  // Decrease count for the processed element
        }

        // Step 7: Copy the output array back to the original array
        for (int i = 0; i < n; i++)
            arr[i] = output[i];
    }

    // Utility function to find the maximum value in the array
    public static int FindMaxValue(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        return max;
    }

    // Main function to test the Counting Sort
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Original Array: ");
        PrintArray(arr);

        // Perform Counting Sort
        PerformCountingSort(arr);

        Console.WriteLine("Sorted Array: ");
        PrintArray(arr);
    }

    // Utility function to print an array
    public static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
