using LambdaConsole.Configurations;
using LambdaConsole.Domain;
using LambdaConsole.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using static LambdaConsole.Dto.StudentItemDto;

namespace LambdaConsole
{
    class Program
    {
        static List<Students> students = new List<Students>();//所有学生信息
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetStudentDrop();
        }

        /// <summary>
        /// 1. 初始化数据,将值赋值给students
        /// 学生信息有：
        /// 小李：男，生日：2019-01-02
        /// 小花：女，生日：2017-03-03
        /// 小刘：女，生日：2017-03-27
        /// </summary>
        static void InitStudentData()
        {
            Students studentsXiaoLi = Students.Create("小李", true, DateTime.Parse("2019-01-02"));//通过静态方法初始化
            Students studentsXiaoHua = new Students("小花", false, DateTime.Parse("2017-03-03"));//通过有参构造函数初始化
            Students studentsXiaoLiu = new Students()//通过无参构造函数初始化并为对应属性赋值
            {
                Name = "小刘",
                Gender = false,
                Birthday = DateTime.Parse("2017-03-27"),
                CreateTime = DateTime.Now
            };
            Students studentsXiaoLiu2 = new Students();//通过声明无参构造函数，并且属性赋值
            studentsXiaoLiu2.Name = "小李";
            studentsXiaoLiu2.Gender = true;
            studentsXiaoLiu2.Birthday = DateTime.Parse("2018-09-29");

            students.Add(studentsXiaoLi);
            students.Add(studentsXiaoHua);
            students.Add(studentsXiaoLiu);


        }

        /// <summary>
        /// 2. 今天考试了，为其录入成绩
        /// 小李的学习成绩：语文：100，  数学：90 ,英语：89
        /// 小花的学习成绩：语文：50，  数学：49 ,英语：89
        /// 小刘的学习成绩：语文：80，  数学：100 ,英语：30
        /// </summary>
        static void JoinCourse()
        {
            var xiaoLi = students.Where(x => x.Name == "小李").FirstOrDefault();

            #region 第一种
            Course coursesYuWen = new Course()
            {
                Name = "语文",
                Score = 100,
            };
            Course coursesShuXue = new Course()
            {
                Name = "数学",
                Score = 90,
            };
            Course coursesYingYu = new Course()
            {
                Name = "英语",
                Score = 89,
            };
            xiaoLi.Courses.Add(coursesYuWen);
            xiaoLi.Courses.Add(coursesShuXue);
            xiaoLi.Courses.Add(coursesYingYu);
            #endregion

            #region 第二种
            xiaoLi.JoinCourse("语文", 100);
            #endregion

            var xiaoHua = students.Where(x => x.Name == "小花").FirstOrDefault();
            Course courseXiaoHuayuwen = new Course()
            {
                Name = "语文",
                Score = 50
            };
            Course courseXiaoHuashuxue = new Course()
            {
                Name = "数学",
                Score = 49
            };
            Course courseXiaoHuayingyu = new Course()
            {
                Name = "英语",
                Score = 89
            };

        }

        /// <summary>
        /// 3. 得到所有学生的基本信息
        /// 返回类型为List
        /// </summary>
        static List<StudentItemDto> GetStudentList()
        {
            List<StudentItemDto> studentItemDtos = students.Select(x => new StudentItemDto()
            {
                Name = x.Name,
                Birthday = x.Birthday,
                Grades = x.Courses.Select(y => new GradeItem()
                {
                    Name = y.Name,
                    Score = y.Score,
                    //Grade=y.Score>90? GradeEnum.Great :(y.Score>75?GradeEnum.Good:(y.Score>60?GradeEnum.Normal:GradeEnum.Flunk
                }).ToList()
            }).ToList();
            return studentItemDtos;
        }

        /// <summary>
        /// 4. 得到所有的女同学信息
        /// 返回类型为字典，key为学生名称，value为学生性别
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, bool> GetStudentDrop()
        {
            Dictionary<string, bool> keyValuePairs = new Dictionary<string, bool>();
            var info = students.Where(x => x.Gender == false).Select(x => new
            {
                x.Name,
                x.Gender
            }).ToList();
            info.ForEach(item =>
            {
                keyValuePairs.Add(item.Name, item.Gender);
            });

            return keyValuePairs;

        }

        /// <summary>
        /// 5. 得到所有的男同学信息
        /// 返回类型为List<KeyValuePair<string,bool>>，key为学生名称，value为学生性别
        /// </summary>
        /// <returns></returns>
        static List<KeyValuePair<string, bool>> GetStudentKeyPairList()
        {
            List<KeyValuePair<string, bool>> keyValuePairs = new List<KeyValuePair<string, bool>>();
            var infos = students.Where(x => x.Gender == true).Select(x => new
            {
                x.Name,
                x.Gender
            }).ToList();
            infos.ForEach(item =>
            {
                keyValuePairs.Add(new KeyValuePair<string, bool>(item.Name, item.Gender));
            });
            return keyValuePairs;
        }

        /// <summary>
        /// 6. 得到语文成绩为优秀的男同学信息
        /// </summary>
        /// <returns></returns>
        static List<StudentItemDto> GetGradeStudentList()
        {
            //得到男同学信息
            var boyStudents = students.Where(x => x.Gender == true).Select(x => new StudentItemDto()
            {
                Name=x.Name,
                Birthday=x.Birthday,
                Grades = x.Courses.Select(y => new GradeItem()
                {
                    Name = y.Name,
                    Score = y.Score,
                }).ToList()
            }).ToList();
            List<StudentItemDto> studentItems = new List<StudentItemDto>();
            boyStudents.ForEach(boyStudent =>
            {
              if ( boyStudent.Grades.Where(x => x.Score > 90 && x.Name == "语文").Select(x => new GradeItem()
                {
                  Name=x.Name,
                  Score=x.Score
              }).Count()>0)
                {
                    studentItems.Add(boyStudent);
                }

            });

            //通过成绩筛选出符合的人，但是人下面仍然有三门学科的成绩
            students.Where(x => x.Gender == true && x.Courses.Any(y => y.Score > 90 && y.Name == "语文")).Select(x => new StudentItemDto() {
                Name = x.Name,
                Birthday = x.Birthday,
                Grades = x.Courses.Where(y=>y.Name=="数学").Select(y => new GradeItem()
                {//这个是具体的数学学科成绩
                    Name = y.Name,
                    Score = y.Score,
                }).ToList()
            }).ToList();

            return studentItems;

        }
    }

}
