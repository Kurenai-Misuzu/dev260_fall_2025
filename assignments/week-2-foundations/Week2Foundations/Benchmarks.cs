using System.Diagnostics;

public static class Benchmarks
{
    public static void Benchmark()
    {
        int n = 250000;
        Stopwatch stopwatch = new Stopwatch();

        listLastBenchmark(n, stopwatch);
        hashsetLastBenchmark(n, stopwatch);
        dictLastBenchmark(n, stopwatch);
        listMissingBenchmark(n, stopwatch);
        hashsetMissingBenchmark(n, stopwatch);
        dictLastBenchmark(n, stopwatch);
    }

    static void listLastBenchmark(int n, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            list.Add(i);
        }

        stopwatch.Start();
        list.Contains(n - 1);
        stopwatch.Stop();
        Console.WriteLine($"List.Contains(N-1): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void hashsetLastBenchmark(int n, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        HashSet<int> hashset = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            hashset.Add(i);
        }
        stopwatch.Start();
        hashset.Contains(n - 1);
        stopwatch.Stop();
        Console.WriteLine($"Hashset.Contains(N-1): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void dictLastBenchmark(int n, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            dict.Add(i, i);
        }
        stopwatch.Start();
        dict.ContainsKey(n - 1);
        stopwatch.Stop();
        Console.WriteLine($"Dictionary.ContainsKey(N-1): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void listMissingBenchmark(int n, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            list.Add(i);
        }

        stopwatch.Start();
        list.Contains(-999);
        stopwatch.Stop();
        Console.WriteLine($"List.Contains(-1): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void hashsetMissingBenchmark(int n, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        HashSet<int> hashset = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            hashset.Add(i);
        }
        stopwatch.Start();
        hashset.Contains(-999);
        stopwatch.Stop();
        Console.WriteLine($"Hashset.Contains(-1): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void dictMissingBenchmark(int n, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            dict.Add(i, i);
        }
        stopwatch.Start();
        dict.ContainsKey(-999);
        stopwatch.Stop();
        Console.WriteLine($"Dictionary.ContainsKey(-1): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }
}
