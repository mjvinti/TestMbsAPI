using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestMbsApi.Models;

namespace TestMbsApi.Controllers
{
    [Route("api/[controller]")]
    public class MbsController : Controller
    {
        private readonly MbsContext _context;

        public MbsController(MbsContext context)
        {
            _context = context;

            if (_context.MbsItems.Count() == 0)
            {
                _context.MbsItems.AddRange(new MbsItem { DocumentNum = "AbCd123", LatestRev = "A" },
                    new MbsItem { DocumentNum = "eFg456", LatestRev = "B" },
                    new MbsItem { DocumentNum = "HiJk789", LatestRev = "C" });
                _context.SaveChanges();
            }
        }

        // GET api/mbs
        [HttpGet]
        public IEnumerable<MbsItem> GetAll()
        {
            return _context.MbsItems.ToList();
        }

        // GET api/mbs/ABCD123
        [HttpGet("{documentNum}", Name = "GetMbs")]
        public IActionResult GetByDocumentName(string documentNum)
        {
            var mbsItem = _context.MbsItems.FirstOrDefault(t => t.DocumentNum.ToUpper() == documentNum);
            if (mbsItem == null)
            {
                return NotFound();
            }
            return new ObjectResult(mbsItem);
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
