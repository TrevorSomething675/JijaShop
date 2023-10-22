namespace JijaShop.Services.Settings.SettingsModel
{
    public class SwaggerSettings
    {
        public bool Enabled { get; private set; }

        public SwaggerSettings()
        {
            Enabled = false;
        }
    }
}
