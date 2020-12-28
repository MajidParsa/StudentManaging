using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManaging.Application.Commands;
using StudentManaging.Application.Query;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator) => 
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize]
        [Route("getStudentsAsync")]
        [HttpGet]
        public async Task<ActionResult<Student>> GetStudents(int? id)
        {
	        var student = await _mediator.Send(new GetStudentQuery(){Id = id});
	        if (student == null)
		        return NotFound("Record(s) not found!");

	        return Ok();
        }

        [Authorize]
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand addStudentCommand)
        {
            await _mediator.Send(addStudentCommand);
            return Ok();
        }

        [Authorize]
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand updateStudentCommand)
        {
	        await _mediator.Send(updateStudentCommand);
	        return Ok();
        }

        [Authorize]
        [HttpPost("DeleteAsync")]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand deleteStudentCommand)
        {
	        await _mediator.Send(deleteStudentCommand);
	        return Ok();
        }

    }
}