

namespace OOP
{
    public class Magazine : Document
    {
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public int ReleaseNumber { get; set; }
        public DateTime PublishDate { get; set; }

        public override string GetCardInfo()
        {
            return $"Magazine - Title: {Title}, Publisher: {Publisher}, Release Number: {ReleaseNumber}, Publish Date: {PublishDate}";
        }
    }
}
