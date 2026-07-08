using Portal.Core.Minecraft.Instance.Bedrock;
using Portal.Core.Minecraft.Instance.Manifest;

namespace Portal.Core.Minecraft.Instance;

public class InstanceManager
{
    private readonly string _gameRootFolder;
    public List<string> VersionFolders { get; } = new() { "versions", "bedrock_versions" }; // 前一个是所有启动器公共的目录，后一个是 bedrockboot 规范中的目录
    public List<InstanceInfo> Instances { get; private set; } = new();

    public InstanceManager(string gameRootFolder)
    {
        _gameRootFolder = gameRootFolder;
    }

    #region 公共方法

    public List<InstanceInfo> RefreshInstances()
    {
        VersionFolders.ForEach(versionFolder =>
        {
            var versionsFolder = Path.Combine(_gameRootFolder, versionFolder);
            if (!Directory.Exists(versionsFolder))
                Directory.CreateDirectory(versionsFolder);

            Directory.GetDirectories(versionsFolder).ToList().ForEach(instanceFolder =>
            {
                if (GetInstanceType(instanceFolder) == InstanceType.Bedrock)
                {
                    var version = BedrockHelper.GetInstanceVersion(instanceFolder);
                    Instances.Add(new()
                    {
                        Name = Path.GetFileName(instanceFolder),
                        Version = version,
                        Description = string.Empty,
                        Type = InstanceType.Bedrock,
                        GameRootFolder = _gameRootFolder,
                        InstanceFolder = instanceFolder
                    });
                }
            });
        });
        
        return Instances;
    }

    public InstanceType GetInstanceType(string instanceFolder)
    {
        if (File.Exists(Path.Combine(instanceFolder, "appxmanifest.xml")))
            return InstanceType.Bedrock;
        if (File.Exists(Path.Combine(instanceFolder, $"{Path.GetFileName(instanceFolder)}.json")))
            return InstanceType.Java;
        
        return InstanceType.Java;
    }

    #endregion

    #region 私有方法

    #endregion
}