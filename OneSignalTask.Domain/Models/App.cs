using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OneSignalTask.Domain.Models
{
    public class App
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [JsonProperty("players")]
        [Display(Name = "Players")]
        public int Players { get; set; }

        [JsonProperty("apns_env")]
        [Display(Name = "ApnsEnv (iOS)")]
        public string ApnsEnv { get; set; }

        [JsonProperty("apns_p12")]
        [Display(Name = "ApnsP12 (iOS)")]
        public string ApnsP12 { get; set; }

        [JsonProperty("apns_p12_password")]
        [Display(Name = "ApnsP12 Password (iOS)")]
        public string ApnsP12Password { get; set; }

        [JsonProperty("gcm_key")]
        [Display(Name = "FCM Google Push Server Auth Key (Android)")]
        public string GcmKey { get; set; }

        [JsonProperty("android_gcm_sender_id")]
        [Display(Name = "FCM Google Project number (Android)")]
        public string AdroidGcmSenderId { get; set; }

        [JsonProperty("chrome_web_origin")]
        [Display(Name = "Chrome website's URL (Chrome)")]
        public string ChromeWebOrigin { get; set; }

        [JsonProperty("chrome_web_default_notification_icon")]
        [Display(Name = "Chrome default notification icon (Chrome)")]
        public string ChromeWebDefaultNotificationIcon { get; set; }

        [JsonProperty("chrome_web_sub_domain")]
        [Display(Name = "Subdomain (Chrome)")]
        public string ChromeWebSubDomain { get; set; }

        [JsonProperty("site_name")]
        [Display(Name = "Site Name (Chrome)")]
        public string SiteName { get; set; }

        [JsonProperty("safari_site_origin")]
        [Display(Name = "Website's hostname (Safari)")]
        public string SafariSiteOrigin { get; set; }

        [JsonProperty("safari_apns_p12")]
        [Display(Name = "SafariApnsP12 (Safari)")]
        public string SafariApnsP12 { get; set; }

        [JsonProperty("safari_apns_p12_password")]
        [Display(Name = "SafariApnsP12 password (Safari)")]
        public string SafariApnsP12Password { get; set; }

        [JsonProperty("safari_icon_256_256")]
        [Display(Name = "Url for a 256x256 png (Safari)")]
        public string SafariIcon256x256 { get; set; }

        [JsonProperty("chrome_key")]
        [Display(Name = "Google Push Messaging Auth Key")]
        public string ChromeKey { get; set; }

        [JsonProperty("additional_data_is_root_payload")]
        [Display(Name = "Additional notification  data")]
        public string AdditionalDataIsRootPayload { get; set; }

        [JsonProperty("organization_id")]
        [Display(Name = "Organization Id")]
        public string OrganizationId { get; set; }

        [JsonProperty("messageable_players")]
        [Display(Name = "Messageable Players")]
        public string MessageablePlayers { get; set; }

        [JsonProperty("updated_at")]
        [Display(Name = "Updated At")]
        public string UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        [Display(Name = "Created At")]
        public string CreatedAt { get; set; }

        [JsonProperty("chrome_web_gcm_sender_id")]
        [Display(Name = "Web Gcm Sender Id (Chrome)")]
        public string CromeWebGcmSenderId { get; set; }

        [JsonProperty("apns_certificates")]
        [Display(Name = "Apns Certificates")]
        public string ApnsCertificates { get; set; }

        [JsonProperty("safari_apns_certificate")]
        [Display(Name = "Apns Certificates (Safari)")]
        public string SafariApnsCertificates { get; set; }

        [JsonProperty("safari_push_id")]
        [Display(Name = "Push Id (Safari)")]
        public string SafariPushId { get; set; }

        [JsonProperty("basic_auth_key")]
        [Display(Name = "Basic Auth Key")]
        public string BasicAuthKey { get; set; }
    }
}
