using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement
{
    public class StudentRepository: IStudentRepository
    {
        private readonly StudentManagementContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public StudentRepository(StudentManagementContext context) => 
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Student>> Get(int? id)
        {
	        var students = _context.Students
		        .Where(s => s.Id == id || id.HasValue == false);

	        return await students.ToListAsync();
        }

        public async Task<Student> Add(Student student) => 
            (await _context.Students.AddAsync(student)).Entity;

        public Student Update(Student student) =>
	        _context.Students.Update(student).Entity;

        public Student Delete(Student student) =>
	        _context.Students.Remove(student).Entity;

    }
}