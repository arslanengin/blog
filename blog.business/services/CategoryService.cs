using System;
using System.Collections.Generic;
using System.Text;
using blog.data.models;
using blog.business.repositories;
using blog.data.context;

namespace blog.business.services
{
   public class CategoryService : Repository<Category>, ICategoryRepository
    {
        public CategoryService(BlogContext context) : base(context) { }

    }
}
