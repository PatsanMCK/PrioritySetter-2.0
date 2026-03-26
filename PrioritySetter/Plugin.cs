using System;
using IPA;
using IPA.Loader;
using IpaLogger = IPA.Logging.Logger;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using BeatSaberMarkupLanguage.GameplaySetup;
using IPA.Config;
using UnityEngine;
using Debug = UnityEngine.Debug;
using ModestTree;
using SiraUtil.Zenject;
using Timer = System.Timers.Timer;

namespace PrioritySetter;

[Plugin(RuntimeOptions.DynamicInit)]
public class Plugin
{
    private static readonly PrioritySet PrioritySet = new PrioritySet();
    internal static IpaLogger Log { get; private set; } = null!;
    // Methods with [Init] are called when the plugin is first loaded by IPA.
    // All the parameters are provided by IPA and are optional.
    // The constructor is called before any method with [Init]. Only use [Init] with one constructor
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
            resource: "PrioritySetter.prioritysetterui.bsml",
            host: PrioritySet);
    }
    [OnExit]
    public void OnApplicationQuit()
    {
        Log.Debug("OnApplicationQuit");
    }
}