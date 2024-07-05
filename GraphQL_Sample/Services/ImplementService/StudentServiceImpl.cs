using GraphQL_Sample.Models;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using MySqlConnector;

namespace GraphQL_Sample.PresentationLayer.ImplementService;

public class StudentServiceImpl : IStudentService
{
    private IConfiguration _configuration;

    public StudentServiceImpl(IConfiguration configuration)
    {
        _configuration = configuration; 
    }
    public async Task<IQueryable<StudentModel>> GetAll()
    {
        List<StudentModel> listStudent = new List<StudentModel>();
        try
        {
            var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var command = new MySqlCommand("SELECT * FROM demo_sample.Student;", connection);
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                listStudent.Add(new StudentModel()
                {
                    StudentId = Int32.Parse(reader.GetValue(0).ToString() ?? "0"),
                    GroupId = Int32.Parse(reader.GetValue(2).ToString() ?? "0"),
                    Name = reader.GetValue(1).ToString()
                });
            }

            await connection.CloseAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }
        return listStudent.AsQueryable();
    }
    
    public async Task<IQueryable<StudentModel>> GetStudentByGroupId(int groupId)
    {
        List<StudentModel> listStudent = new List<StudentModel>();
        try
        {
            var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var command = new MySqlCommand("SELECT * FROM demo_sample.Student WHERE GroupId = @Groupd_Id;", connection);
            command.Parameters.AddWithValue("@Groupd_Id", groupId); 
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                listStudent.Add(new StudentModel()
                {
                    StudentId = Int32.Parse(reader.GetValue(0).ToString() ?? "0"),
                    GroupId = Int32.Parse(reader.GetValue(2).ToString() ?? "0"),
                    Name = reader.GetValue(1).ToString()
                });
            }
            await connection.CloseAsync();
        }
        catch (Exception)
        {
            throw new Exception();
        }   
        return listStudent.AsQueryable();
    }

    public async Task<StudentModel?> CreateStudent(StudentModel request)
    {
        try
        {
            var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var command = new 
                MySqlCommand(
                    "INSERT INTO `demo_sample`.`Student` ( `Name`, `GroupId`) VALUES ( @Student_Name, @Group_Id);", connection);

            command.Parameters.AddWithValue("@Student_Name", request.Name);
            command.Parameters.AddWithValue("@Group_Id", request.GroupId);
            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request; 
            }
            return null; 
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    public async Task<StudentModel?> DeleteStudent(StudentModel request)
    {
        try
        {
            var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var command = new 
                MySqlCommand(
                    "DELETE FROM `demo_sample`.`Student` WHERE StudentId = @Student_Id;", connection);
            command.Parameters.AddWithValue("@Student_Id", request.StudentId);
            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request; 
            }
            return null; 
        }
        catch (Exception)
        {
            throw new Exception(); 
        }
    }

    public async Task<StudentModel?> UpdateStudent(StudentModel request)
    {
        try
        {
            var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var command = new 
                MySqlCommand(
                    "UPDATE `demo_sample`.`Student` as tbStudent SET tbStudent.Name = @Student_Name WHERE StudentId = @Student_Id;", connection);

            command.Parameters.AddWithValue("@Student_Name", request.Name);
            command.Parameters.AddWithValue("@Student_Id", request.StudentId);
            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request; 
            }

            return null; 
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}