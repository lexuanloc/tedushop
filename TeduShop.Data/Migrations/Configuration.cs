namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeduShop.Common;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            CreateProductCategorySample(context);

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "loclx",
            //    Email = "lexuanloc@outlook.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Le Xuan Loc"

            //};

            //manager.Create(user, "123@123a");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("lexuanloc@outlook.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() > 0) return;

            List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh", Alias="dien-lanh", Status=true },
                new ProductCategory() { Name="Viễn thông", Alias="vien-thong", Status=true },
                new ProductCategory() { Name="Đồ gia dụng", Alias="do-gia-dung", Status=true },
                new ProductCategory() { Name="Mỹ phẩm", Alias="my-pham", Status=true }
            };

            context.ProductCategories.AddRange(listProductCategory);
        }
        
        private void CreateFooter(TeduShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {

            }
        }
    }
}
