using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.PackageManager.Auth.Editor.Config
{
    internal class PackageManagerAuthConfig
    {
        public IReadOnlyDictionary<string, AuthData> Dictionary { get; }

        private readonly Dictionary<string, AuthData> m_dictionary = new Dictionary<string, AuthData>();

        public readonly struct AuthData
        {
            public string Email { get; }
            public string Token { get; }
            public bool AlwaysAuth { get; }

            public AuthData(string email, string token, bool alwaysAuth)
            {
                Email = email;
                Token = token;
                AlwaysAuth = alwaysAuth;
            }
        }

        public PackageManagerAuthConfig()
        {
            Dictionary = new ReadOnlyDictionary<string, AuthData>(m_dictionary);
        }

        public void Add(string url, AuthData data)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException("Value cannot be null or empty.", nameof(url));

            m_dictionary.Add(url, data);
        }

        public bool Remove(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException("Value cannot be null or empty.", nameof(url));

            return m_dictionary.Remove(url);
        }

        public AuthData Get(string url)
        {
            return TryGet(url, out AuthData data) ? data : throw new ArgumentException($"Auth data not found by the specified url: '{url}'.");
        }

        public bool TryGet(string url, out AuthData data)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException("Value cannot be null or empty.", nameof(url));

            return m_dictionary.TryGetValue(url, out data);
        }

        public Dictionary<string, AuthData>.Enumerator GetEnumerator()
        {
            return m_dictionary.GetEnumerator();
        }
    }
}
