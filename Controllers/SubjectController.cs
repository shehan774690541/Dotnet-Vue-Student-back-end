using learnMySQL.DTOs.Request;
using learnMySQL.DTOs.Responces;
using learnMySQL.Services.StudentService;
using learnMySQL.Services.SubjectService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learnMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        public ISubjectService SubjectService;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public SubjectController(IConfiguration configuration, IWebHostEnvironment env, ISubjectService SubjectService)
        {
            this.SubjectService = SubjectService;
            this.configuration = configuration;
            this.env = env;
        }

        [HttpPost("save")]
        public BaseResponse CreateSubject(CreateSubjectRequest request)
        {
            return SubjectService.CreateSubject(request);
        }

        [HttpGet("List")]
        public BaseResponse SubjectList()
        {
            return SubjectService.SubjectList();
        }
    }

    
}
