using System;
using System.Collections.Generic;
using System.Text;

namespace blog.data.models
{
    public class PostCategory
    {
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
