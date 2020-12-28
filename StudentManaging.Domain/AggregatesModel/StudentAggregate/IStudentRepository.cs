using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Domain.AggregatesModel.StudentAggregate
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> Get(int? id);
        Task<Student> Add(Student student);
        Student Update(Student student);
        Student Delete(Student student);
    }

}