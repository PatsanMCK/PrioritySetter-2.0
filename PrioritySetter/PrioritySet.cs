using System.Diagnostics;
using BeatSaberMarkupLanguage.Attributes;

namespace PrioritySetter;

public class PrioritySet
{
    [UIAction("priority-set")]
    public static void SetAllPriorities()
    {
        //Set Beat Saber to High
        Process currentProcess = Process.GetCurrentProcess();
        currentProcess.PriorityClass = ProcessPriorityClass.High;
        
        // Set all Discord processes Normal Priority
        string discordProcessName = "Discord";
        Process[] discordProccess = Process.GetProcessesByName(discordProcessName);
        foreach (Process p in discordProccess)
        {
            p.PriorityClass = ProcessPriorityClass.Normal;
        }
        Plugin.Log.Info("Set Priorities by Button");
    }
}

