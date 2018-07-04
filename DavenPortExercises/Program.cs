using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavenPortExercises
{

    static class Program
    {
        static void Main(string[] args)
        {

            CallFirstExercise(new int[] 
            {
                21,14,19,3,80,7
            });

            //CallSecondExercise("dog");
        }

        public static void CallFirstExercise(int[] array)
        {
            //[5, 3, 2, 8, 1, 4] should return [1, 3, 2, 8, 5, 4]
            //[6, 3, 2, 7, 5, 0] should return [6, 3, 2, 5, 7, 0]
            var newarray = ReorderArray(array);
            for (int i = newarray.GetLowerBound(0); i <= newarray.GetUpperBound(0); i++)
                Console.WriteLine("   [{0}] : {1}", i, newarray[i]);
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void CallSecondExercise(string word)
        {
            var middleCharacter = GetMiddleCharacter(word);
            Console.WriteLine(string.Format("Middle Character(s): {0} ", middleCharacter));
            Console.WriteLine();
            Console.ReadKey();
        }
        #region Logic
        #region First Exercise
        public static int[] ReorderArray(int[] inputArray)
        {
            int[] outputArray = { };
            if (!inputArray.Any()) return outputArray;
            var tempLst = new List<int>(0);//declare  temp int List
            var evenDict = new Dictionary<int, int>(); // dictionary with key and value of int type
            for (int i = 0; i < inputArray.Length; i++)//Loop over inputArray
                if (inputArray[i] % 2 == 0)//validate if any number is even then insert it into dictionary
                    evenDict.Add(i, inputArray[i]);
            var oddArray = inputArray.Where(o => (o % 2 != 0)).ToArray();//extract odd numbers from inputArray
            oddArray.PartialSort(0, oddArray.Length);//Sort asceding  odd numbers
            outputArray = oddArray;//equalize odd numbers variable  to outputArray
            for (int i = 0; i < outputArray.Length; i++)//Loop over outputArray and insert numbers into temp int List
                tempLst.Insert(i, outputArray[i]);
            foreach (KeyValuePair<int, int> entry in evenDict)//Loop over dictionary and insert  number with its index into temp int List
                tempLst.Insert(entry.Key, entry.Value);
            outputArray = tempLst.ToArray();
            return outputArray;
        }

        public static int[] Insert(int[] existinNuber, int position, int Newnum)
        {
            int[] result = new int[existinNuber.Length];
            for (int i = 0; i < position; i++)
                result[i] = existinNuber[i];
            result[position] = Newnum;
            for (int i = position + 1; i < existinNuber.Length; i++)
                result[i] = existinNuber[i - 1];
            return result;
        }
        #endregion

        #region Second Exercises
        public static string GetMiddleCharacter(string inputString)
        {
            int length = inputString.Length;
            string outPutString = string.Empty;
            if (inputString == string.Empty) return outPutString;
            Double midvalue = 0;
            int mid = 0;
            if (inputString.IsOdd())
            {
                midvalue = length / 2;
                mid = Convert.ToInt32(midvalue);
                char[] InputString = inputString.ToCharArray();
                outPutString = InputString[mid].ToString();
            }
            else
            {
                char[] InputString = inputString.ToCharArray();
                var firstHalf = inputString.Substring(0, length / 2);
                var secondHalf = inputString.Substring(length / 2, length - (length / 2));
                outPutString = string.Concat(firstHalf.Last().ToString(), secondHalf.First().ToString());
            }
            return outPutString;
        }

        #endregion

        #region Extensions
        public static bool IsOdd(this string value)
        {
            return (value.Length % 2 != 0);
        }
        public static bool IsOdd(this int value)
        {
            return (value % 2 != 0);
        }
        public static void PartialSort<T>(this T[] sequence, int startindex, int endindex)
        {
            sequence.Skip(startindex).Take(endindex - startindex + 1)
            .OrderBy(o => o).ToArray().CopyTo(sequence, startindex);
        }


    }
    #endregion

    #endregion
}
