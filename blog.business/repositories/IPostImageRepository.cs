namespace blog.business.repositories
{
    using data.models;
    using System;

    public interface IPostImageRepository:IRepository<PostImage>
    {
        void SetFalse(Guid id);
    }
    
}