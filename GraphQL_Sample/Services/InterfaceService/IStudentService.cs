using GraphQL_Sample.Models;

namespace GraphQL_Sample.PresentationLayer.InterfaceService;

public interface IStudentService
{
    Task<IQueryable<StudentModel>> GetAll();
    Task<IQueryable<StudentModel>> GetStudentByGroupId(int groupID);
    Task<StudentModel?> CreateStudent(StudentModel request);
    Task<StudentModel?> DeleteStudent(StudentModel request);
    Task<StudentModel?> UpdateStudent(StudentModel request);
}