using CoreApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            try
            {
                var res = await ctx.Courses.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return res.Entity;
            }
            catch (SqlException ex)
            {
                throw new Exception("Database is failed to connect..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                bool result = false;
                var res = await ctx.Courses.FindAsync(id);
                if (res != null)
                {
                    ctx.Courses.Remove(res);
                    await ctx.SaveChangesAsync();
                    result = true;
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception("Database is failed to connect..");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Course>> GetAsync()
        {
            try
            {
                return await ctx.Courses.ToListAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database is failed to connect..");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Course> GetAsync(int id)
        {
            try
            {
                var res = await ctx.Courses.FindAsync(id);
                return res;
            }
            catch (SqlException ex)
            {
                throw new Exception("Database is failed to connect..");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Course> UpdateAsync(int id, Course entity)
        {
            try
            {
                var res = await ctx.Courses.FindAsync(id);
                if (res != null)
                {
                    res.CourseId = entity.CourseId;
                    res.CourseName = entity.CourseName;
                    res.Capacity = entity.Capacity;
                    ctx.Courses.Update(res);
                    await ctx.SaveChangesAsync();
                }
                return res;
            }
            catch (SqlException ex)
            {
                throw new Exception("Database is failed to connect..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
