using Portal.Core.Minecraft.Instance;

var manager = new InstanceManager(@"D:\BedrockBoot");
manager.RefreshInstances().ForEach(x =>
{
    Console.WriteLine(x.Version);
});