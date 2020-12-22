using UGF.CustomSettings.Editor;
using UnityEditor;

namespace UGF.PackageManager.Auth.Editor
{
    public static class PackageManagerAuthSettings
    {
        public static PackageManagerAuthSettingsFile Settings { get; } = new PackageManagerAuthSettingsFile(PackageManagerAuthUtility.GetConfigPath());

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<PackageManagerAuthSettingsData>("Preferences/UGF/Package Manager Auth", Settings, SettingsScope.User);
        }
    }
}
