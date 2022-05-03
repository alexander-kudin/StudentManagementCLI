// Student name: Aleksandr Kudin (101258693)
// Student name: Yamato Masuda (101280981)
// Institution: George Brown College
// Professor: Albert Danison
// Assignment Date: August 11, 2020
// CRN-80801-201903

// Updated: May 4, 2022 by Aleksandr Kudin

using System;

namespace StudentManagementCLI
{
    class MainClass
    {
        static StudentManager studentManager;

        // MAIN (init Stident Manager and add dummy data in it)
        public static void Main(string[] args)
        {
            studentManager = new StudentManager(1, 99);
            studentManager.addStudent("Aleksandr", "Kudin", "Computer Science", 3.8, "+1 000 000 0000", new DateTime(2001, 9, 1));
            printGreetingMessage();
            runProgram();
        }

        // Run program logic
        public static void runProgram()
        {
            string menu = mainMenu();
            int choice = getValidChoice(5, menu);
            while (choice != 5)
            {
                if (choice == 1) { addStudent(); }
                if (choice == 2) { viewStudents(); }
                if (choice == 3) { viewSpecificStudent(); }
                if (choice == 4) { deleteStudent(); }

                choice = getValidChoice(5, menu);
            }
            studentManager.saveDataToFile();
        }

        // Main Menu Content
        public static string mainMenu()
        {
            string s = "Modified Student Management System (Semester 2) by Alexander Kudin.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Student \n";
            s += "2: View Students \n";
            s += "3: View Student Details \n";
            s += "4: Delete Student \n";
            s += "5: Exit";
            return s;
        }

        // Main Menu Input Validation
        public static int getValidChoice(int max, string menu)
        {
            int choice;
            Console.Clear();
            Console.WriteLine(menu);
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > max))
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.WriteLine("Please enter a valid choice:");
            }
            return choice;
        }

        // Print student list from main menu
        public static void viewStudents()
        {
            Console.Clear();
            Console.WriteLine(studentManager.getStudentList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        // Print student details info from main menu
        public static void viewSpecificStudent()
        {
            int id;
            string studentInfoSelected;
            Console.Clear();
            Console.WriteLine(studentManager.getStudentList());
            Console.Write("Please enter a student id to View:");
            id = getIntChoice();
            Console.Clear();
            studentInfoSelected = studentManager.getStudentInfo(id);
            Console.WriteLine(studentInfoSelected);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        // Add student from main menu
        public static void addStudent()
        {
            string firstName, lastName, major, phone;
            int day, month, year;
            double gpa;
            DateTime birthday;

            Console.Clear();
            Console.WriteLine("-----------Add Student----------");
            Console.Write("Please enter the student's first name:");
            firstName = Console.ReadLine();
            Console.Write("Please enter the student's last name:");
            lastName = Console.ReadLine();
            Console.Write("Please enter the student's major:");
            major = Console.ReadLine();
            Console.Write("Please enter the student's phone number:");
            phone = Console.ReadLine();
            Console.Write("Please enter the student's GPA:");
            gpa = getDoubleChoice();
            Console.Write("Please enter the DAY of the student's birthday (as an integer):");
            day = getIntChoice();
            Console.Write("Please enter the MONTH of the student's birthday (as an integer):");
            month = getIntChoice();
            Console.Write("Please enter the YEAR of the student's birthday (as an integer):");
            year = getIntChoice();

            birthday = new DateTime(year, month, day);
            if (studentManager.addStudent(firstName, lastName, major, gpa, phone, birthday))
            {
                Console.WriteLine("Student has been successfully added..");
            }
            else
            {
                Console.WriteLine("Student was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        // Delete student from main menu
        public static void deleteStudent()
        {
            int id;
            Console.Clear();
            Console.WriteLine(studentManager.getStudentList());
            Console.Write("Please enter a student id to delete:");
            id = getIntChoice();
            if (studentManager.deleteStudent(id))
            {
                Console.WriteLine("Student with id {0} deleted..", id);
            }
            else
            {
                Console.WriteLine("Student with id {0} was not found..", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        // Integer Input Validation
        public static int getIntChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0)
            {
                if (choice <= 0) { Console.WriteLine("Integer must be positive:"); }
                else { Console.WriteLine("Please enter an integer:"); }
            }
            return choice;
        }

        // Double Input Validation
        public static double getDoubleChoice()
        {
            double choice;
            while (!double.TryParse(Console.ReadLine(), out choice) || choice < 0)
            {
                if (choice <= 0) { Console.WriteLine("Double must be positive:"); }
                else { Console.WriteLine("Please enter a double:"); }
            }
            return choice;
        }


        public static void printGreetingMessage()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("Student: Aleksandr Kudin 101258693");
            Console.WriteLine("Student: Yamato Masuda 101280981");
            Console.WriteLine("Institution: George Brown College");
            Console.WriteLine("CRN: 80801-201903");
            Console.WriteLine("Professor: Albert Danison");
            Console.WriteLine("Date: August 11, 2020");
            Console.WriteLine("Assignment 2 Student Management System");
            Console.WriteLine();
            Console.WriteLine("Description:");
            Console.WriteLine();
            Console.WriteLine("The user will have an access to the database which contains examples ");
            Console.WriteLine("of the student data. The user will be able to store and manage");
            Console.WriteLine("students data.");
            Console.WriteLine();
            Console.WriteLine("Functions avaliability:");
            Console.WriteLine();
            Console.WriteLine("Function 1. Display students list");
            Console.WriteLine("Function 2. Filter student list ");
            Console.WriteLine("Function 3. Add new student data");
            Console.WriteLine("Function 4. Erase student data");
            Console.WriteLine("Function 5. Edit student data");
            Console.WriteLine("Function 6. Search for a student");
            Console.WriteLine();
            Console.WriteLine("Privacy:");
            Console.WriteLine();
            Console.WriteLine("After the application is terminated all the session information will be saved");
            Console.WriteLine("on the user's device. After creating a new session, the information from");
            Console.WriteLine("the previous session will be erased and new session data will be stored.");
            Console.WriteLine();
            Console.WriteLine("Academic Honesty:");
            Console.WriteLine();
            Console.WriteLine("Aleksandr and Yamato, we guarantee that this program is our origin work.");
            Console.WriteLine("Aleksandr and Yamato, we have not given other student(s) access to our program.");
            Console.WriteLine();
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


    }
}
