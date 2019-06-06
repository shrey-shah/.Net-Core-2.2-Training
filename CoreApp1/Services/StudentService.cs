using CoreApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Services
{
    public class StudentService : IService<Student, int>
    {
        private ApplicationDbContext ctx;

        /// <summary>
        /// Injecting ApplicationDbContext as dependency to service class
        /// </summary>
        /// <param name="ctx"></param>
        public StudentService(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            var res = await ctx.Students.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var res = await ctx.Students.FindAsync(id);
            if (res != null)
            {
                ctx.Students.Remove(res);
                await ctx.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await ctx.Students.ToListAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            var res = await ctx.Students.FindAsync(id);
            return res;
        }

        public async Task<Student> UpdateAsync(int id, Student entity)
        {
            var res = await ctx.Students.FindAsync(id);
            if (res != null)
            {
                res = entity;
                await ctx.SaveChangesAsync();
            }
            return res;
        }
    }
}
