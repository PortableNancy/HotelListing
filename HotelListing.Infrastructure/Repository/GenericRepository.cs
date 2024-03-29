﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HotelListing.Infrastructure.Data;
using HotelListing.Infrastructure.IRepository;

namespace HotelListing.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _db;
        
  
        

        public GenericRepository(DataContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Delete(int Id)
        {
            var entity = await _db.FindAsync(Id);
            _db.Remove(entity);
        }

        public  void DeleteRange(IEnumerable<T> entities)
        {
           
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query =_db;

            if(expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                   query =query.Include(include);
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();

        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
          await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
           _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
