using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.User.Proj;
using Notification.Application.Service.WriteRepository.User.Kat;
using Notification.Application.Service.WriteRepository.User.Kat.SarKhat; 


namespace NotificationAPICQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ProjectController : Controller
    {
         
        private readonly IUserProjects _userProjects;
        private readonly IUserDoc _userDoc;
        private readonly IKhat _khat;
        private readonly ISarKhat _sarKhat;
        private readonly ILogger<ProjectController> _logger;
        public ProjectController(IUserProjects userProjects, IUserDoc userDoc, ISarKhat sarKhat, IKhat khat, ILogger<ProjectController> logger)
        {
            _userProjects = userProjects;
            _userDoc = userDoc;
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
        public IActionResult AddPro(ADDProjModel p)
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

       
        /// <summary>
        /// //SarKHAT//
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        //SarKHAT//

        //in API Adi baashad.

        /////
        //SarKHAT//

        //in API Adi baashad.
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


        /// <summary>
        ///  in mediator bashad
        /// </summary>
        /// <returns></returns>

        ///////////////////////////////////
        ////KHAT//
        [HttpGet]
        public IActionResult getallkhat()
        {
            _logger.LogInformation("get all khat");
          return Ok(_khat.GetAllKhatUsers());
             
        }
        [HttpGet]
        public IActionResult GetAllKhatOmoomi()
        {
            _logger.LogInformation("get all khat"); 
            return Ok(_khat.GetAllKhatOmoomi());
        }

        [HttpGet]
        public IActionResult GetAllKhatKhososiProperties()
        {
            _logger.LogInformation("get all khat");
            return Ok(_khat.GetAllKhatKhososiProperties());
          
        }

        [HttpGet]
        public IActionResult GetKhatKhososibyJustLenghofkhat(int lenghofkhat)
        {
            _logger.LogInformation("get all khat");
            return Ok(_khat.GetKhatKhososibyJustLenghofkhat(lenghofkhat));

        }

        [HttpGet]
        public IActionResult GetKhatKhososibySarkhat(string sarkhat)
        {
            _logger.LogInformation("get all khat");
            return Ok(_khat.GetKhatKhososibySarkhat(sarkhat));

        }

        [HttpGet]
        public IActionResult GetPricekhossosibysarkhatandlenghNumber([FromBody]PriceKhatkhososiREquest priceKhatkhososiREquest)
        {
            _logger.LogInformation("get all khat");
            return Ok(_khat.GetPricekhossosibysarkhatandlenghNumber(priceKhatkhososiREquest));

        }

        [HttpGet("{id}")]
        public IActionResult getkhatbyiduser([FromRoute] long id)
        {
            _logger.LogInformation("get khat {0}", id);
            return Ok(_khat.GetKhatbyIdUser(id)); 
        }

        [HttpGet("{id}")]
        public IActionResult getkhatbyidkhat([FromRoute] long id)
        {
            _logger.LogInformation("get khat by {0} pro", id);
            return Ok(_khat.GetKhatbyId(id));
        }

        [HttpGet]
        public IActionResult getalltypeDocs()
        {
            _logger.LogInformation("getgetalltypeDocs");
            return Ok(_userDoc.getalltypeDocs());
        }


        [HttpGet]
        public IActionResult getalltypeuser()
        {
            _logger.LogInformation("getgetalltypeDocs");
            return Ok(_userProjects.Gettypeuser());
        }


        [HttpGet]
        public IActionResult getalltypepackage()
        {
            _logger.LogInformation("getgetalltypeDocs");
            return Ok(_userProjects.GetPackageTariff());
        }


        // in mediator coded.


        //[HttpPost]
        //public IActionResult Addkhat(KhatModel p)
        //{
        //    long i = _khat.AddKhat(p);

        //    _logger.LogInformation("add khat {0}", i);
        //    return Ok(i);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Deletekhat([FromRoute] long id)
        //{
        //    long d = _khat.DeletKhat(id);

        //    _logger.LogInformation(" Delete khat {0}", d);
        //    return Ok(d);
        //}

        ///////////////////////////////////////////////////
        ///// 
    }
}
