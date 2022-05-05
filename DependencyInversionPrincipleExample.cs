// In this example high class depend of lower class for that reason it's not a dependency inversion 
// BAD IMPLEMENTATION OF DEPENDENCY INVERSION
public class Salary  //Low level chass or Object
 {  
     public float Salary(int hoursWorked, float hourlyRate) 
            => hoursWorked * hourlyRate;  
 }  
  
 public class Employee  //higl level class or  Object
 {  
     public int HoursWorked { get; set; }  
     public int HourlyRate { get; set; }  
     public float Salary()  
     {  
         var salaryCalculator = new Salary();  
         return salaryCalculator.Salary(HoursWorked, HourlyRate);  
     }  
 }  


//Following the principle
//GOOD IMPLEMENTATION
public interface Isalary  
{  
    float Salary(int hoursWorked, float hourlyRate);  
}  

public class SalaryCalculatorModified : Isalary  
{  
    public float Salary(int hoursWorked, float hourlyRate) 
        => hoursWorked * hourlyRate;  
}  

public class EmployeeDetailsModified  
{  
    private readonly Isalary _salary;  
    public int HoursWorked { get; set; }  
    public int HourlyRate { get; set; }  

    public EmployeeDetailsModified(Isalary salary)  
    {  
        _salary = salary;  
    }  
    public float Salary()  
    {  
        return _salaryCalculator.Salary(HoursWorked, HourlyRate);  
    }  
}  