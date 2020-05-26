using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaConsole.Domain
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Students
    {

        public Students()
        {
            this.CreateTime = DateTime.Now;
            this.Courses = new List<Course>();
        }

        public Students(string name, bool gender, DateTime birthday) : this()
        {
            this.Name = name;
            this.Gender = gender;
            this.Birthday = birthday;
        }

        public Students(string name, bool gender) : this()
        {
            this.Name = name;
            this.Gender = gender;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 学生课程
        /// </summary>
        public List<Course> Courses { get; set; }

        public static Students Create(string name, bool gender, DateTime birthday)
        {
            return new Students()
            {
                Name = name,
                Gender = gender,
                Birthday = birthday,
            };
        }

        /// <summary>
        /// 参加课程
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void JoinCourse(string name, decimal score)
        {
            this.Courses.Add(new Course()
            {
                Name = name,
                Score = score
            });
        }
    }
}
