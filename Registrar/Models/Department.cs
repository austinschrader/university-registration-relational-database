using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<CourseStudent>();
    }

    public int DepartmentId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<CourseStudent> Courses { get; set; }
  }
}