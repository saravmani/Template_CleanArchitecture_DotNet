using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scorpion.SchoolManagement.Student.Applicaiton.Interfaces;
using Scorpion.SchoolManagement.Student.Domain.DBEntity;

namespace Scorpion.SchoolManagement.Student.Persister
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagerContext studentManagerContext;
        public StudentRepository(StudentManagerContext studentManagerContext)
        {
            this.studentManagerContext = studentManagerContext;
        }

        
        public async Task<StudentDetails> AddAsync(StudentDetails entity)
        {
            var addedStudent =  await studentManagerContext.StudentDetails.AddAsync(entity);
            studentManagerContext.SaveChanges();
            return addedStudent.Entity;
        }

        public Task DeleteAsync(StudentDetails entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<StudentDetails>> GetAllAsync()
        {
            return await studentManagerContext.StudentDetails.ToListAsync();
        }

        public Task<IReadOnlyList<StudentDetails>> GetAsync(Expression<Func<StudentDetails, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StudentDetails>> GetAsync(Expression<Func<StudentDetails, bool>> predicate = null, Func<IQueryable<StudentDetails>, IOrderedQueryable<StudentDetails>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<StudentDetails>> GetAsync(Expression<Func<StudentDetails, bool>> predicate = null, Func<IQueryable<StudentDetails>, IOrderedQueryable<StudentDetails>> orderBy = null, List<Expression<Func<StudentDetails, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDetails> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StudentDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
