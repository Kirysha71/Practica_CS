using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeJournal.Models;

namespace GradeJournal.Data.Repositories
{
    public class StudentRepository : IRepository<StudentModel>
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .Include(s => s.Grades)
                .Include(s => s.Attendance)
                .ToListAsync();
        }

        public async Task<StudentModel> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                .Include(s => s.Grades)
                .Include(s => s.Attendance)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<StudentModel>> FindAsync(Expression<Func<StudentModel, bool>> predicate)
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                .Include(s => s.Grades)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(StudentModel student)
        {
            await _context.Students.AddAsync(student);
        }

        public void Update(StudentModel student)
        {
            _context.Students.Update(student);
        }

        public void Delete(StudentModel student)
        {
            _context.Students.Remove(student);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}