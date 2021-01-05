namespace Registrar.Models
{
  public class DepartmentStudent
  {
    public int DepartmentStudentId { get; set; }
    public int StudentId { get; set; }
    public int DepartmentId { get; set; }
    public Student Student { get; set; }
    public Department Department { get; set; }
  }
}