namespace blog.business.services
{
    using data.models;
    using repositories;
    using data.context;

    public class PostService : Repository<Post>,IPostRepository
    {
        public PostService(BlogContext context):base(context){}
        
    }
}