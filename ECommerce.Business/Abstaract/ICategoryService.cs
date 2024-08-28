using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstaract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
    }
}
