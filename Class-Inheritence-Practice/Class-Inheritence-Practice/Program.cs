using Class_Inheritence_Practice.Exceptions;
using System;

namespace Class_Inheritence_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Class  Inheritence  Method 

            Course CodeAcademy = new Course();
            string option;
            Console.WriteLine("Code Academy-e xos geldiniz");
            do
            {
                Selection();
                option = Console.ReadLine();
                string secim = null;
                Group addingGroup = null;
                switch (option)
                {
                    case "1":
                        AddTeacherProcess(CodeAcademy);
                        break;
                    case "2":
                        AddGroupProcess(CodeAcademy);
                        break;
                    case "3":
                        try
                        {
                            GroupSelectStdAdd(CodeAcademy);
                        }
                        catch (EmptyException msg)
                        {
                            Console.WriteLine(msg.Message);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bilinmeyen xeta bas verdi");
                        }
                        secim = Console.ReadLine();
                         addingGroup=CheckHasGroupNo(CodeAcademy, secim);
                        CheckOdenis(addingGroup, CodeAcademy);
                        break;
                    case "4":
                        try
                        {
                            AddTeacherToGroup(CodeAcademy, secim, addingGroup);
                        }
                        catch (EmptyException exp)
                        {
                            Console.WriteLine(exp.Message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bilinmeyen xeta bas verdi");
                        }
                        break;
                    case "5":
                        try
                        {
                            ShowGroupStudents(CodeAcademy, secim, addingGroup);
                        }
                        catch (EmptyException exp)
                        {
                            Console.WriteLine(exp.Message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bilinmeyen xeta bas verdi");
                        }
                        break;
                    case "6":
                        try
                        {
                            ShowGroupTeachers(CodeAcademy, secim, addingGroup);
                        }
                        catch (EmptyException exp)
                        {
                            Console.WriteLine(exp.Message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bilinmeyen xeta bas verdi");
                        }
                        break;
                }
            } while (option != "7");
        }
        static void Selection()
        {
            Console.WriteLine(" ");
            Console.WriteLine("  -  1-Mellim elave edin");
            Console.WriteLine("  -  2-Group elave edin");
            Console.WriteLine("  -  3-Group-a telebe elave edin");
            Console.WriteLine("  -  4-Group-a mellim elave edin");
            Console.WriteLine("  -  5-Group-daki telebeleri goruntule");
            Console.WriteLine("  -  6-Group-un mellimlerini goruntule");
            Console.WriteLine("  -  7-Cixis edin");
        }
        static void AddTeacherProcess(Course CodeAcademy)
        {
            Console.WriteLine("Mellim adini daxil edin:");
            string tName = Console.ReadLine();
            Console.WriteLine("Mellim soyadini daxil edin:");
            string tSurName = Console.ReadLine();

            string ageStr;
            int tAge;
            do
            {
                Console.WriteLine("Mellim yasini daxil edin:");
                ageStr = Console.ReadLine();
            } while (!int.TryParse(ageStr, out tAge) || (tAge<18 || tAge>50));

            Console.WriteLine("Mellim pozisiyasini daxil edin:");
            string tPosition = Console.ReadLine();

            string salaryStr;
            int tSalary;
            do
            {
                Console.WriteLine("Mellim maasini daxil edin:");
                salaryStr = Console.ReadLine();
            } while (!int.TryParse(salaryStr,out tSalary) || tSalary<100);
            Teacher teacher = new Teacher()
            {
                Name = tName,
                Surname = tSurName,
                Age = tAge,
                Position = tPosition,
                Salary = tSalary
            };
            CodeAcademy.AddTeacher(teacher);
        }
        static void AddGroupProcess(Course CodeAcademy)
        {
            string groupNo;
            do
            {
                Console.WriteLine("Group adin daxil edin");
                groupNo = Console.ReadLine();
            } while (!Group.CheckGroupNo(groupNo));

            Group group = new Group()
            {
                GroupName = groupNo
            };
            CodeAcademy.AddGroup(group);
        }
        static Group CheckHasGroupNo(Course course, string groupNo)
        {
            for (int i = 0; i < course.Groups.Length; i++)
            {
                if (course.Groups[i].GroupName==groupNo)
                {
                    return course.Groups[i];
                }
            }
            return null;
        }
        static void StudentAddInfoProcess(Group addingGroup)
        {
            Console.WriteLine("Student adini daxil edin");
            string name = Console.ReadLine();
            Console.WriteLine("Student soyadini daxil edin");
            string surName = Console.ReadLine();
            Console.WriteLine("Student ata adini daxil edin");
            string fatherName = Console.ReadLine();
            
            int age;
            string ageStr;
            do
            {
                Console.WriteLine("Student yasini daxil edin");
                ageStr = Console.ReadLine();
            } while (!int.TryParse(ageStr,out age) || (age<15 || age>50));
            Student newStudent = new Student()
            {
                Name = name,
                Age = age,
                FatherName = fatherName,
                Surname = surName
            };
            addingGroup.AddStudent(newStudent);
        }
        static void GroupSelectStdAdd(Course course)
        {
            if (course.Groups.Length==0)
            {
                throw new EmptyException("Hal hazirda qrup yoxdur.Evvelce yeni qrup yaradin!!!");
                return; 
                
            }
            Console.WriteLine("Telebeni hansi qrupa elave etmek isteyirsiniz?(Asagidakilardan birin tam olaraq yazin)");
            for (int i = 0; i < course.Groups.Length; i++)
            {
                Console.WriteLine(course.Groups[i].GroupName);
            }
        }
        static void CheckOdenis(Group addingGroup,Course CodeAcademy)
        {
            if (addingGroup != null)
            {
                string optOdenis;
                do
                {
                    Console.WriteLine("Kursa daxil olmaq ucun Umumi mebleg 5000 manat");
                    Console.WriteLine("1- 6 ayliq kreditle odenis");
                    Console.WriteLine("2- Negd birdefelik odenis");
                    Console.WriteLine("3-Legv etmek");
                    optOdenis = Console.ReadLine();
                    switch (optOdenis)
                    {
                        case "1":
                            Console.WriteLine($"1-ci ayliq ucun odenis {CodeAcademy.Odenis / 6} manat");
                            string odenisStr;
                            int odenis;
                            do
                            {
                                Console.WriteLine("Odenisi daxil edin");
                                odenisStr = Console.ReadLine();
                            } while (!int.TryParse(odenisStr,out odenis));
                            if (odenis < CodeAcademy.Odenis / 6)
                            {
                                Console.WriteLine("Kursa yazilmaq ucun mebleg kifayet etmir");
                                break;
                            }
                            else
                            {
                                StudentAddInfoProcess(addingGroup);
                            }
                            return;
                        case "2":
                            Console.WriteLine($"Odenis 5000 manat");
                            do
                            {
                                Console.WriteLine("Odenisi daxil edin");
                                odenisStr = Console.ReadLine();
                            } while (!int.TryParse(odenisStr, out odenis));
                            if (odenis < CodeAcademy.Odenis)
                            {
                                Console.WriteLine("Kursa yazilmaq ucun mebleg kifayet etmir");
                                break;
                            }
                            else
                            {
                                StudentAddInfoProcess(addingGroup);
                            }
                            return;
                        default:
                            Console.WriteLine("Secim yanlisdir!!!!!!!!!!!!");
                            break;
                        case "3":
                            break;
                    }
                } while (optOdenis!="3");
            }
            else
            {
                Console.WriteLine("Bu adda qrup yoxdur");
            }
        }
        static void AddTeacherToGroup(Course CodeAcademy,string secim,Group addingGroup)
        {
            if (CodeAcademy.Groups.Length==0)
            {
                throw new EmptyException("Hal hazirda qrup yoxdur. Evvelce yeni qrup elave edin !!!");
            }
            else if (CodeAcademy.Teachers.Length == 0)
            {
                throw new EmptyException("Hal hazirda mellim yoxdur. Evvelce yeni mellim elave edin !!!");
            }
            
            int slctTeacher;
            string slctStr;
            do
            {
                Console.WriteLine("Elave etmek istediyiniz mellimi secin");
                for (int i = 0; i < CodeAcademy.Teachers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}- {CodeAcademy.Teachers[i].Name}");
                }
                slctStr = Console.ReadLine();
            } while (!int.TryParse(slctStr,out slctTeacher));
            Teacher teacher = null;
            for (int i = 0; i < CodeAcademy.Teachers.Length; i++)
            {
                if (i == slctTeacher - 1)
                {
                    teacher = CodeAcademy.Teachers[i];
                }
            }
            if (teacher != null)
            {
                Console.WriteLine("Mellimi hansi qrupa elave etmek isteyirsiniz?");
                for (int i = 0; i < CodeAcademy.Groups.Length; i++)
                {
                    Console.WriteLine(CodeAcademy.Groups[i].GroupName);
                }
                secim = Console.ReadLine();
                addingGroup = CheckHasGroupNo(CodeAcademy, secim);
                if (addingGroup != null)
                {
                    addingGroup.AddTeacher(teacher);
                }
            }
            
        }
        static void ShowGroupStudents(Course CodeAcademy, string secim, Group addingGroup)
        {
            if (CodeAcademy.Groups.Length==0)
            {
                throw new EmptyException("Group yoxdur !!! Yeni bir qrup yarada bilersiniz");
            }
            Console.WriteLine("Hansi qrupdaki telebeleri gormek isteyirsiniz");
            for (int i = 0; i < CodeAcademy.Groups.Length; i++)
            {
                Console.WriteLine(CodeAcademy.Groups[i].GroupName);
            }
            secim = Console.ReadLine();
            addingGroup = CheckHasGroupNo(CodeAcademy, secim);
            if (addingGroup != null)
            {
                for (int i = 0; i < addingGroup.Students.Length; i++)
                {
                    Console.WriteLine(addingGroup.Students[i].Name);
                }
            }
        }
        static void ShowGroupTeachers(Course CodeAcademy, string secim, Group addingGroup)
        {
            if (CodeAcademy.Groups.Length == 0)
            {
                throw new EmptyException("Hal hazirda qrup yoxdur. Elave ede bilersiniz.");
            }
            Console.WriteLine("Hansi qrupdaki mellimleri gormek isteyirsiniz");
            for (int i = 0; i < CodeAcademy.Groups.Length; i++)
            {
                Console.WriteLine(CodeAcademy.Groups[i].GroupName);
            }
            secim = Console.ReadLine();
            addingGroup = CheckHasGroupNo(CodeAcademy, secim);
            if (addingGroup != null)
            {
                for (int i = 0; i < addingGroup.GroupTeacher.Length; i++)
                {
                    Console.WriteLine(addingGroup.GroupTeacher[i].Name);
                }
            }
        }
    }
}
