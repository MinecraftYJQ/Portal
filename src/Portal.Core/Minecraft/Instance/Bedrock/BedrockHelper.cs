using System.Xml;

namespace Portal.Core.Minecraft.Instance.Bedrock;

public class BedrockHelper
{
    public static string GetInstanceVersion(string instanceFolder)
    {
        var manifestPath = Path.Combine(instanceFolder, "appxmanifest.xml");
        if (!File.Exists(manifestPath)) throw new FileNotFoundException($"未找到 {manifestPath} 文件");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(File.ReadAllText(manifestPath));

        XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
        nsManager.AddNamespace("ns", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");

        XmlNode identityNode = xmlDoc.SelectSingleNode("//ns:Identity", nsManager);

        if (identityNode != null)
        {
            string version = identityNode.Attributes["Version"]?.Value;

            return version;
        }
        else
        {
            throw new NullReferenceException("未找到Identity节点");
        }
    }
}