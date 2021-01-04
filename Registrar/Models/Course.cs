using System.Collections.Generic;

namespace Registrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<CourseStudent>();
    }

    public int CourseId { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public virtual ICollection<CourseStudent> Students { get; set; }
  }
}