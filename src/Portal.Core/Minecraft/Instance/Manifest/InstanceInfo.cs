namespace Portal.Core.Minecraft.Instance.Manifest;

public class InstanceInfo
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public InstanceType Type { get; set; }
    public string GameRootFolder { get; set; } = string.Empty;
    public string InstanceFolder { get; set; } = string.Empty;
}