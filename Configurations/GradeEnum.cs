using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaConsole.Configurations
{
  /// <summary>
  /// 成绩
  /// </summary>
  public enum GradeEnum
  {
    /// <summary>
    /// 优秀
    /// 成绩>90
    /// </summary>
    Great = 1,
    /// <summary>
    /// 优秀
    /// 成绩<75并且<90
    /// </summary>
    Good = 2,
    /// <summary>
    /// 一般
    /// 成绩>60并且<75
    /// </summary>
    Normal = 3,
    /// <summary>
    /// 不及格
    /// 成绩<60
    /// </summary>
    Flunk = 4
  }
}
