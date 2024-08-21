using Bogus;
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

            var user = context.Users.FirstOrDefault();
            if (user == null) {
                return;
            }

            var menus = CreateMenus(user.Id);
 
            await context.AddRangeAsync(menus);
            context.SaveChanges();
        }
        private static ICollection<Menu> CreateMenus(string OwnerId) {

            var list = new List<Menu>();

            for (int i = 0; i < 20; i++) {

                var menu = new Menu
                {
                    Title = faker.Lorem.Slug(2),
                    Description = faker.Lorem.Sentence(),
                    Items = CreateMenuItems(random.Next(0, 8)),
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
                    View = CreateView()
                };

                list.Add(menuItem);
            }

            return list;
        }

        private static View CreateView()
        {
                var view =  new View
                {
                    ContentBlocks = CreateContentBlocks()
                  
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
