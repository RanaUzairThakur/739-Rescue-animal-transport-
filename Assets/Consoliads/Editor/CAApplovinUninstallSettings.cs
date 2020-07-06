using UnityEditor;
using System.IO;
using UnityEngine;

public class CAApplovinUninstallSettings : Editor
{
	const string adnetworkTitle = "Applovin";
    const string Uninstall_Adnetwork_MenuItem_Title = "ConsoliAds/Uninstall Adnetwork";

    [MenuItem(Uninstall_Adnetwork_MenuItem_Title + "/" + adnetworkTitle, false, 3)]
    public static void UnistallAdnetworks()
	{
		CAApplovinUninstall applovinUnistall =  new CAApplovinUninstall();
		applovinUnistall.unistall();
	}

	class CAApplovinUninstall
	{
        const string kUninstallAlertTitle = "Uninstall - " + adnetworkTitle;
        const string kUninstallAlertMessage = "Backup before doing this step to preserve changes done in this plugin. This deletes files only related to ConsoliAds plugin. Do you want to proceed?";
        const string kAssets = "Assets";
        const string kPluginsPath = "Assets/Plugins";
        const string kAndroidPluginsPath = kPluginsPath + "/Android";
        const string kIOSPluginsPath = kPluginsPath + "/iOS";

        private readonly string[] kPluginFiles = {
			kIOSPluginsPath       +   "/libapplovin-mediation.a",
			kIOSPluginsPath       +   "/applovin_card_learn_more.png",
			kIOSPluginsPath       +   "/applovin_card_muted.png",
			kIOSPluginsPath       +   "/applovin_card_play.png",
			kIOSPluginsPath       +   "/applovin_card_replay.png",
			kIOSPluginsPath       +   "/applovin_card_unmuted.png",
			kIOSPluginsPath       +   "/Star_Sprite_0.5.png",
			kIOSPluginsPath       +   "/Star_Sprite_1.5.png",
			kIOSPluginsPath       +   "/Star_Sprite_2.5.png",
			kIOSPluginsPath       +   "/Star_Sprite_3.5.png",
			kIOSPluginsPath       +   "/Star_Sprite_4.5.png",
			kIOSPluginsPath       +   "/Star_Sprite_5.png",
			kIOSPluginsPath       +   "/Star_Sprite_0.png",
			kIOSPluginsPath       +   "/Star_Sprite_1.png",
			kIOSPluginsPath       +   "/Star_Sprite_2.png",
			kIOSPluginsPath       +   "/Star_Sprite_3.png",
			kIOSPluginsPath       +   "/Star_Sprite_4.png",

			kAndroidPluginsPath   +   "/applovin-mediation.aar",
			kAndroidPluginsPath   +   "/applovin-sdk-9.12.6.aar",
			kAssets               +   "/Consoliads/Editor/CAApplovinUninstallSettings.cs",

            kAssets               +   "/Consoliads/Editor/CAApplovinBuildPostProcessor.cs"
							

		};

		private string[] kPluginFolders = {
			kIOSPluginsPath   +   "/AppLovinSDK.framework",
            kIOSPluginsPath   +   "/AppLovinSDKResources.bundle",
            kIOSPluginsPath   +   "/Native Ads Carousel"
		};

        public void unistall()
        {
            bool _startUninstall = EditorUtility.DisplayDialog(kUninstallAlertTitle, kUninstallAlertMessage, "Uninstall", "Cancel");

            if (_startUninstall)
            {

                foreach (string _eachFILE in kPluginFiles)
                {
                    string _absolutePath = AssetPathToAbsolutePath(_eachFILE);

                    if (File.Exists(_absolutePath))
                    {
                        Delete(_absolutePath);

                        // Delete meta files.
                        if (File.Exists(_absolutePath + ".meta"))
                        {
                            Delete(_absolutePath + ".meta");
                        }
                    }
                }

                foreach (string _eachFolder in kPluginFolders)
                {
                    string _absolutePath = AssetPathToAbsolutePath(_eachFolder);

                    if (Directory.Exists(_absolutePath))
                    {
                        Directory.Delete(_absolutePath, true);

                        // Delete meta files.
                        if (File.Exists(_absolutePath + ".meta"))
                        {
                            Delete(_absolutePath + ".meta");
                        }
                    }
                }
                AssetDatabase.Refresh();
            }
        }

        public static string AssetPathToAbsolutePath(string _relativePath)
        {
            string _unrootedRelativePath = _relativePath.TrimStart('/');

            if (!_unrootedRelativePath.StartsWith(kAssets, System.StringComparison.Ordinal))
                return null;

            string _absolutePath = Path.Combine(GetProjectPath(), _unrootedRelativePath);

            // Return absolute path to asset
            return _absolutePath;
        }

        public static string GetProjectPath()
        {
            return Path.GetFullPath(Application.dataPath + @"/../");
        }

        public static void Delete(string _filePath)
        {
#if (UNITY_WEBPLAYER || UNITY_WEBGL)
			Debug.LogError("[CPFileOperations] File operations are not supported.");
#else
            File.Delete(_filePath);
#endif
        }
    }
}
