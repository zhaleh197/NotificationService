using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Service.User.Proj;
using Notification.Application.Service.WriteRepository.User.Proj.Kat;
using Notification.Application.Service.WriteRepository.User.Proj.Kat.SarKhat;

namespace NotificationAPICQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ProjectController : Controller
    {
         
        private readonly IUserProjects _userProjects;
        private readonly IKhat _khat;
        private readonly ISarKhat _sarKhat;
        private readonly ILogger<ProjectController> _logger;
        public ProjectController(IUserProjects userProjects, ISarKhat sarKhat, IKhat khat, ILogger<ProjectController> logger)
        {
            _userProjects = userProjects;
            _khat = khat;
             _sarKhat=sarKhat;
            _logger = logger;
        }
        /// /////PROJECT 
        [HttpGet]
        public IActionResult getallpro()
        {
            _logger.LogInformation("get all pro");
            return Ok(_userProjects.GetAllPro());
        }

        [HttpGet("{id}")]
        public IActionResult getprobyid([FromRoute] long id)
        { 
            _logger.LogInformation("get pro {0}", id);
            return Ok(_userProjects.GetprobyId(id));
        }

        [HttpGet("{id}")]
        public IActionResult getprobyiduser([FromRoute] long id)
        {
            _logger.LogInformation("get pro by {0}", id);
            return Ok(_userProjects.GetprobyIdUser(id));
        }

        [HttpPost]
        public IActionResult AddPro(ProjModel p)
        {
            long i=_userProjects.AddPro(p);

            _logger.LogInformation("add pro {0}", i);
            return Ok(i);
        }
         
        [HttpDelete("{id}")]
        public IActionResult DeletePro([FromRoute] long id)
        {
           long d= _userProjects.DeletPro(id);    

            _logger.LogInformation(" Delete pro {0}", d);
            return Ok(d);
        }

        ///////////////////////////////////
        //KHAT//
        [HttpGet]
        public IActionResult getallkhat()
        {
            _logger.LogInformation("get all khat");
            return Ok(_khat.GetAllKhat());
        }
        [HttpGet("{id}")]
        public IActionResult getkhatbyid([FromRoute] long id)
        {
            _logger.LogInformation("get khat {0}", id);
            return Ok(_khat.GetKhatbyId(id));
        }

        [HttpGet("{id}")]
        public IActionResult getkhatbyidpro([FromRoute] long id)
        {
            _logger.LogInformation("get khat by {0} pro", id);
            return Ok(_khat.GetKhatbyIdPro(id));
        }

        [HttpPost]
        public IActionResult Addkhat(KhatModel p)
        {
            long i = _khat.AddKhat(p);

            _logger.LogInformation("add khat {0}", i);
            return Ok(i);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletekhat([FromRoute] long id)
        {
            long d = _khat.DeletKhat(id);

            _logger.LogInformation(" Delete khat {0}", d);
            return Ok(d);
        }

        /////////////////////////////////////////////////
        ///
           //SarKHAT//
        [HttpGet]
        public IActionResult getallSarkhat()
        {
            _logger.LogInformation("get all Sarkhat");
            return Ok(_sarKhat.GetAllsarKhat());
        }

        [HttpPost]
        public IActionResult Addsarkhat(SarKhatModel p)
        {
            long i = _sarKhat.AddSarKhat(p);

            _logger.LogInformation("add sarkhat {0}", i);
            return Ok(i);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletesarkhat([FromRoute] long id)
        {
            long d = _sarKhat.DeletsarKhat(id);

            _logger.LogInformation(" Delete sarkhat {0}", d);
            return Ok(d);
        }

    }
}
