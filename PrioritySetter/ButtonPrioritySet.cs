using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using BeatSaberMarkupLanguage.Attributes;

namespace PrioritySetter;

public class ButtonPrioritySet
{
    [UIAction("priority-set")]
    private void SetAllPriorities()
    {
        //Set Beat Saber to High
        Process currentProcess = Process.GetCurrentProcess();
        currentProcess.PriorityClass = ProcessPriorityClass.High;
        
        // Set all Discord processes same priority, Normal in this case
        string discordProcessName = "Discord";
        Process[] discordProccess = Process.GetProcessesByName(discordProcessName);
        foreach (Process p in discordProccess)
        {
            p.PriorityClass = ProcessPriorityClass.Normal;
        }
        Plugin.Log.Info("Set Priorities by something");
    }
}

