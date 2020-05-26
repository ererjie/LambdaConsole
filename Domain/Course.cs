using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaConsole.Domain
{
  public class Course
  {
    /// <summary>
    /// 课程名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 分数
    /// </summary>
    public decimal Score { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
  }
}
