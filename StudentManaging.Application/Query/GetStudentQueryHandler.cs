using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Application.Query
{
	public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, IEnumerable<Student>>
	{
		private readonly IStudentRepository _studentRepository;

		public GetStudentQueryHandler(IStudentRepository studentRepository) =>
			_studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));

		public async Task<IEnumerable<Student>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
		{
			return (await _studentRepository.Get(request.Id));
		}
	}
}
