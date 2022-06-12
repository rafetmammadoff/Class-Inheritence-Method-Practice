using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Inheritence_Practice
{
    internal class Group
    {
        public string GroupName;
        private Teacher[] _groupTeachers=new Teacher[0];
        private Student[] _students = new Student[0];
        private int StudentLimit = 18;
        public Student[] Students
        {
            get { return _students; }
        }
        public Teacher[] GroupTeacher
        {
            get { return _groupTeachers; }
        }
        public void AddStudent(Student student)
        {
            if (_students.Length<StudentLimit)
            {
                Array.Resize(ref _students, _students.Length + 1);
                _students[_students.Length - 1] = student;
            }
        }
        public void AddTeacher(Teacher teacher)
        {
                Array.Resize(ref _groupTeachers, _groupTeachers.Length + 1);
            _groupTeachers[_groupTeachers.Length - 1] = teacher;
        }
        public static bool CheckGroupNo(string groupNo)
        {
            if (!String.IsNullOrWhiteSpace(groupNo) && groupNo.Length==4 && Char.IsLetter(groupNo[0]))
            {
                for (int i = 1; i < groupNo.Length; i++)
                {
                    if (!Char.IsDigit(groupNo[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
