using Bogus;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SimpleCMS.Data;
using SimpleCMS.Model;
using SimpleCMS.Service;

namespace SimpleCMS.Seed
{
    public static class SeedData
    {

        private static Faker faker = new Faker();
        private static Random random = new Random();
        public static async Task InitAsync(ApplicationDbContext context, IRegisterUserService registerService)
        {

            if (context.Menu.Any())
            {
                return;
            }

            for (int i = 0; i < 100; i++)
            {
                var fName = faker.Name.FirstName();
                var lName = faker.Name.LastName();
                var email = faker.Internet.Email(fName, lName, "zocom.se");
                var result = await registerService.Register(email, "pSrkXHN6z8s%KHW@");
                Console.WriteLine(result);
            }

            var userId = context.Users.Where(u => EF.Functions.Like(u.Email, "mdalwakil@outlook.com")).Select(u => u.Id).FirstOrDefault();
            if (userId == null)
            {
                return;
            }

            var menus = CreateMenus(userId);

            await context.AddRangeAsync(menus);
            context.SaveChanges();

            var list = new List<View>();
            var menuItemsIds = context.MenuItem.Select(i => i.Id).ToList();
            foreach (var Id in menuItemsIds)
            {
                var view = CreateView(Id);
                list.Add(view);
            }

            context.AddRangeAsync(list);
            context.SaveChanges();

        }
        private static ICollection<Menu> CreateMenus(string OwnerId)
        {

            var list = new List<Menu>();

            for (int i = 0; i < 10; i++)
            {

                var menu = new Menu
                {
                    Title = faker.Lorem.Slug(2),
                    Description = faker.Lorem.Sentence(),
                    Items = CreateMenuItems(random.Next(3, 8)),
                    OwnerId = OwnerId
                };

                list.Add(menu);
            }

            return list;
        }

        private static ICollection<MenuItem> CreateMenuItems(int count)
        {
            var list = new List<MenuItem>();
            for (int i = 0; i < count; i++)
            {

                var menuItem = new MenuItem
                {
                    Title = faker.Lorem.Slug(2),
                    Position = random.Next(0, count),
                };

                list.Add(menuItem);
            }

            return list;
        }

        private static View CreateView(int menuItemId)
        {
            var view = new View
            {
                ContentBlocks = CreateContentBlocks(),
                MenuItemId = menuItemId
            };

            return view;
        }

        private static ICollection<ContentBlock> CreateContentBlocks()
        {

            var list = new List<ContentBlock>
            {
              new ContentBlock
            {
                Text = faker.Lorem.Slug(3),
                Position = 0
            },

            new ContentBlock
            {
                Text = faker.Lorem.Slug(100),
                Position = 1,
                Image ="https://picsum.photos/200/300?random=" + $"{random.Next(1,10000)}",

            },
             new ContentBlock
            {
                Text = faker.Lorem.Slug(10),
                Position = 2
            }
            };

        return list;
        }
    }
}
