using IPA;
using IPA.Loader;
using IpaLogger = IPA.Logging.Logger;
using BeatSaberMarkupLanguage.GameplaySetup;
using PrioritySetter.UI;

namespace PrioritySetter;

[Plugin(RuntimeOptions.DynamicInit)]
public class Plugin
{
    private static readonly PrioritySet PrioritySet = new PrioritySet();
    internal static IpaLogger Log { get; private set; } = null!;
    
    [Init]
    public Plugin(IpaLogger ipaLogger, PluginMetadata pluginMetadata)
    {
        Log = ipaLogger;
        Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
    }
    [OnStart]
    public void OnApplicationStart()
    {
        Log.Debug("OnApplicationStart");
        PrioritySet.SetAllPriorities();
        Log.Notice("Priority Set on start");
        BeatSaberMarkupLanguage.Util.MainMenuAwaiter.MainMenuInitializing += OnMainMenuInitializing;
    }
    private static void OnMainMenuInitializing()
    {
        GameplaySetup.Instance.AddTab(
            name: "Priority Setter",
            resource: "PrioritySetter.UI.prioritysetterui.bsml",
            host: PrioritySet);
    }
    [OnExit]
    public void OnApplicationQuit()
    {
        Log.Debug("OnApplicationQuit");
    }
}