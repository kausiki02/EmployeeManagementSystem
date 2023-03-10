namespace EmployeeManagement.Models
{
    public enum EType
    {
        Internal,
        External
    }
    public class Employee
    {
        public EType EmployeeType { get; set; }
       
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string Gender { get; set; }

        public string Role { get; set; }

        public string Skills { get; set; }

        public string Division { get; set; }

    }
}
