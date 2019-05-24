using Dapper;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RolePermission rp = new RolePermission
            {
                Id=1000,
                MenuId = 7,
                Permission = "test!!",
                RoleId = 1
            };
            //引入Dapper
            IDbConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=EasyAdmin;User ID=sa;pwd=123123123");
            var insertSql = "insert into RolePermission (MenuId,Permission,RoleId) values(@MenuId,@Permission,@RoleId)";
           

            connection.Execute(insertSql, rp);

            var querySql = "select * from RolePermission";
            //无参数查询，返回列表，带参数查询和之前的参数赋值法相同。
            var list =connection.Query<RolePermission>(querySql).ToList();

            foreach(var s in list)
            {
                Console.WriteLine(s.Permission);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
