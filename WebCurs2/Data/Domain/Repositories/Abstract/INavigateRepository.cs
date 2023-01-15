using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface INavigateRepository
    {
        Task<List<Navigate>> GetAllAsync();

        Task<List<Navigate>> GetParentsAsync();

        Task<List<Navigate>> GetChildrensByParentIdAsync(long id);

        Task<Navigate?> GetByNameAsync(string name);

        Task<bool> CreateAsync(Navigate entity);

        public Task SeveAsync(Navigate entity);
        public Task DeleteAsync(Navigate entity);

    }
}
