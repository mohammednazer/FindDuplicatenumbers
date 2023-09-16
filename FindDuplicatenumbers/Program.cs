using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDuplicatenumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<int> randomNumbers = GenerateRandomNumbers(1, 100, 100);

            Console.WriteLine("Random numbers:");
            Console.WriteLine(string.Join(", ", randomNumbers));


            List<int> duplicateNumbers = FindDuplicates(randomNumbers); // find duplicates using sort and compare 

            List<int> duplicateNumbersDictionary = FindDuplicatesusingDictionary(randomNumbers); // using dictionary 

            List<int> duplicateNumbersHashset = FindDuplicatesUsingHashset(randomNumbers); // using dictionary

            if (duplicateNumbers.Count > 0)
            {
                Console.WriteLine("\nDuplicate numbers found using Sort and compare:");
                Console.WriteLine(string.Join(", ", duplicateNumbers));

                Console.WriteLine("\nDuplicate numbers found using Dictionary:");
                Console.WriteLine(string.Join(", ", duplicateNumbersDictionary));

                Console.WriteLine("\nDuplicate numbers found using Dictionary:");
                Console.WriteLine(string.Join(", ", duplicateNumbersHashset));
            }
            else
            {
                Console.WriteLine("\nNo duplicate numbers were found.");
            }
            Console.ReadLine();
        }
        static List<int> GenerateRandomNumbers(int min, int max, int count)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(min, max + 1);
                numbers.Add(randomNumber);
            }
            return numbers;
        }
        /// <summary>
        /// Sort the list first and then compare adjacent elements. 
        /// This approach has a time complexity of O(n log n) for sorting and O(n) for finding duplicates, 
        /// making it efficient for larger lists.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static List<int> FindDuplicates(List<int> numbers)
        {
            List<int> duplicateNumbers = new List<int>();
            numbers.Sort();
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    duplicateNumbers.Add(numbers[i]);
                }
            }
            return duplicateNumbers;
        }
        /// <summary>
        /// Use a dictionary (or a Hashtable) to store counts of each element in the list. 
        /// This approach also has a time complexity of O(n).
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static List<int> FindDuplicatesusingDictionary(List<int> numbers)
        {
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();
            List<int> duplicateNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (numberCounts.ContainsKey(number))
                {
                    numberCounts[number]++;
                }
                else
                {
                    numberCounts[number] = 1;
                }
            }

            foreach (var pair in numberCounts)
            {
                if (pair.Value > 1)
                {
                    duplicateNumbers.Add(pair.Key);
                }
            }
            return duplicateNumbers;
        }
        /// <summary>
        /// using hasset
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static List<int> FindDuplicatesUsingHashset(List<int> numbers)
        {
            List<int> duplicateNumbers = new List<int>();
            HashSet<int> uniqueNumbers = new HashSet<int>();

            foreach (int number in numbers)
            {
                if (!uniqueNumbers.Add(number)) //
                {                 
                    duplicateNumbers.Add(number);
                }
            }
            return duplicateNumbers;
        }
    }
}
