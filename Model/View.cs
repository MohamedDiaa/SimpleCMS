namespace SimpleCMS.Model
{
    public class View
    {
        public int Id { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public ICollection<ContentBlock> ContentBlocks { get; set; }
    }
}
