namespace JijaShop.Services.Settings.SettingsModel
{
    public class IdentitySettings
    {
        public string SecretKeyForToken { get; private set; }
        public string Audience { get; private set; }
        public string Issuer { get; private set; }
        public int ExpTimeHours { get; private set; }
    }
}
