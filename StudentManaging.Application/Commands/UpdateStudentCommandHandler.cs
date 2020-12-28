using MediatR;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManaging.Application.Commands
{
	public class UpdateStudentCommandHandler : AsyncRequestHandler<UpdateStudentCommand>
	{
		private readonly IStudentRepository _studentRepository;
		public UpdateStudentCommandHandler(IStudentRepository studentRepository) =>
			_studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));

		protected override async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
		{
			var address = Address.AddAddress(request.Street, request.City, request.State, request.Country, request.ZipCode);
			var student = Student.UpdateStudent(request.Id, request.Name, address, request.PhoneNumber);

			_studentRepository.Update(student);
			await _studentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
		}
	}
}
