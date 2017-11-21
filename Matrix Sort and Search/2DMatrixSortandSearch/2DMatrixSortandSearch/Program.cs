using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ali Albayrak
//Student ID: P304320
//Date: 22/09/2017
/*
Portfolio Activity 1.4
In the previous topics you used searching and sorting algorithms on various data structures.In this
assessment task you will create a console application that will populate a matrix with non-repeating
random numbers.Then sort the matrix across each row and each column using the pseudo code
supplied to create a Young Tableau.Next you will create a Step-Wise Linear Search method to locate
a value in the matrix. The matrix must be square using a variable which can be altered from 5-8. The
random numbers must be from 10 to 100 inclusive.A separate display method must be used after
each method call to demonstrate the matrix values in a table format.
*/

namespace _2DMatrixSortandSearch
{
    class Program
    {               
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int size;
            Console.WriteLine("Please enter matrix size between 5 and 8: ");
            size = Convert.ToInt32(Console.ReadLine());

            //Loop for getting correct size entry from user
            while (size < 5 || size>8)
            {
                Console.WriteLine("Matrix size should be between 5 and 8!");
                Console.WriteLine("Please enter matrix size: ");
                size = Convert.ToInt32(Console.ReadLine());
            }

            // Creating 2D array named matrix
            int[,] matrix = new int[size,size];

            // Creating an arraylist to add numbers in the matrix
            ArrayList check = new ArrayList();


            //Fill Method. Filling the matrix with random numbers
            Fill(ref matrix,size,check);
                       
            //Display method before sorting the array
            Console.WriteLine("Matrix before Sorting: ");
            Display(ref matrix, size);


            //Sorting the matrix
            Sort(ref matrix, size);

            //Display method after sorting
            Console.WriteLine("After Sorting ");    
            Display(ref matrix,size);


            // Searching
            Console.WriteLine("Please enter a number to search: ");
            int search = Convert.ToInt32(Console.ReadLine());
            if (!stepWise(ref matrix, size, search))
            {
                Console.WriteLine("Couldnt found " + search);
            }
            else
            {
                Console.WriteLine("Found!");
            }
                 
        }

        // Step-Wise Linear Search method. Works for sorted matrix. First it checks if target number is in the bounds of sorted matrix. 
        //Then, searches for the user input in the 2D array(starts from top right of the matrix and goes bottom-left like steps)
        //and if it is found, displays the number position in the array and returns true. Returns false if number can`t found.

        public static bool stepWise(ref int[,] x, int max, int target)
        {
            if (target < x[0, 0] || target > x[max - 1, max - 1])
            {
                Console.WriteLine(target +  " is outside of the bounds of the matrix !");         
                return false;
            }
            else
            {
                int row = 0;
                int col = max - 1;
                while (row <= max - 1 && col >= 0)
                {
                    if (x[row, col] < target)
                    {
                        row++;
                    }
                    else if (x[row, col] > target)
                    {
                        col--;
                    }
                    else
                    {
                        Console.WriteLine(target + " Found at : Column: " + (col+1) + "   Row: " + (row+1));
                        return true;
                    }                 
                }
                return false;
            }
        }

        //Display method for the matrix. Displays the values of matrix by its row and column number order on the screen
        public static void Display(ref int[,] x, int max)
        {
              for (int i = 0; i < max; i++)
          {
              for (int j = 0; j < max; j++)
              {
                  int mat = x[i, j];
                  Console.Write("[ " + mat + "]   ");
              }
              Console.WriteLine(" ");
          }
        }

        //Fill method. Filling the matrix with random values between 10 and 100 by an arraylist. Also checks for duplicates and avoid from them.
        public static void Fill(ref int[,] x, int size , ArrayList list)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int num = rnd.Next(10, 101);

                    //duplicate check
                    if (!list.Contains(num))
                    {
                       x[i, j] = num;
                        list.Add(num);
                    }

                    else
                    {
                        j--;
                    }
                }
            }
        }

        // Sorting Method. Checks the matrix cell values one by one and compares them with their neighbour cell`s value. Sorting matrix by ascending order to create a Young tableau.
        public static void Sort(ref int[,] m, int size)
        {
            int temp = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (m[i, j] > m[x, y])
                            {
                                temp = m[x, y];
                                m[x, y] = m[i, j];
                                m[i, j] = temp;
                            }
                        }
                    }
                }
            }
        }

    }
}
