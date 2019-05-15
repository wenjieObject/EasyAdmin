using Common;
using IRepository;
using IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repository;
using System;

namespace AutoGenerateCode
{
    class Program
    {
        private readonly IArticleCategoryService _service;

        public Program(IArticleCategoryService service)
        {
            _service = service;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var serviceProvider = BuildServiceForSqlServer();
            //var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            //codeGenerator.GenerateTemplateCodesFromDatabase(true);
            //Console.WriteLine("自动代码生成完成,按任意键退出");

            //_service.get

            //var category1 = new ArticleCategory
            //{
            //    Title = "随笔1",
            //    ParentId = 0,
            //    ClassList = "",
            //    ClassLayer = 0,
            //    Sort = 0,
            //    ImageUrl = "",
            //    SeoTitle = "随笔的SEOTitle",
            //    SeoKeywords = "随笔的SeoKeywords",
            //    SeoDescription = "随笔的SeoDescription",
            //    IsDeleted = false,
            //};
            //var category2 = new ArticleCategory
            //{
            //    Title = "随笔2",
            //    ParentId = 0,
            //    ClassList = "",
            //    ClassLayer = 0,
            //    Sort = 0,
            //    ImageUrl = "",
            //    SeoTitle = "随笔的SEOTitle",
            //    SeoKeywords = "随笔的SeoKeywords",
            //    SeoDescription = "随笔的SeoDescription",
            //    IsDeleted = false,
            //};
            //var categoryId = categoryRepository.Insert(category1);
            //var categoryId2 = categoryRepository.Insert(category2);

            //var list = categoryRepository.GetList();
            //categoryRepository.DeleteList("where 1=1");
            //var count = categoryRepository.RecordCount();



            Console.ReadLine();
        }

 
 


        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "Data Source=(local);Initial Catalog=EasyAdmin;User ID=sa;pwd=123123123";
                options.DbType = DatabaseType.MSSQL.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType
                options.Author = "jwj";//作者名称
                options.OutputPath = "D:\\VSCode\\Demo\\EasyAdmin";//模板代码生成的路径
                options.ModelsNamespace = "Models";//实体命名空间
                options.IRepositoryNamespace = "IRepository";//仓储接口命名空间
                options.RepositoryNamespace = "Repository";//仓储命名空间
                options.IServicesNamespace = "IServices";//服务接口命名空间
                options.ServicesNamespace = "Services";//服务命名空间


            });
            //var path = AppContext.BaseDirectory;
            //var config = GetConfiguration().GetSection("DbOpion");
            services.Configure<DbOption>("EasyAdmin", GetConfiguration().GetSection("DbOpion"));
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<CodeGenerator>();
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            return builder.Build();
        }

    }




}
