namespace SimpleCMS.Model
{
    public class ContentBlock
    {
       public int Id { get; set; }

        public string Text { get; set; }

        public int Position { get; set; }

        public int ViewId { get; set; }

        public View View { get; set; }
    }
}

