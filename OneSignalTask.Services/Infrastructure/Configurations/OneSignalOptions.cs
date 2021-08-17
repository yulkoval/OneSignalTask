namespace OneSignalTask.Services.Infrastructure.Configurations
{
    public class OneSignalOptions
    {
        public static string SectionName { get; set; } = "OneSignalOptionsApi";
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
