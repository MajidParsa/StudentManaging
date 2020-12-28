using MediatR;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Application.Commands
{
	public class DeleteStudentCommand : IRequest
	{
		public int Id { get; set; }
	}
}
