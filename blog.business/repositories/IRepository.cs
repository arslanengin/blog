namespace blog.business.repositories
{
    using System;
    using System.Collections.Generic;
    using data.models;
    using System.Linq.Expressions;
    public interface IRepository<T> where T : CoreEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid Id);
        void Delete(T item);
        void Delete(Expression<Func<T, bool>> exp);
        T GetById(Guid Id);
        IEnumerable<T> GetAll();

        IEnumerable<T> GetDefault(Expression<Func<T, bool>> exp);
        int Save();
        void RollBack();

        bool Any(Expression<Func<T, bool>> exp);
    }
}