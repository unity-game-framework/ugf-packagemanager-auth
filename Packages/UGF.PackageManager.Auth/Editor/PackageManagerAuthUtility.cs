using System;

namespace UGF.PackageManager.Auth.Editor
{
    public static class PackageManagerAuthUtility
    {
        public const string CONFIG_FILE_NAME = ".upmconfig.toml";

        public static string GetConfigPath()
        {
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            user = user.Replace('\\', '/');

            return $"{user}/{CONFIG_FILE_NAME}";
        }
    }
}
