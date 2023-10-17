using learnMySQL.DTOs.Request;
using learnMySQL.DTOs.Responces;

namespace learnMySQL.Services.SubjectService
{
    public interface ISubjectService
    {
        BaseResponse CreateSubject(CreateSubjectRequest request);

        BaseResponse SubjectList();
    }
}
