namespace blog.root
{
    using Microsoft.Extensions.DependencyInjection;
    using business.repositories;
    using business.services;
    using data.context;
    using Microsoft.EntityFrameworkCore;
    public class CompositionRoot
    {
        public CompositionRoot() { }
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<BlogContext>();
            services.AddScoped(typeof(IPostRepository),typeof(PostService));
            services.AddScoped(typeof(IPostImageRepository),typeof(PostImageService));
            services.AddScoped(typeof(ICategoryRepository),typeof(CategoryService));

            services.AddDbContext<BlogContext>(options => 
            options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=blogDB;integrated security=true;", x=> x.MigrationsAssembly("blog.ui")));
        }
    }
}