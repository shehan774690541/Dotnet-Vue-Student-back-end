using learnMySQL.DTOs.Request;
using learnMySQL.DTOs.Responces;
using learnMySQL.DTOs;
using learnMySQL.Models;
using System;
using learnMySQL.Migrations;

namespace learnMySQL.Services.SubjectService
{
    public class subjectService : ISubjectService
    {
        public readonly ApplicationDbContext context;

        public subjectService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateSubject(CreateSubjectRequest request)
        {
            BaseResponse response;

            try
            {
                SubjectsModel newSubject = new SubjectsModel();
                
                newSubject.Subject = request.Subject;
                newSubject.Check = request.Check;

                using (context)
                {
                    context.Add(newSubject);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new
                    {
                        message = "Successful created the new subject"
                    }
                };

            }
            catch (Exception ex){
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new
                    {
                        message = "Internal server error : " + ex.Message
                    }
                };
            }

            return response;
        }
        public BaseResponse SubjectList()
        {
            BaseResponse response;
            try
            {
                List<SubjectDTO> subjects = new List<SubjectDTO>();

                using (context)
                {
                    context.Subjects.ToList().ForEach(subject => subjects.Add(new SubjectDTO
                    {
                        Id = subject.Id,
                        Subject = subject.Subject,
                        Check = subject.Check,
                    }));
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { subjects }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = ex.Message }
                };
            }

            return response;
        }

    }
}
