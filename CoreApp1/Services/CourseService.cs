using CoreApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Services
{
    public class CourseService : IService<Course, int>
    {
        private ApplicationDbContext ctx;

        /// <summary>
        /// Injecting ApplicationDbContext as dependency to service class
        /// </summary>
        /// <param name="ctx"></param>
        public CourseService(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            var res = await ctx.Courses.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var res = await ctx.Courses.FindAsync(id);
            if(res != null)
            {
                ctx.Courses.Remove(res);
                await ctx.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await ctx.Courses.ToListAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            var res = await ctx.Courses.FindAsync(id);
            return res;
        }

        public async Task<Course> UpdateAsync(int id, Course entity)
        {
            var res = await ctx.Courses.FindAsync(id);
            if (res != null)
            {
                res = entity;
                await ctx.SaveChangesAsync();
            }
            return res;
        }
    }
}
