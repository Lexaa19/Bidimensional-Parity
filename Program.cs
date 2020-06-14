using System;
using System.Collections.Generic;
using System.Linq;

namespace ParitateBidimensionala
{
    class Program
    {
        private bool validateUserInput(string userInput)
        {
            if ((userInput.Length % 7) == 0)
            {
                if ((userInput.Contains("1") || userInput.Contains("0")))
                {
                   // Console.WriteLine("Your input is correct!");
                   
                }
                return true;
            }
            else
            {
                Console.WriteLine("Your input is not correct! Please enter a number that is multiple of 7 and contains only '1's and '0's");
                Console.WriteLine("Examples of numbers multiple of 7: 7, 14, 21....");
                return false;
            }

        }

        private void getRowsParity(List<string> lst, string parityWord)
        {
            int counter = 0;
            int index = 0;
            foreach (char item in parityWord)
            {
                if (item == '1')
                {
                    counter++;
                    index++;
                }
                if (item == '0')
                {
                    counter += 0;
                }
            }
            if (counter % 2 == 0)
            {
                Console.WriteLine("Parity is: 0");
            }
            else
            {
                Console.WriteLine("Parity is: 1");
            }

        }
        public void initialSteps(string userInput)
        {
            List<string> lst = new List<string>();

            Program p = new Program();
            p.validateUserInput(userInput);

            int chunkSize = 7;
            int stringLength = userInput.Length;

            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength)
                {
                    chunkSize = stringLength - i;
                }

                lst.Add(userInput.Substring(i, chunkSize));
                Console.WriteLine(userInput.Substring(i, chunkSize));
                p.getRowsParity(lst, userInput.Substring(i, chunkSize));
            }
        }

        public void getColumnParity(string userInput)
        {
            int rows = (userInput.Length) / 7;
            int columns = 7;
            char[] oneDimensionalArray = new char[userInput.Length];
            char[,] twoDimensionalArray = new char[rows, columns];
            for (int i = 0; i < userInput.Length; i++)
            {
                oneDimensionalArray[i] = userInput[i];//Store values in one-dimensional array
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    twoDimensionalArray[i, j] = oneDimensionalArray[i * columns + j];//Store values in two-dimensional array

                }
            }
            List<string> columnBits = new List<string>();
            int count = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (twoDimensionalArray[j, i] == '1')
                    {
                        count++;
                    }
                }
                if (count % 2 == 0)
                {
                    columnBits.Add("0");
                }
                else {
                    columnBits.Add("1");

                }
                count = 0;

            }
            Console.WriteLine("Parity bits by column: ");
            columnBits.ForEach(Console.Write);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number multiple of 7: ");
            string userInput = Console.ReadLine();
            Program p = new Program();
            if (p.validateUserInput(userInput) == true)
            {
                p.initialSteps(userInput);
                p.getColumnParity(userInput);
                Console.ReadLine();
            }
            else
            {
                Console.ReadLine();
            }
            }
        }
    }



    


   
    
        


