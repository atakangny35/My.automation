using Microsoft.EntityFrameworkCore;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace My.Otomasyon.DataAccess.Concrete.EfCore
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetCurrents()
        {
            using var context = new OtomasyonContext();
            var value = context.Users.Join(context.UserRoles, x => x.Id, y => y.UserId, (resultUser, resultRole) => new
            {
                user = resultUser,
                role = resultRole

            }).Join(context.Roles, x => x.role.RoleId, y => y.Id, (table, roles) => new
            {
                user = table.user,
                userRole = table.role,
                Roles = roles
            }).Where(x => x.Roles.Name == "Current").Select(x => new AppUser()
            {
                Id = x.user.Id,
                Departman = x.user.Departman,
                DepartmanId = x.user.DepartmanId,
                City = x.user.City,
                Name = x.user.Name,
                Email = x.user.Email,
                UserName = x.user.UserName,
                Surname = x.user.Surname



            }).ToList();
            return value;
        }

        public List<AppUser> GetPerconels(int id)
        {
            using var context = new OtomasyonContext();
            var value = context.Users.Join(context.UserRoles, x => x.Id, y => y.UserId, (resultUser, resultRole) => new
            {
                user = resultUser,
                role = resultRole

            }).Join(context.Roles, x => x.role.RoleId, y => y.Id, (table, roles) => new
            {
                user = table.user,
                userRole = table.role,
                Roles = roles
            }).Where(x => x.Roles.Name == "Perconel").Select(x => new AppUser()
            {
                Id = x.user.Id,
                Departman = x.user.Departman,
                DepartmanId = x.user.DepartmanId,
                City = x.user.City,
                Name = x.user.Name,
                Email = x.user.Email,
                UserName = x.user.UserName,
                Surname = x.user.Surname



            }).Where(x=>x.DepartmanId==id).ToList();
            return value;
                
        }

        public List<AppUser> GetPerconels()
        {
            using var context = new OtomasyonContext();
            var value = context.Users.Join(context.UserRoles, x => x.Id, y => y.UserId, (resultUser, resultRole) => new
            {
                user = resultUser,
                role = resultRole

            }).Join(context.Roles, x => x.role.RoleId, y => y.Id, (table, roles) => new
            {
                user = table.user,
                userRole = table.role,
                Roles = roles
            }).Join(context.Departmen, x => x.user.DepartmanId, y => y.Id, (table2, departman) => new 
            {

                allTable =table2,
                dep=departman


            }).Where(x => x.allTable.Roles.Name == "Perconel").Select(x => new AppUser()
            {
                Id = x.allTable.user.Id,
                Departman = x.dep,
                DepartmanId = x.allTable.user.DepartmanId,
                City = x.allTable.user.City,
                Name = x.allTable.user.Name,
                Email = x.allTable.user.Email,
                UserName = x.allTable.user.UserName,
                Surname = x.allTable.user.Surname



            }).ToList();
            return value;
        }

        
    }
}
