using learnMySQL.DTOs.Request;
using learnMySQL.DTOs.Responces;
using learnMySQL.DTOs;
using learnMySQL.Models;
using System.Buffers.Text;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace learnMySQL.Services.StudentService
{
    public class StudentsService : IStudentService
    {
        public readonly ApplicationDbContext context;

        public StudentsService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            BaseResponse response;

            try
            {
                StudentModel newStudent = new StudentModel();

                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("HHmmssfff");
                Console.Write(formattedTime);
                string filePath = $"usr_{request.first_name}_{formattedTime}.png";
                
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(request.pic_url);
                    string file_Path = Path.Combine("wwwroot/uploads/", filePath);
                    System.IO.File.WriteAllBytes(file_Path, imageBytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving the image: ".ToUpper() + ex.Message.ToString());
                }
                newStudent.first_name = request.first_name;
                newStudent.last_name = request.last_name;
                newStudent.address = request.address;
                newStudent.email = request.email;
                newStudent.phone_number = request.phone_number;
                newStudent.pic_url = filePath;

                using (context)
                {
                    context.Add(newStudent);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created the new student" }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;
            }
        }
        public BaseResponse StudentList()
        {
            BaseResponse response;
            try
            {
                List<StudentDTO> students = new List<StudentDTO>();

                using (context)
                {
                    context.Students.ToList().ForEach(student => students.Add(new StudentDTO
                    {
                        Id = student.id,
                        first_name = student.first_name,
                        last_name = student.last_name,
                        address = student.address,
                        email = student.email,
                        phone_number = student.phone_number,
                        pic_url = student.pic_url,
                    }));
                }
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { students }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };
            }
            return response;
        }

        public BaseResponse GetStudentById(long id)
        {
            BaseResponse response;
            try
            {
                StudentDTO student = new StudentDTO();

                using (context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.id == id).FirstOrDefault();


                    if (filteredStudent != null)
                    {
                        student.Id = filteredStudent.id;
                        student.first_name = filteredStudent.first_name;
                        student.last_name = filteredStudent.last_name;
                        student.address = filteredStudent.address;
                        student.email = filteredStudent.email;
                        student.phone_number = filteredStudent.phone_number;
                        student.pic_url = filteredStudent.pic_url;
                    }
                    else
                    {
                        student = null;
                    }

                    if (student != null)
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { student }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status500InternalServerError,
                            data = new { message = "No student found" }
                        };
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error : " + ex.Message }
                };
                return response;
            }
        }

        public BaseResponse UpdateStudentById(long id, CreateStudentRequest request)
        {
            BaseResponse response;
            try
            {
                using (context)
                {
                    StudentModel filteredStudent = context.Students.FirstOrDefault(student => student.id == id);
                    if (filteredStudent != null)
                    {
                        Console.WriteLine("started!");
                        
                        DateTime currentTime = DateTime.Now;
                        string formattedTime = currentTime.ToString("HHmmssfff");
                        Console.Write(formattedTime);
                        string pic_name = $"usr_{request.first_name}_{formattedTime}.png";

                        string old_pic = request.pic_url.Split('~')[0];
                        string pic_content = request.pic_url.Split('~')[1];

                            try
                            {
                                if (pic_content != " ")
                                {
                                    File.Delete("wwwroot/uploads/" + old_pic);
                                }
                            }
                            catch{ }

                        try
                        {
                            if (pic_content == " ")
                            {
                                pic_name = old_pic;
                            }
                            else
                            {
                                byte[] imageBytes = Convert.FromBase64String(pic_content);
                                string file_Path = Path.Combine("wwwroot/uploads/", pic_name);
                                System.IO.File.WriteAllBytes(file_Path, imageBytes);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error saving the image: ".ToUpper() + ex.Message.ToString());
                        }

                        filteredStudent.first_name = request.first_name;
                        filteredStudent.last_name = request.last_name;
                        filteredStudent.address = request.address;
                        filteredStudent.email = request.email;
                        filteredStudent.phone_number = request.phone_number;
                        filteredStudent.pic_url = pic_name;

                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student updated successfully." }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status500InternalServerError,
                            data = new { message = "Student not found" }
                        };
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error : " + ex.Message }
                };
                return response;
            }
        }
        public BaseResponse DeleteStudentById(long id)
        {
            BaseResponse response;
            try
            {
                using (context)
                {
                    StudentModel studentToDelete = context.Students.Where(student => student.id == id).FirstOrDefault();

                    if(studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new {message = "Student deleted successfully."}
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                        };
                    }

                    return response;
                };
            }
            catch(Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };
                return response;
            }
        }



    }
}
