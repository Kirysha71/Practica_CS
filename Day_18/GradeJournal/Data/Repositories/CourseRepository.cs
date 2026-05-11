using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeJournal.Models;

namespace GradeJournal.Data.Repositories
{
    public class CourseRepository : IRepository<CourseModel>
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseModel>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .ToListAsync();
        }

        public async Task<CourseModel> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CourseModel>> FindAsync(Expression<Func<CourseModel, bool>> predicate)
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(CourseModel course)
        {
            await _context.Courses.AddAsync(course);
        }

        public void Update(CourseModel course)
        {
            _context.Courses.Update(course);
        }

        public void Delete(CourseModel course)
        {
            _context.Courses.Remove(course);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}