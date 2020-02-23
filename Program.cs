using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment2_CT_Spring2020
{
    class Program
    {
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int t)
        {
            try
            {
                int[] result = { -1, -1 };             // Initializing result
                int first = -1;                     // Initilalizing variable first
                int last = -1;                      // Initilalizing instance last
                for (int i = 0; i < l1.Length; i++)     // Iterate through list
                {
                    if (l1[i] == t)                 // Check if target is at ith position
                    {
                        if (first == -1)            // Check value of first 
                        {
                            first = i;              // If first is -1, assign i to first
                        }
                        last = i;                   // Assign i to last otherwise
                    }
                }
                result[0] = first;                  // Assign first to initialized list
                result[1] = last;                   // Assign first to initialized list
                return result;                      // Return result
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string StringReverse(string s)
        {
            try
            {
                string reverse = string.Empty;              // Initialize output string 
                string temp = string.Empty;                 // Initializing another string to place before the existing output string
                for (int i = s.Length - 1; i >= 0; i--)     // Iterate from end to start of string
                {
                    if (s[i] == ' ')                        // If string realizes a whitespace
                    {
                        reverse = temp + " " + reverse;     // Position temp before reverse with a space in between
                        temp = " ";                         // Assign whitspace to temp
                    }
                    else
                    {
                        temp += s[i];                       // Add letters to temp in reverse order
                    }
                }
                reverse = temp + " " + reverse;             // FInal string with expected output
                reverse = reverse.TrimStart();              // Trimming the space at the beginning caused due to temp
                return reverse;                             // Returning the output
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int MinimumSum(int[] l2)
        {
            int sum = 0;
            try
            {
                for (int i = 0; i < l2.Length - 1; i++)
                {
                    if (l2[i] == l2[i + 1])
                    {
                        l2[i + 1] = l2[i + 1] + 1;
                    }
                    sum += l2[i];
                }
                sum += l2[^1];
            }
            catch (Exception)
            {
                throw;
            }
            return sum;
        }

        public static string FreqSort(string s2)
        {
            string result = "";
            try
            {
                Dictionary<char, int> freq = new Dictionary<char, int>();
                for (int i = 0; i < s2.Length; i++)
                {
                    if (freq.ContainsKey(s2[i]))
                    {
                        freq[s2[i]] += 1;
                    }
                    else
                    {
                        freq[s2[i]] = 1;
                    }
                }

                SortedDictionary<int, List<char>> sortedfreq = new SortedDictionary<int, List<char>>();

                foreach (KeyValuePair<char, int> kvp in freq)
                {
                    if (sortedfreq.ContainsKey(kvp.Value))
                    {
                        sortedfreq[kvp.Value].Add(kvp.Key);
                    }
                    else
                    {
                        sortedfreq[kvp.Value] = new List<char> { kvp.Key };
                    }

                }
                foreach (KeyValuePair<int, List<char>> kvp in sortedfreq)
                {
                    foreach (char c in kvp.Value)
                    {
                        for (int i = 0; i < kvp.Key; i++)
                        {
                            result = c + result;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {

            int[] result = new int[] { };
            try
            {

                int[] nums1_int1 = new int[nums1.Length];
                int[] nums2_int1 = new int[nums2.Length];

                for (int n1 = 0; n1 < nums1.Length; n1++)
                {
                    nums1_int1[n1] = nums1[n1];
                }

                for (int n2 = 0; n2 < nums2.Length; n2++)
                {
                    nums2_int1[n2] = nums2[n2];
                }

                Array.Sort(nums1_int1);
                Array.Sort(nums2_int1);

                //implement merge sort

                int i = 0; int j = 0; int k = 0;
                while (i < nums1_int1.Length && j < nums2_int1.Length)
                {
                    if (nums1_int1[i] == nums2_int1[j])
                    {
                        nums1_int1[k] = nums1_int1[i];
                        i += 1; j += 1; k += 1;
                    }
                    else if (nums1_int1[i] < nums2_int1[j])
                    {
                        i += 1;
                    }
                    else
                    {
                        j += 1;
                    }
                }

                result = new int[k];

                for (int r = 0; r < k; r++)
                {
                    result[r] = nums1_int1[r];
                }

            }
            catch
            {
                throw;
            }
            return result;
        }

        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            int[] result = new int[] { };
            try
            {
                Dictionary<int, int> nums1_dict = new Dictionary<int, int>();
                foreach (int num in nums1)
                {
                    if (nums1_dict.ContainsKey(num))
                    {
                        nums1_dict[num] += 1;
                    }
                    else
                    {
                        nums1_dict[num] = 1;
                    }
                }
                int k = 0;

                int[] nums1_int2 = new int[nums1.Length];

                foreach (int num in nums2)
                {
                    if (nums1_dict.ContainsKey(num) && nums1_dict[num] > 0)
                    {
                        nums1_int2[k] = num;
                        k++;
                        nums1_dict[num] -= 1;
                    }
                }

                result = new int[k];

                for (int i = 0; i < k; i++)
                {
                    result[i] = nums1_int2[i];
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {

            try
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();   // Initialized dictionary
                for (int i = 0; i < arr.Length; i++)                        // Iterate through array
                {
                    if (dict.ContainsKey(arr[i]))                           // Check if array value is a key
                    {
                        if (i - dict[arr[i]] <= k)                          // check if difference of i and dictionary value is less than k
                        {
                            return true;                                    // return true if condition satisfied
                        }
                    }
                    else
                        dict[arr[i]] = i;                                   // Assign  array's value as key
                }
                return false;                                               // Return false otherwise
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int GoldRod(int rodLength)
        {

            try
            {
                {
                    int n = rodLength;                                                            // Initialize rod length as n
                    int price = 0;                                                                // Initialize price as 0
                    /* The for loop is called for the rod length - 1 and for the recursive function used in max function below*/
                    for (int i = 1; i < n; i++)                                                  // Iterate uptil rod length

                    {
                        price = Math.Max(price, Math.Max(i * (n - i), i * GoldRod(n - i)));     // Pick maximum value using max function
                    }
                    return price;                                                               // return maximum price as output
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {
                List<string> li = userDict.ToList();                // created a list to store userDict
                foreach (string item in li)                        // Traversing through each word in the list 'li'
                {
                    if (item.Length != keyword.Length)              // checking if the length of current word(item) = length of keyword
                    {
                        continue;                                   // if not equal continue to next word
                    }
                    else
                    {
                        int count = 0;                              // Initialized count to 0
                        for (int i = 0; i < item.Length; i++)       // Traversing through each letter in the item
                        {
                            if (item[i] == keyword[i])              // To check each of the letters of item and keyword
                            {
                                count++;                            // Increment counter
                            }
                        }
                        if (count == (item.Length - 1))             // To check if length of common letters between item and keyword is 1 less than the length of each
                        {
                            return true;                            // Returns true
                        }
                    }
                }
                return false;                                       // Else returns false

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            return default;
        }

        public static void SolvePuzzle()
        {
            List<List<int>> perm = new List<List<int>>();
            List<char> uniqlist = new List<char>();
            Dictionary<char, int> uniq_dict = new Dictionary<char, int>();
            string input1 = "";
            string input2 = "";
            string output = "";
            try
            {
                Console.WriteLine("Enter input1");
                input1 = Console.ReadLine();
                Console.WriteLine("Enter input2");
                input2 = Console.ReadLine();
                Console.WriteLine("Enter output");
                output = Console.ReadLine();


                UniqueChar(input1);
                UniqueChar(input2);
                UniqueChar(output);

                void UniqueChar(string input)
                {
                    foreach (char c in input)
                    {
                        if (uniqlist.Contains(c))
                        {
                            continue;
                        }
                        else
                        {
                            uniqlist.Add(c);
                        }
                    }
                }

                Console.WriteLine(string.Join(",", uniqlist));



                int[] opt = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                Permutation(opt, 0, opt.Length - 1, perm);

                static void Swap(ref int a, ref int b)
                {
                    var temp = a;
                    a = b;
                    b = temp;
                }


                static List<List<int>> Permutation(int[] opt, int start, int end, List<List<int>> perm)
                {
                    if (start == end)
                    {
                        perm.Add(new List<int>(opt));
                    }
                    else
                    {
                        for (int i = start; i <= end; i++)
                        {
                            Swap(ref opt[start], ref opt[i]);
                            Permutation(opt, start + 1, end, perm);
                            Swap(ref opt[start], ref opt[i]);
                        }
                    }

                    return perm;
                }


                double compute_length(string input)
                {
                    int x = input.Length - 1;
                    double input_double = 0;
                    for (int i = input.Length - 1; i >= 0; i--)
                    {

                        if (uniq_dict[input[i]] == 0)
                        {
                            input_double += 0;
                            continue;
                        }
                        input_double += Math.Pow(10, (x - i)) * uniq_dict[input[i]];
                    }

                    return input_double;
                }

                foreach (List<int> result in perm)
                {

                    if (result[0] == 0 || result[1] == 0)
                    {
                        continue;
                    }

                    for (int i = 0; i < uniqlist.Count; i++)
                    {
                        uniq_dict[uniqlist[i]] = result[i];
                    }

                    double input1_int = compute_length(input1);
                    double input2_int = compute_length(input2);
                    double output_int = compute_length(output);

                    if ((input1_int + input2_int) == output_int)
                    {
                        Console.WriteLine(input1_int);
                        Console.WriteLine(input2_int);
                        Console.WriteLine(output_int);
                        foreach (KeyValuePair<char, int> kvp in uniq_dict)
                        {
                            Console.WriteLine("Char: {0}, Integer:{1}", kvp.Key, kvp.Value);
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            Console.WriteLine("[" + string.Join(",", r) + "]");
            Console.WriteLine();

            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);
            Console.WriteLine();

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);
            Console.WriteLine();

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);
            Console.WriteLine();

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);

            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");

            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));
            Console.WriteLine();

            Console.WriteLine("Question 7");
            int rodLength = 4;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);
            Console.WriteLine();

            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";
            Console.WriteLine(DictSearch(userDict, keyword));
            Console.WriteLine();

            Console.WriteLine("Question 9");
            SolvePuzzle();
        }
    }
}