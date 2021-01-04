using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<CourseStudent>();
    }

    public int StudentId { get; set; }
    public string Name { get; set; }
    public string EnrollmentDate { get; set; }

    public ICollection<CourseStudent> Courses { get; }
  }
}