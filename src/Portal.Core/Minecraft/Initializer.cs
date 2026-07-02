namespace Portal.Core.Minecraft;
using MinecraftLaunch;

public static class MinecraftCoreInitializer
{
    public static void Initialize(string appVersion)
    {
        InitializeHelper.Initialize(settings => {
            settings.MaxThread = 256;
            settings.MaxFragment = 128;
            settings.MaxRetryCount = 4;
            settings.IsEnableMirror = false;
            settings.IsEnableFragment = false;
            settings.CurseForgeApiKey = "$2a$10$ndSPnOpYqH3DRmLTWJTf5Ofm7lz9uYoTGvhSj0OjJWJ8WdO4ZTsr.";
            settings.UserAgent = $"Portal/{appVersion}";
        });
    }
}