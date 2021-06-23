using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrepApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintArraySpiral(a, 4, 4);
            //IdentifyDuplicates(b, 5);
            //Identify5AndReplace("1234567890");
            //FindMax(new int[] { 5,8,4,2,9,5,3}, 3);
            //Sort(new int[] { 5, 8, 4, 2, 9, 5, 3 });
            //Encode(new List<byte> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            //AddTwoDigits(99);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = PunctuationMistakes("This is , a test! now ! That,I have a little bit more time,I was!able to get it done !");
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms and the result is: {res}");
        }

        static int[] Sort(int[] numbers)
        {
            //var result = numbers.Clone();
            //Array.Sort(result, new Comparison<int>(
            //(i, j) => j.CompareTo(i)
            //));
            //return result;
            var temp = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return numbers;
        }

        static IEnumerable<byte> Encode(IEnumerable<byte> original)
        {
            var count = 0;
            var previous = new byte();
            var result = new List<byte>();
            var first = true;

            if (original == null || original.Count() == 0)
            {
                return original;
            }

            foreach (var item in original)
            {
                Console.WriteLine("Item: ");
                Console.WriteLine(item);
                Console.WriteLine("Previous: ");
                Console.WriteLine(previous);

                if (first)
                {
                    count = 1;
                    previous = item;
                    first = false;

                    continue;
                }

                if (previous == item)
                {
                    count++;
                }

                else
                {
                    result.Add((byte)count);
                    result.Add(previous);
                    count = 1;
                }

                previous = item;
            }

            result.Add((byte)count);
            result.Add(previous);

            return result;
        }

        static int[] FindMax(int[] numbers, int n)
        {
            var size = numbers.Length < n ? numbers.Length : n;
            var result = new int[size];
            var ordered = new int[numbers.Length];

            for (int i = 0; i < ordered.Length; i++)
            {
                ordered[i] = numbers[i];
            }

            var temp = 0;
            for (int i = 0; i < ordered.Length; i++)
            {
                for (int j = i + 1; j < ordered.Length; j++)
                {
                    if (ordered[i] < ordered[j])
                    {
                        temp = ordered[i];
                        ordered[i] = ordered[j];
                        ordered[j] = temp;
                    }
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = ordered[i];
            }

            return result;
        }
        static void PrintArraySpiral(int[,] a, int m, int n)
        {
            var t = 0;
            var b = m - 1;
            var l = 0;
            var r = n - 1;
            var dir = 0;

            while (t <= b && l <= r)
            {
                if (dir == 0)
                {
                    for (int i = l; i <= r; i++)
                    {
                        Console.WriteLine(a[t, i]);
                    }

                    t++;
                }

                if (dir == 1)
                {
                    for (int i = t; i <= b; i++)
                    {
                        Console.WriteLine(a[i, r]);
                    }

                    r--;
                }

                if (dir == 2)
                {
                    for (int i = r; i >= l; i--)
                    {
                        Console.WriteLine(a[b, i]);
                    }
                    b--;
                }

                if (dir == 3)
                {
                    for (int i = b; i >= t; i--)
                    {
                        Console.WriteLine(a[i, l]);
                    }
                    l++;
                }

                dir = (dir + 1) % 4;
            }
        }

        static void IdentifyDuplicates(int[] a, int len)
        {
            var duplicates = new List<int>();

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (a[i] == a[j])
                    {
                        if (duplicates.Contains(a[i]))
                        {
                            break;
                        }

                        else
                        {
                            duplicates.Add(a[i]);
                        }
                    }
                }
            }

            if (duplicates.Count > 0)
            {
                foreach (var item in duplicates)
                {
                    Console.WriteLine(item);
                }
            }

            else
            {
                Console.WriteLine("No duplicates were found");
            }
        }

        static int AddTwoDigits(int n)
        {
            var sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }

        static string PunctuationMistakes(string text)
        {
            var newText = "";
            var length = text.Length;

            for (int i = 0; i < text.Length; i++)
            {
                var current = text[i];

                //first added only if it's not a space and next a punctuation
                if (i == 0)
                {
                    if (length > 1)
                    {
                        if (Char.IsWhiteSpace(current) && Char.IsPunctuation(text[i + 1]))
                        {
                            continue;
                        }
                    }

                    newText = string.Concat(newText, current);
                    continue;
                }

                if (i == length - 1)
                {
                    if (!Char.IsWhiteSpace(current))
                    {
                        newText = string.Concat(newText, current);
                    }
                    break;
                }

                var previous = text[i - 1];
                var next = text[i + 1];

                //if current is a space and next is a punction, skip
                if (Char.IsWhiteSpace(current) && Char.IsPunctuation(next))
                {
                    continue;
                }

                //if previous is punction, then next has to be a space
                if (Char.IsPunctuation(previous) && !Char.IsWhiteSpace(current))
                {
                    newText = string.Concat(newText, ' ', current);
                    continue;
                }

                newText = string.Concat(newText, current);
            }

            return newText;
        }
    }
}
