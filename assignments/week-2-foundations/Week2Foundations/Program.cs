namespace Week2Foundations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            // PartA();
            // PartB();
            // PartC();
            // PartD();
            // PartE();
            // PartF();

            // Benchmarks wau = new Benchmarks();
            // wau.Benchmarks();
            Benchmarks.Benchmark();

        }
        static void PartA()
        {
            // part a
            // create int[] length 10
            int[] a_array = new int[10];
            // set 3 values
            for (int i = 0; i < 3; i++)
            {
                a_array[i] = i;
            }
            // print index 2
            Console.WriteLine("Index 2: " + a_array[2]);
            //linear search (looking for number 1)
            for (int i = 0; i < a_array.Length; i++)
            {
                if (a_array[i] == 1)
                {
                    Console.WriteLine("value found");
                    continue;
                }
            }
            Console.WriteLine();
        }
        static void PartB()
        {
            // part b
            // initiazlie list, add 1-5
            List<int> b_list = new List<int> { 1, 2, 3, 4, 5 };
            // insert 99 at index2
            b_list.Insert(2, 99);
            // remove it
            b_list.Remove(99);
            // print final count
            Console.WriteLine("b list count: " + b_list.Count());
            Console.WriteLine();
        }

        static void PartC()
        {
            // part c
            //initialize stack
            Stack<string> c_stack = new Stack<string>();
            // push 3 page urls
            c_stack.Push("https://google.com");
            c_stack.Push("https://twitch.tv");
            c_stack.Push("https://youtu.be");
            // peek current page
            Console.WriteLine(c_stack.Peek());
            // pop all
            c_stack.Pop();
            c_stack.Pop();
            c_stack.Pop();
            // part c order
            Console.WriteLine("C PROCESSING ORDER: google.com > twitch.tv > youtu.be > twitch.tv > google.com > null");
            Console.WriteLine();
        }
        static void PartD()
        {
            // part d
            // initialize queue
            Queue<string> d_queue = new Queue<string>();
            // enqueue 3 print jobs
            d_queue.Enqueue("homework 1");
            d_queue.Enqueue("homework 2");
            d_queue.Enqueue("final paper");
            // peek
            Console.WriteLine(d_queue.Peek());
            // dequeue
            d_queue.Dequeue();
            d_queue.Dequeue();
            d_queue.Dequeue();
            // Print processing order
            Console.WriteLine("D PROCESSING ORDER: homework 1 > homework 2 > final paper");
            Console.WriteLine();
        }
        static void PartE()
        {
            // part e/
            //initialize
            Dictionary<string, int> e_dictionary = new Dictionary<string, int>();
            // map 3 SKUs to 3 quanitities 
            e_dictionary.Add("1110", 30);
            e_dictionary.Add("5671", 26);
            e_dictionary.Add("1389", 15);
            //update one quantitiy
            e_dictionary["5671"] = 100;
            // then show TryGetValue("missing") result
            Console.WriteLine("part e: " + e_dictionary.TryGetValue("missing", out int e));
            Console.WriteLine();
        }

        static void PartF()
        {
            // part f
            HashSet<int> f_hashset = new HashSet<int>();
            // add a few integers with duplicates /// check if it says false 
            Console.WriteLine("adding not duplicated: " + f_hashset.Add(2));
            Console.WriteLine("adding duplicate: " + f_hashset.Add(2));
            f_hashset.Add(3);
            f_hashset.Add(2);
            f_hashset.Add(1);
            f_hashset.Add(2);
            f_hashset.Add(4);
            f_hashset.Add(6);
            // perform unionwidth
            f_hashset.UnionWith(new HashSet<int> { 3, 4, 5 });
            // print final count
            Console.WriteLine("hashset final count: " + f_hashset.Count());
            Console.WriteLine();
        }
    }

}
















