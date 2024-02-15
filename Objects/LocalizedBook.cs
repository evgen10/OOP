

namespace OOP
{
    public class LocalizedBook : Book
    {
        public string? OriginalPublisher { get; set; }
        public string? CountryOfLocalization { get; set; }
        public string? LocalPublisher { get; set; }

        public override string GetCardInfo()
        {
            return $"{base.GetCardInfo()}, Original Publisher: {OriginalPublisher}, Localization: {CountryOfLocalization}, Local Publisher: {LocalPublisher}";
        }
    }
}
