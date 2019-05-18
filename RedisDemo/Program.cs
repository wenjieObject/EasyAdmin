using Common;
using IRepository;
using IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repository;
using Services;
using System;
using System.Linq;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var flag = RedisHelper._connMultiplexer.GetDatabase().StringGet("colip");
        

            RedisHelper rh = new RedisHelper();
            //rh.StringSet("boway", "bowayValue");
            //var test= rh.StringGet("boway");

            var menu = rh.StringGet<Menu>("MenuKey");
            if (menu == null)
            {
                var serviceProvider = AutoGenerateCode.Program.BuildServiceForSqlServer();
                IMenuService service = serviceProvider.GetService<IMenuService>();
                menu = service.LoadData().FirstOrDefault();
                rh.StringSet<Menu>("MenuKey", menu);

            }
            Console.WriteLine("Hello World!"+ menu.DisplayName);
        }

        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
  
    }
}
