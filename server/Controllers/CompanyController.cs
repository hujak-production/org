using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Infrastructure;
using Server.Model.Data;
using Server.Model.DTO;
using Server.Model.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [BasicAuthorization]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;

        public CompanyController(ILogger<CompanyController> logger, ApplicationDbContext context, ICompanyService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<object>> Create([FromBody] CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);

            var result = _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            long companyId = result.Entity.CompanyId;
            _logger.LogInformation("Company with id: {0} was created.", companyId);

            return new { Id = companyId };
        }

        [AllowAnonymous]
        [HttpPost("Search")]
        public ActionResult<object> Search(SearchCondition condition)
        {
            var companies = _service.Search(condition,  _context.Companies);

            _logger.LogInformation("Companies with ID:{0} have been found.",
                companies.Select(c => $"{c.CompanyId}"));

            var result = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return new { Results = result };
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] CompanyDto companyDto)
        {
            _logger.LogInformation("Update company with id: {0}.", id);

            if (_context.Companies.All(e => e.CompanyId != id))
            {
                _logger.LogWarning("Company with id: {0} wasn't found.", id);
                return NotFound();
            }

            Company update = _mapper.Map<Company>(companyDto);

            Company updatedEntry = await _context.Companies
                .Include(c => c.Employees)
                .FirstAsync(c => c.CompanyId == id);

            _service.Update(ref updatedEntry, update);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Company with id: {0} was updated.", id);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Company>> Delete(long id)
        {
            _logger.LogInformation("Delete company with id: {0}", id);

            var company = await _context.Companies.FindAsync(id);
            if (company is null)
            {
                _logger.LogWarning("Company with id: {0} wasn't found.", id);
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Company with id: {0} was deleted.");
            return Ok();
        }
    }
}
