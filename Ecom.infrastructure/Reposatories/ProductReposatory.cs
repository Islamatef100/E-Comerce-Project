using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Reposatories
{
    public class ProductReposatory : GenericReposatory<Product> , IProductReposatory
    {
        public ProductReposatory(AppDBContext _context) : base(_context) { }

    }
}
