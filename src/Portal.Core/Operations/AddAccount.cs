using Avalonia;
using Avalonia.Controls;
using TioUi.Common;
using TioUi.Controls;

namespace Portal.Core.Operations;

public class AddAccount
{
    public static async Task Main(object sender)
    {
        var options = new OverlayDialogOptions()
        {
            Mode = DialogMode.None,
            Buttons = DialogButton.OKCancel,
            Title = "添加新账户",
            
            CanLightDismiss = false,
            CanDragMove = true,
            IsCloseButtonVisible = false,
            CanResize = false,
            OverrideOkButtonText = "下一步"
        };
        var type = new ComboBox()
        {
            Items =
            {
                "离线模式",
                "微软登录",
                "外置登录"
            },
            SelectedIndex = 0,
            Width = 320,
            Margin = new Thickness(0,15)
        };
        var result = await OverlayDialog.ShowStandardAsync(type, vm: null, hostId: null, options: options);
        if (result != DialogResult.Yes)
        {
            return;
        }
        
    }
}