namespace SimpleCMS.Model
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Position { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    
        public int? ViewId { get; set; }

        public View? View { get; set; }
    }
}
