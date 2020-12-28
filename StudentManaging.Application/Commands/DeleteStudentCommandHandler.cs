using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManaging.Application.Exceptions;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Application.Commands
{
	public class DeleteStudentCommandHandler : AsyncRequestHandler<DeleteStudentCommand>
	{
		private readonly IStudentRepository _studentRepository;
		public DeleteStudentCommandHandler(IStudentRepository studentRepository) =>
			_studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));

		protected override async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var students = await _studentRepository.Get(request.Id);
			Student student = students?.FirstOrDefault();
			if (student == null)
				throw new StudentApplicationException("Record not found!");

			_studentRepository.Delete(student);
			await _studentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
		}
	}
}
