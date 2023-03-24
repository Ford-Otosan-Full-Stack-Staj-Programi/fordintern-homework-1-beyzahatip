using Homework1.Data;
using Homework1.Data.Model;
using Microsoft.AspNetCore.Mvc;
using static Homework1.Web.FluentValidation.FluentValidation;

namespace Homework1.Web.Controllers
{
    [Route("ford/api/v1.0/[Controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public StaffController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Staff> GetAll()
        {
            List<Staff> staffList = unitOfWork.StaffRepository.GetAll();
            return staffList;
        }

        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            Staff staff = unitOfWork.StaffRepository.GetByID(id);
            return staff;
        }


        [HttpPost]
        public IActionResult AddStaff([FromBody] Staff request)
        {
            var Validator = new StaffValidator();
            var res=Validator.Validate(request);

            if (res.IsValid)
            {
                unitOfWork.StaffRepository.Insert(request);
                unitOfWork.Complete();
                return Ok(request);
            }
            var errorMessage = res.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStaff([FromBody] Staff request, [FromRoute] int id)
        {
            var Validator = new StaffValidator();
            var res = Validator.Validate(request);

            if (res.IsValid)
            {
                request.Id = id;
                unitOfWork.StaffRepository.Update(request);
                unitOfWork.Complete();
                GetAll();
                return Ok(request);
            }
            var errorMessage = res.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessage);


        }
        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            Staff staff = GetAll().Where(x => x.Id == id).FirstOrDefault();
            unitOfWork.StaffRepository.Remove(staff);
            unitOfWork.Complete();
            GetAll();
        }

        [HttpGet("/filter")]
        public List<Staff> GetByFilter([FromQuery]string city, [FromQuery] string province )
        {
            List<Staff> filterList = unitOfWork.Filter(city, province);
            return filterList;
        }

    }
}
