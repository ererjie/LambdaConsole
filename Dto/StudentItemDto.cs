using LambdaConsole.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaConsole.Dto
{
  class StudentItemDto
  {
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<GradeItem> Grades { get; set; }

    /// <summary>
    /// 学习成绩
    /// </summary>
    public class GradeItem
    {
      /// <summary>
      /// 课程名称
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// 成绩
      /// </summary>
      public decimal Score { get; set; }

      /// <summary>
      /// 等级
      /// </summary>
      public GradeEnum Grade { get
        {
          if (this.Score > 90)
          {
           return GradeEnum.Great;
          }
          else if (this.Score>75)
          {
            return GradeEnum.Good;
          }
          else if (this.Score>60)
          {
            return GradeEnum.Normal;
          }
          else
          {
            return GradeEnum.Flunk;
          }
        }
      }
    }
  }
}
