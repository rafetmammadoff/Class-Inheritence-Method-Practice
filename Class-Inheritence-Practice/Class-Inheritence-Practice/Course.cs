using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Inheritence_Practice
{
    internal class Course
    {
        public Teacher[] Teachers = new Teacher[0];
        public Group[] Groups = new Group[0];
        private int _odenis = 5000;
        public int Odenis
        {
            get { return _odenis; }
        }

        public void AddTeacher(Teacher teacher)
        {
            Array.Resize(ref Teachers, Teachers.Length+1);
            Teachers[Teachers.Length - 1] = teacher;
        }

        public void AddGroup(Group group)
        {
            if (CheckUnicGroupNo(group))
            {
                Array.Resize(ref Groups, Groups.Length + 1);
                Groups[Groups.Length - 1] = group;
            }
        }

        public bool CheckUnicGroupNo(Group group)
        {
            for (int i = 0; i < Groups.Length; i++)
            {
                if (Groups[i].GroupName==group.GroupName)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
