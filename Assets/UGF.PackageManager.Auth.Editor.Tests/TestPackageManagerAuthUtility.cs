using NUnit.Framework;

namespace UGF.PackageManager.Auth.Editor.Tests
{
    public class TestPackageManagerAuthUtility
    {
        [Test]
        public void GetUserFolderPath()
        {
            string path = PackageManagerAuthUtility.GetConfigPath();

            Assert.Pass(path);
        }
    }
}
