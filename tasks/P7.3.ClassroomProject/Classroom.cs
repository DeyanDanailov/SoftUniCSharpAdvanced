using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        private List<Student> students;
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.students.Count;
            }
        }
        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            foreach (var student in this.students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    this.students.Remove(student);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }
            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var cnt = 0;
            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in this.students)
            {
                if (student.Subject == subject)
                {
                    cnt++;
                    sb.AppendLine($"{ student.FirstName} { student.LastName}");
                }
            }
            if (cnt == 0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                return sb.ToString().TrimEnd();
            }
        }
        public int GetStudentsCount()
        {
            return this.students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            foreach (var student in this.students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return student;
                }
            }
                return null;
        }
    }
}
