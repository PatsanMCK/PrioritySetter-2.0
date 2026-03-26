using System.Collections;
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
        // Set all Discord processes needed priority
        string discordProcessName = "Discord";
        Process[] discordProccess = Process.GetProcessesByName(discordProcessName);
        for (var i = 0; i < discordProccess.Length; i++)
        {
            if (i == 4)
            {
                discordProccess[i].PriorityClass = ProcessPriorityClass.BelowNormal;
            }
            else
            {
                discordProccess[i].PriorityClass = ProcessPriorityClass.Normal;
            }
        }
    }
}

