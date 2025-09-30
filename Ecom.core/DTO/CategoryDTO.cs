using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO
{
    public class CategoryDTO
    {
        public string Name { set; get; }
        public string Description { set; get; }

    }
    public class UpdateCategoryDTO
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public int Id { set; get; }
    }
}
