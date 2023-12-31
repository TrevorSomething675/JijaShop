﻿namespace JijaShop.Extensions.SettingsModel
{
    public class AuthSettings
    {
        public string Key { get; private set; } = null!;
        public string? Audience { get; private set; }
        public string? Issuer { get; private set; }
        public int ExpTimeHours { get; private set; }
    }
}
