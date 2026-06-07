using System.ComponentModel;
using Avalonia.Media;
using Avalonia.Styling;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TioUi.Common.Helpers;
using TioUi.Shared;

namespace Portal.Classes.Entries;

public class ConfigEntry : ReactiveObject
{
    public ConfigEntry()
    {
        PropertyChanged += OnPropertyChanged;
    }

    [Reactive] [JsonProperty] public Theme Theme { get; set; } = Theme.Light;
    [Reactive] [JsonProperty] public Color ThemeColor { get; set; } = Color.Parse("#1BD76A");
    [Reactive] [JsonProperty] public bool UseFilePicker { get; set; } = true;

    private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Theme))
            ThemeHelper.ToggleTheme(Theme);
        else if (e.PropertyName == nameof(ThemeColor)) 
            ThemeHelper.SetThemeColor(ThemeColor);

        App.Method.SaveConfig();
    }
}