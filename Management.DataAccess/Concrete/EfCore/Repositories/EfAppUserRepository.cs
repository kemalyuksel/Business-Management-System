using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Contexts;
using Management.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Management.DataAccess.Concrete.EfCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetAllNonAdmin()
        {
            //select* from AspNetUsers inner join AspNetUserRoles
            //on AspNetUsers.Id = AspNetUserRoles.UserId
            //inner join AspNetRoles
            //on AspNetUserRoles.RoleId = AspNetRoles.Id
            //where AspNetRoles.Name = 'Member'


            using var context = new ManagementContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
            {
                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Picture = x.user.Picture,
                Email = x.user.Email,
                UserName = x.user.UserName
            }).ToList();

        }

        public List<AppUser> GetAllNonAdmin(out int pageCount, string searchKey, int activePage = 1)
        {

            using var context = new ManagementContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
            {
                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Picture = x.user.Picture,
                Email = x.user.Email,
                UserName = x.user.UserName
            });

            pageCount = (int)Math.Ceiling((double)result.Count() / 4);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Surname.ToLower().Contains(searchKey.ToLower()));
                pageCount = (int)Math.Ceiling((double)result.Count() / 4);
            }

            result = result.Skip((activePage - 1) * 4).Take(4);

            return result.ToList();

        }

        //        select AspNetUsers.UserName, count(works.Id) from AspNetUsers inner join Works on AspNetUsers.Id = Works.AppUserId
        //where Works.Status = 1 group by AspNetUsers.UserName

        public List<DualHelper> Top5WorkCompleter()
        {
            using var context = new ManagementContext();

            return context.Works.Include(x => x.AppUser).Where(x => x.Status == true)
                 .GroupBy(x => x.AppUser.Name + " " + x.AppUser.Surname).OrderByDescending(x => x.Count()).Take(5).Select(x => new DualHelper
                 {
                     Name = x.Key,
                     WorkCount = x.Count()

                 }).ToList();

        }

        public List<DualHelper> MostEmployeedAtWork()
        {
            using var context = new ManagementContext();

            return context.Works.Include(x => x.AppUser).Where(x => !x.Status && x.AppUserId != null)
                 .GroupBy(x => x.AppUser.Name + " "+ x.AppUser.Surname).OrderByDescending(x => x.Count()).Take(5).Select(x => new DualHelper
                 {
                     Name = x.Key,
                     WorkCount = x.Count()  

                 }).ToList();


        }


    }
}
