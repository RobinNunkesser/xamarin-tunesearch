namespace PlaceholderPosts.Core
{
    public class PostEntity
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString() =>
            $"UserId: {UserId}\nId: {Id}\nTitle: {Title}\nBody: {Body}\n";
    }
}