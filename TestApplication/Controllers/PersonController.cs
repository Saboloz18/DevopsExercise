using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly MyAppContext _dbContext;

        public PersonController(MyAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _dbContext.Person.ToList();
        }
    }
}
