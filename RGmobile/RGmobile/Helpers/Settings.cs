using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in the Core solution or in any
    /// of the client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        #region Setting Constants

        private const string AccessTokenKey     = "access_token";
        private const string KeyValidUntilKey   = "key_valid";
        private const string UserIdKey          = "user_id";
        private const string UserNameKey        = "user_id";

        #endregion

        private static ISettings AppSettings => CrossSettings.Current;

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessTokenKey, string.Empty);
            set => AppSettings.AddOrUpdateValue(AccessTokenKey, value);
        }

        public static string UserId
        {
            get => AppSettings.GetValueOrDefault(UserIdKey, string.Empty);
            set => AppSettings.AddOrUpdateValue(UserIdKey, value);
        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(UserNameKey, string.Empty);
            set => AppSettings.AddOrUpdateValue(UserNameKey, value);           
        }

        public static long KeyValidUntil
        {
            get => AppSettings.GetValueOrDefault(KeyValidUntilKey, 0);
            set => AppSettings.AddOrUpdateValue(KeyValidUntilKey, value);
        }
    }
}
