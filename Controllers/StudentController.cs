using learnMySQL.DTOs.Request;
using learnMySQL.DTOs.Responces;
using learnMySQL.Services.StudentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learnMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentService studentService;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public StudentController(IStudentService studentService, IConfiguration configuration, IWebHostEnvironment env)
        {
            this.studentService = studentService;
            this.configuration = configuration;
            this.env = env;
        }

        [HttpPost("save")]
        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            return studentService.CreateStudent(request); 
        }

        [HttpGet("List")]
        public BaseResponse StudentList()
        {
            return studentService.StudentList();
        }

        [HttpGet("{id}")]
        public BaseResponse GetStudentId(long id) {
            return studentService.GetStudentById(id);
        }

        [HttpPut("{id}")]
        public BaseResponse UpdateStudentById(long id, UpdateStudentRequset request)
        {
            return studentService.UpdateStudentById(id,request);
        }

        [HttpDelete("{id}")]
        public BaseResponse DeleteStudentById(long id)
        {
            return studentService.DeleteStudentById(id);
        }

        



        //[HttpPost("uploadImage")]
        //public async Task<ActionResult> uploadImage()
        //{
        //    bool Results = false;
        //    try
        //    {
        //        var _uploadedfiles = Request.Form.Files;
        //        foreach (IFormFile source in _uploadedfiles) {
        //            string Filename = source.FileName;
        //            string Filepath = GetFilePath(Filename);

        //            if(!System.IO.Directory.Exists(Filepath))
        //            {
        //                System.IO.Directory.CreateDirectory(Filepath);
        //            }

        //            string imagepath = Filepath + "'\\img1.png";
        //            if(System.IO.File.Exists(imagepath))
        //            {
        //                System.IO.File.Delete(imagepath);
        //            }
        //            using (FileStream stream = System.IO.File.Create(imagepath))
        //            {
        //                await source.CopyToAsync(stream);
        //                Results = true;
        //            }
        //        }
        //    }catch (Exception ex)
        //    {

        //    }
        //    return Ok(Results);
        //}
        //[NonAction]
        //private string GetFilePath(string ProductCode)
        //{
        //    string ImageUrl = string.Empty;
        //    string HostUrl = "http://localhost:7055/";
        //    string filepath = GetFilePath(ProductCode);
        //    string Imagepath = "\\image.png";
        //    if (!System.IO.File.Exists(Imagepath))
        //    {
        //        ImageUrl = HostUrl + "/uploads/common/noImage.png";
        //    }
        //    else
        //    {
        //        ImageUrl = HostUrl + "/uploads/Product/" + ProductCode + "/";
        //    }
        //    return this.env.WebRootPath + "\\uploads\\Product\\" + ProductCode;

        //}
        //[HttpGet("GetAll")]
        //public async Task<List<ent>>

    }
}
