using learnMySQL.DTOs.Request;
using learnMySQL.DTOs.Responces;

namespace learnMySQL.Services.StudentService
{
    public interface IStudentService
    {
        BaseResponse CreateStudent(CreateStudentRequest request);

        BaseResponse StudentList();

        BaseResponse GetStudentById(long id);

        BaseResponse UpdateStudentById(long id, CreateStudentRequest request);

        BaseResponse DeleteStudentById(long id);

        //BaseResponse save_picture(IFormFile file);


    }
}
