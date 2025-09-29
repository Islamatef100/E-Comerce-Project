using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Reposatories
{
    public class CategoryReposatory: GenericReposatory<Category>, ICategoryReposatory
    {
        public CategoryReposatory(AppDBContext _context) : base(_context)
        {

        }
}
}
