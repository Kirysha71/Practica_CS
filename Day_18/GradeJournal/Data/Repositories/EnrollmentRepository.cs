using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeJournal.Models;

namespace GradeJournal.Data.Repositories
{
    public class EnrollmentRepository : IRepository<EnrollmentModel>
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnrollmentModel>> GetAllAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<EnrollmentModel> GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<EnrollmentModel>> FindAsync(Expression<Func<EnrollmentModel, bool>> predicate)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(EnrollmentModel enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
        }

        public void Update(EnrollmentModel enrollment)
        {
            _context.Enrollments.Update(enrollment);
        }

        public void Delete(EnrollmentModel enrollment)
        {
            _context.Enrollments.Remove(enrollment);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}