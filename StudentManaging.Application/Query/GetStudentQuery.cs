using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Application.Query
{
	public class GetStudentQuery : IRequest<IEnumerable<Student>>
	{
		public int? Id { get; set; }
	}
}
