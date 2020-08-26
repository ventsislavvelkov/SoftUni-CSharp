using System;
using System.Linq;
using System.Net.Sockets;

class MainClass
{



    static void Main()
    {
        // keep this function call here
        Console.WriteLine(SeatingStudents(Console.ReadLine().Split(",")
            .Select(int.Parse)
            .ToArray()));


    }

    public static int SeatingStudents(int[] arr)
    {
        var couuntOfDest = arr[0];
        var count = 0;
        var currArr = new int[couuntOfDest];

        for (int i = 0; i < couuntOfDest; i++)
        {
            currArr[i] = i + 1;
        }

        for (int i = 0; i < currArr.Length; i++)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                if (currArr[i] == arr[j])
                {
                    currArr[i] = 0;
                }
            }
        }

        for (int i = 0; i < currArr.Length; i++)
        {
            if (currArr[i] != 0)
            {
                if (i % 2 != 0)
                {
                    if (i + 2 < currArr.Length)
                    {
                        if (currArr[i] + currArr[i + 2] != currArr[i])
                        {
                            count++;
                        }
                    }

                }
                else
                {
                    if (i + 1 < currArr.Length)
                    {
                        if (currArr[i] + currArr[i + 1] != currArr[i])
                        {
                            count++;
                        }
                    }


                    if (i + 2 < currArr.Length)
                    {
                        if (currArr[i] + currArr[i + 2] != currArr[i])
                        {
                            count++;
                        }
                    }
                }
            }
        }

        arr[0] = count;

        return arr[0];

    }



}


