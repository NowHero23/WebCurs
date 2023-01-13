using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Models;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface INavigateRepository
    {
        Task<List<Navigate>> GetAllAsync();

        Task<List<Navigate>> GetParentsAsync();

        Task<List<Navigate>> GetChildrensByParentIdAsync(int id);


    }
}
