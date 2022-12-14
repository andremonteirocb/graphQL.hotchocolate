using HotChocolate.Subscriptions;

public class Query
{
    public List<Employee> AllEmployeeOnly([Service] EmployeeRepository employeeRepository) =>
        employeeRepository.GetEmployees();

    public List<Employee> AllEmployeeWithDepartment([Service] EmployeeRepository employeeRepository) =>
        employeeRepository.GetEmployeesWithDepartment();

    public async Task<Employee> GetEmployeeById([Service] EmployeeRepository employeeRepository,
        [Service] ITopicEventSender eventSender, int id)
    {
        Employee gottenEmployee = employeeRepository.GetEmployeeById(id);
        await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
        return gottenEmployee;
    }

    public List<Department> AllDepartmentsOnly([Service] DepartmentRepository departmentRepository) =>
        departmentRepository.GetAllDepartmentOnly();

    public List<Department> AllDepartmentsWithEmployee([Service] DepartmentRepository departmentRepository) =>
        departmentRepository.GetAllDepartmentsWithEmployee();
}