using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Tommy;

namespace UGF.PackageManager.Auth.Editor.Config
{
    internal static class PackageManagerAuthConfigUtility
    {
        public static string ToTomlConfig(PackageManagerAuthConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            var toml = new TomlTable();
            var authNode = new TomlTable();

            toml["npmAuth"] = authNode;

            foreach (KeyValuePair<string, PackageManagerAuthConfig.AuthData> pair in config)
            {
                var table = new TomlTable
                {
                    ["email"] = pair.Value.Email,
                    ["token"] = pair.Value.Token,
                    ["alwaysAuth"] = pair.Value.AlwaysAuth
                };

                authNode[pair.Key] = table;
            }

            string text = ToToml(toml);

            return text;
        }

        public static PackageManagerAuthConfig FromTomlConfig(string text)
        {
            var config = new PackageManagerAuthConfig();
            TomlTable toml = FromToml(text);

            if (toml.TryGetNode("npmAuth", out TomlNode authNode))
            {
                foreach (string key in authNode.Keys)
                {
                    TomlNode table = authNode[key];
                    string email = table["email"].AsString?.Value ?? string.Empty;
                    string token = table["token"].AsString?.Value ?? string.Empty;
                    bool alwaysAuth = table["alwaysAuth"].AsBoolean?.Value ?? false;

                    var auth = new PackageManagerAuthConfig.AuthData(email, token, alwaysAuth);

                    config.Add(key, auth);
                }
            }

            return config;
        }

        public static string ToToml(TomlTable target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                target.WriteTo(writer);

                return writer.ToString();
            }
        }

        public static TomlTable FromToml(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));

            using (var reader = new StringReader(text))
            {
                return TOML.Parse(reader);
            }
        }
    }
}
