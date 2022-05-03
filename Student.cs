using System;
namespace StudentManagementCLI
{
    public class Student
    {
        private int studentId;
        private string firstName;
        private string lastName;
        private string major;
        private double gpa;
        private string phone;
        private DateTime birthday;

        public Student(int studentId, string firstName, string lastName, string major, double gpa, string phone, DateTime birthday)
        {
            this.studentId = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.major = major;
            this.gpa = gpa;
            this.phone = phone;
            this.birthday = birthday;

        }

        public int getId() { return studentId; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getPhone() { return phone; }
        public string getMajor() { return major; }
        public double getGPA() { return gpa; }
        public DateTime getBirthday() { return birthday; }

        public override string ToString()
        {
            string s = "Student " + studentId;
            s = s + "\nName: " + firstName + " " + lastName;
            s = s + "\nMajor: " + major;
            s = s + "\nGPA: " + gpa.ToString();
            s = s + "\nPhone: " + phone;
            s = s + "\nBirthday: " + birthday.ToString("MMMM dd, yyyy");

            return s;
        }
    }
}
