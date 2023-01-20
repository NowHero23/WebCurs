using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface INavigateRepository
    {
        public Task<List<Navigate>> GetAllAsync();

        public Task<List<Navigate>> GetParentsAsync();

        public Task<List<Navigate>> GetChildrensByParentIdAsync(long id);

        public Task<Navigate?> GetByNameAsync(string name);

        public Task CreateAsync(Navigate entity);

        public Navigate? GetById(long id);

        public Task SeveAsync(Navigate entity);
        public Task DeleteAsync(Navigate entity);

    }
}
