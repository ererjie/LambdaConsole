using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaConsole.Domain
{
  /// <summary>
  /// 班级
  /// </summary>
  public class ClassAndGrade
  {
    /// <summary>
    /// 班级名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool IsDel { get; set; }
  }
}
