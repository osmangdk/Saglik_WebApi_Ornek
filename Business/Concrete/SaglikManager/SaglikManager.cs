using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.SaglikManager
{
    public class SaglikManager : ISaglikService
    {
        private readonly GenericRepo<Hastum> _genericRepo;

        public SaglikManager(GenericRepo<Hastum> genericRepo)
        {
            _genericRepo = genericRepo;
        }
        public async Task AddAsync(Hastum entity)
        {
            await _genericRepo.AddAsync(entity);
        }

        public void Delete(Hastum entity)
        {
            _genericRepo.Delete(entity);
        }

        public async Task<IEnumerable<Hastum>> GetAllAsync()
        {
           return await _genericRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Hastum>> GetAsync(Expression<Func<Hastum, bool>>? filter = null, Func<IQueryable<Hastum>, IOrderedQueryable<Hastum>>? orderBy = null, string includeProperties = "")
        {
            return await _genericRepo.GetAsync(filter, orderBy, includeProperties);
        }

        public async Task<Hastum?> GetByIdAsync(object id)
        {
            return await _genericRepo.GetByIdAsync(id);
        }

        public Task SaveChangesAsync()
        {
            return  _genericRepo.SaveChangesAsync();
        }

        public void Update(Hastum entity)
        {
            _genericRepo.Update(entity);
        }
    }
}
