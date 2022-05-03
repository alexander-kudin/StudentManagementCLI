using System;
using System.IO;
namespace StudentManagementCLI
{
    public class StudentManager
    {
        private static int currentCustNumber;
        private int maxNumStudents;
        private int numStudents;
        private Student[] studentList;

        public StudentManager(int ccn, int max)
        {
            currentCustNumber = ccn;
            maxNumStudents = max;
            numStudents = 0;
            studentList = new Student[maxNumStudents];
        }

        public bool addStudent(string fn, string ln, string major, double gpa, string phone, DateTime birthday)
        {
            if (numStudents >= maxNumStudents) { return false; }
            Student newStudent = new Student(currentCustNumber, fn, ln, major, gpa, phone, birthday);
            currentCustNumber++;
            studentList[numStudents] = newStudent;
            numStudents++;
            return true;
        }

        public int findStudent(int studentId)
        {
            for (int x = 0; x < numStudents; x++)
            {
                if (studentList[x].getId() == studentId) { return x; }
            }
            return -1;
        }

        public bool studentExist(int studentId)
        {
            int loc = findStudent(studentId);
            if (loc == -1) { return false; }
            return true;
        }

        public Student getStudent(int studentId)
        {
            int loc = findStudent(studentId);
            if (loc == -1) { return null; }
            return studentList[loc];
        }

        public string getStudentInfo(int studentId)
        {
            int loc = findStudent(studentId);
            if (loc == -1) { return "There is no student with id " + studentId + "."; }
            return studentList[loc].ToString();
        }

        public bool deleteStudent(int studentId)
        {
            int loc = findStudent(studentId);
            if (loc == -1) { return false; }
            studentList[loc] = studentList[numStudents - 1];
            numStudents--;
            return true;
        }

        public void saveDataToFile()
        {
            using (TextWriter tw = new StreamWriter("session_data.txt"))
            {
                tw.WriteLine(String.Format("\n   {0,-14} {1,-18} {2,-18} {3,-20} {4,-15}", "Student ID", "First Name", "Last Name", "Major", "Birthday"));
                tw.WriteLine(String.Format("\n   {0,-14} {1,-18} {2,-18} {3,-20} {4,-15}", "----------", "----------", "---------", "-----", "--------\n"));

                for (int x = 0; x < numStudents; x++)
                {
                    tw.WriteLine(String.Format("\n   {0,-14} {1,-18} {2,-18} {3,-20} {4,-15}", studentList[x].getId(), studentList[x].getFirstName(), studentList[x].getLastName(), studentList[x].getMajor(), studentList[x].getBirthday().ToString("MMMM dd, yyyy")));
                }
            }
        }

        public string getStudentList()
        {
            Console.Clear();

            string s = String.Format("\n   {0,-14} {1,-18} {2,-18} {3,-20} {4,-15}", "Student ID", "First Name", "Last Name", "Major", "Birthday");
             s = s + String.Format("\n   {0,-14} {1,-18} {2,-18} {3,-20} {4,-15}", "----------", "----------", "---------", "-----", "--------\n");

            for (int x = 0; x < numStudents; x++)
            {
                s = s + String.Format("\n   {0,-14} {1,-18} {2,-18} {3,-20} {4,-15}", studentList[x].getId(), studentList[x].getFirstName(), studentList[x].getLastName(), studentList[x].getMajor(), studentList[x].getBirthday().ToString("MMMM dd, yyyy"));
            }
            return s;
        }


    }
}
