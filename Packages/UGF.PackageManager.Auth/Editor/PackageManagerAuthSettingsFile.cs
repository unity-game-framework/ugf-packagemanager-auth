using System;
using System.IO;
using UGF.CustomSettings.Runtime;
using UnityEngine;

namespace UGF.PackageManager.Auth.Editor
{
    public class PackageManagerAuthSettingsFile : CustomSettingsFile<PackageManagerAuthSettingsData>
    {
        public PackageManagerAuthSettingsFile(string filePath) : base(filePath)
        {
        }

        protected override void OnSaveSettings(PackageManagerAuthSettingsData data, bool force)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
        }

        protected override PackageManagerAuthSettingsData OnLoadSettings()
        {
            var data = ScriptableObject.CreateInstance<PackageManagerAuthSettingsData>();
            string text = null;

            if (File.Exists(FilePath))
            {
                text = File.ReadAllText(FilePath);
            }

            return data;
        }
    }
}
