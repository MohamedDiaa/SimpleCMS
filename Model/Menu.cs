using SimpleCMS.Data;

namespace SimpleCMS.Model
{
    public class Menu
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }


        public ICollection<MenuItem> Items { get; set; }


        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
