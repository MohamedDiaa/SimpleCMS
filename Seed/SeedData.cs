using Bogus;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data;
using SimpleCMS.Model;

namespace SimpleCMS.Seed
{
    public static class SeedData
    {

        private static Faker faker = new Faker();
        private static Random random = new Random();
        public static async void InitAsync(ApplicationDbContext context) {

            if (context.Menu.Any()) {
                return;
            }

            var userId = context.Users.Where(u => EF.Functions.Like(u.Email, "mdalwakil@outlook.com")).Select(u => u.Id).FirstOrDefault();
            if (userId == null) {
                return;
            }

            var menus = CreateMenus(userId);
 
            await context.AddRangeAsync(menus);
            context.SaveChanges();

            var list = new List<View>();
            var menuItemsIds = context.MenuItem.Select(i => i.Id).ToList();
            foreach (var Id in menuItemsIds) {
               var view =  CreateView(Id);
                list.Add(view);
            }

            context.AddRangeAsync(list);
            context.SaveChanges();

        }
        private static ICollection<Menu> CreateMenus(string OwnerId) {

            var list = new List<Menu>();

            for (int i = 0; i < 10; i++) {

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
                    Position = random.Next(0,count),                    
                };

                list.Add(menuItem);
            }

            return list;
        }

        private static View CreateView(int menuItemId)
        {
                var view =  new View
                {
                    ContentBlocks = CreateContentBlocks(),
                    MenuItemId = menuItemId
                };
           
            return view;
        }

        private static ICollection<ContentBlock> CreateContentBlocks()
        {

            var list = new List<ContentBlock>();
            for (int i = 0; i < 3; i++)
            {

                var content = new ContentBlock
                {
                    Text = faker.Lorem.Slug(100),
                    Position = random.Next(0, 3)
                };

                list.Add(content);
            }

            return list;
        }
    }
}
