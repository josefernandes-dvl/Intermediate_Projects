using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
        inicio:
            Console.Clear();
            Console.WriteLine("Hello! Welcome to the Grading System.");
            Console.Write("First of all, what is the total number of students? R: ");
            int totalStudents = Convert.ToInt32(Console.ReadLine());
            double[] math = new double[totalStudents];
            double[] science = new double[totalStudents];
            double[] english = new double[totalStudents];
            double[] essay = new double[totalStudents];
            double[] averages = new double[totalStudents];
            double[] averages2 = new double[totalStudents];

            for (int i = 0; i < totalStudents; i++)
            {
                Console.Clear();
                Console.Write("Enter the grade of student " + (i + 1) + " in Mathematics: ");
                math[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nEnter the grade of student " + (i + 1) + " in Science: ");
                science[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nEnter the grade of student " + (i + 1) + " in English: ");
                english[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nEnter the grade of student " + (i + 1) + " in Essay: ");
                essay[i] = Convert.ToDouble(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("----Student " + (i + 1) + " grades----");
                Console.WriteLine("Mathematics ....... " + math[i]);
                Console.WriteLine("Science ........... " + science[i]);
                Console.WriteLine("English: .......... " + english[i]);
                Console.WriteLine("Essay ............. " + essay[i]);

                Console.WriteLine("\nWhat course does the student " + (i + 1) + " intend to enroll in?");
                Console.WriteLine("1. Computer Science\n2. Engineering\n3. Medicine\n4. Physics\n5. Letters\n6. Physical Education");
                int index = Convert.ToInt32(Console.ReadLine());

                switch (index)
                { 
                    case 1:
                        double finalRes1 = ComputerScience(math[i], science[i], english[i], essay[i]);
                        Console.WriteLine("The final average of student " + (i + 1) + " is: " + finalRes1);
                        averages[i] = Convert.ToInt32(finalRes1);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();

                        break;

                    case 2:
                        double finalRes2 = Engineering(math[i], science[i], english[i], essay[i]);
                        Console.WriteLine("The final average of student " + (i + 1) + " is: " + finalRes2);
                        averages[i] = Convert.ToInt32(finalRes2);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;

                    case 3:
                        double finalRes3 = Medicine(math[i], science[i], english[i], essay[i]);
                        Console.WriteLine("The final average of student " + (i + 1) + " is: " + finalRes3);
                        averages[i] = Convert.ToInt32(finalRes3);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;

                    case 4:
                        double finalRes4 = Physics(math[i], science[i], english[i], essay[i]);
                        Console.WriteLine("The final average of student " + (i + 1) + " is: " + finalRes4);
                        averages[i] = Convert.ToInt32(finalRes4);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;

                    case 5:
                        double finalRes5 = Letters(math[i], science[i], english[i], essay[i]);
                        Console.WriteLine("The final average of student " + (i + 1) + " is: " + finalRes5);
                        averages[i] = Convert.ToInt32(finalRes5);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;

                    case 6:
                        double finalRes6 = PE(math[i], science[i], english[i], essay[i]);
                        Console.WriteLine("The final average of student " + (i + 1) + " is: " + finalRes6);
                        averages[i] = Convert.ToInt32(finalRes6);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("\nDo you want to continue? (yes/no)");
                        string respo7 = Console.ReadLine().ToLower();
                        if (respo7 == "yes")
                        {
                            goto inicio;
                        }

                        else
                        {
                            Console.WriteLine("Thanks for using the Grading System!");
                        }
                            Console.ReadLine();
                        break;
                }
            }

            inicio2:
            Console.Clear();
            Console.WriteLine("---Class grade---");

            for (int i = 0; i<totalStudents; i++)
            {
                Console.WriteLine("Student " + (i+1) + ": " + averages[i]);
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("\nWould you like to manipulate/view the system in any of these ways?\n");
            Console.WriteLine("1. Approved/failed candidates\n2. Sort in ascending order\n3. Sort in descending order");
            Console.WriteLine("4. Highlight the highest/lowest grade");
            int response = Convert.ToInt32(Console.ReadLine());

            switch (response)
            {
                case 1:
                    for(int i = 0; i<totalStudents; i++)
                    {
                        if (averages[i] >= 700)
                        {
                            Console.Write("\nStudent " + (i + 1) + ": " + averages[i] + " >>> ");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("APPROVED!\n");
                            Console.ResetColor();
                        }

                        else
                        {
                            Console.Write("\nStudent " + (i + 1) + ": " + averages[i] + " >>> ");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("FAILED!\n");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine("Do you want to: \n1. continue with the current grades and back to the last page? (a)");
                    Console.WriteLine("2. reiniciate the program? (b)\n3. close the program? (c)");
                    string respo = Console.ReadLine().ToLower();
                    if (respo == "a")
                    {
                        goto inicio2;
                    }

                    else if (respo == "b")

                    {
                        goto inicio;
                    }

                    else
                    {
                        Console.WriteLine("Thanks for using the Grading System!");
                    }
                    Console.ReadLine();
                    break;

                case 2:

                    Console.Clear();
                    Array.Copy(averages, averages2, totalStudents);
                    Array.Sort(averages2); 
                    Console.WriteLine("--Class Grade (Ascending Order)--");

                    for (int i = 0; i < totalStudents; i++)
                    {
                        Console.WriteLine("Student " + ((Array.BinarySearch(averages, averages2[i]) + 1) + ": " + averages2[i]));
                    }
                    Console.WriteLine("Do you want to: \n1. continue with the current grades and back to the last page? (a)");
                    Console.WriteLine("2. reiniciate the program? (b)\n3. close the program? (c)");
                    string respo1 = Console.ReadLine().ToLower();

                    if (respo1 == "a")
                    {
                        goto inicio2;
                    }

                    else if (respo1 == "b")

                    {
                        goto inicio;
                    }

                    else
                    {
                        Console.WriteLine("Thanks for using the Grading System!");
                    }
                    Console.ReadLine();
                    break;

                case 3:
                    Console.Clear();
                    Array.Copy(averages, averages2, totalStudents);
                    Array.Sort(averages2);
                    Array.Reverse(averages2);
                    Console.WriteLine("--Class Grade (Descending Order)--");
                    for (int i = 0; i < totalStudents; i++)
                    {
                        Console.WriteLine("Student " + ((Array.BinarySearch(averages, averages2[i]) + 1) + ": " + averages2[i]));
                    }
                    Console.WriteLine("---------------------------------");

                    Console.WriteLine("Do you want to: \n1. continue with the current grades and back to the last page? (a)");
                    Console.WriteLine("2. reiniciate the program? (b)\n3. close the program? (c)");
                    string respo2 = Console.ReadLine().ToLower();

                    if (respo2 == "a")
                    {
                        goto inicio2;
                    }

                    else if (respo2 == "b")

                    {
                        goto inicio;
                    }

                    else
                    {
                        Console.WriteLine("Thanks for using the Grading System!");
                    }
                    Console.ReadLine();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("---Class grade---");
                    Array.Copy(averages, averages2, totalStudents);
                    Array.Sort(averages2);

                    for (int i = 0; i < totalStudents; i++)
                    {
                        if (averages[i] == averages2[0])
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Student " + (i + 1) + ": " + averages[i]);
                            Console.ResetColor();
                        }

                        else if (averages[i] == averages2[averages2.GetUpperBound(0)])
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Student " + (i + 1) + ": " + averages[i]);
                            Console.ResetColor();
                        }

                        else
                        {
                            Console.WriteLine("Student " + (i + 1) + ": " + averages[i]);
                        }
 
                    }
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Do you want to: \n1. continue with the current grades and back to the last page? (a)");
                    Console.WriteLine("2. reiniciate the program? (b)\n3. close the program? (c)");
                    string respo4 = Console.ReadLine().ToLower();
                    if (respo4 == "a")
                    {
                        goto inicio2;
                    }

                    else if (respo4 == "b")

                    {
                        goto inicio;
                    }
                    else
                    {
                        Console.WriteLine("Thanks for using the Grading System!");
                    }
                    Console.ReadLine();
                    break;
          }
        }

        static double ComputerScience(double m, double s, double en, double es)
        {
            
            double average = ((m * 4) + (s * 3) + en + (es * 2)) / 10;
            return average;
        }

        static double Engineering(double m, double s, double en, double es)
        {
            double average = ((m * 5) + (s * 2) + en + (es * 2)) / 10;
            return average;
        }

        static double Medicine(double m, double s, double en, double es)
        {
            double average = ((m * 2) + (s * 5) + en + (es * 2)) / 10;
            return average;
        }

        static double Physics(double m, double s, double en, double es)
        {
            double average = ((m * 3) + (s * 5) + en + es) / 10;
            return average;
        }

        static double Letters(double m, double s, double en, double es)
        {
            double average = (m + s + (en * 5) + (es * 3)) / 10;
            return average;
        }

        static double PE(double m, double s, double en, double es)
        {
            double average = (m + (s * 4) + (en * 3) + es / 10);
            return average;
        }
    }
}
