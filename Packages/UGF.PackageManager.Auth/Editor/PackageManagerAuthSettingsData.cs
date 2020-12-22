using System;
using System.Collections.Generic;
using UGF.CustomSettings.Runtime;
using UnityEngine;

namespace UGF.PackageManager.Auth.Editor
{
    public class PackageManagerAuthSettingsData : CustomSettingsData
    {
        [SerializeField] private List<AuthData> m_list = new List<AuthData>();

        public List<AuthData> List { get { return m_list; } }

        [Serializable]
        public struct AuthData
        {
            [SerializeField] private string m_url;
            [SerializeField] private string m_email;
            [SerializeField] private string m_token;
            [SerializeField] private bool m_alwaysAuth;

            public string Url { get { return m_url; } set { m_url = value; } }
            public string Email { get { return m_email; } set { m_email = value; } }
            public string Token { get { return m_token; } set { m_token = value; } }
            public bool AlwaysAuth { get { return m_alwaysAuth; } set { m_alwaysAuth = value; } }
        }
    }
}
