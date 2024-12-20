using System;

class CountingSort
{
    public static void PerformCountingSort(int[] arr)
    {
        int n = arr.Length;
        int max = FindMaxValue(arr);
        int[] count = new int[max + 1];
        
        for (int i = 0; i <= max; i++)
        { count[i] = 0; }

        for (int i = 0; i < n; i++)
        {  count[arr[i]]++;  }

        for (int i = 1; i <= max; i++)
        { count[i] += count[i - 1];  }

        int[] output = new int[n];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[arr[i]] - 1] = arr[i];
            count[arr[i]]--;  
        }

        for (int i = 0; i < n; i++)
        { arr[i] = output[i]; }
    }

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
        PerformCountingSort(arr);

        Console.WriteLine("Sorted Array: ");
        PrintArray(arr);
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
