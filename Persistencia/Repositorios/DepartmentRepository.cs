using Microsoft.EntityFrameworkCore;

public class DepartmentRepository
{
    private readonly GraphQLDbContext _sampleAppDbContext;
    public DepartmentRepository(GraphQLDbContext sampleAppDbContext)
    {
        _sampleAppDbContext = sampleAppDbContext;
    }

    public List<Department> GetAllDepartmentOnly()
    {
        return _sampleAppDbContext.Department.ToList();
    }

    public List<Department> GetAllDepartmentsWithEmployee()
    {
        return _sampleAppDbContext.Department
            .Include(d => d.Employees)
            .ToList();
    }

    public async Task<Department> CreateDepartment(Department department)
    {
        await _sampleAppDbContext.Department.AddAsync(department);
        await _sampleAppDbContext.SaveChangesAsync();
        return department;
    }
}