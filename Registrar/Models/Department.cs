using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<DepartmentCourse>();
    }

    public int DepartmentId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<DepartmentCourse> Courses { get; set; }
  }
}