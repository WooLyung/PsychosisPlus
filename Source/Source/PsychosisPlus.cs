using System.Reflection;
using HarmonyLib;
using Verse;

namespace PsychosisPlus
{
    [StaticConstructorOnStartup]
    internal class PsychosisPlus
    {
        static PsychosisPlus()
        {
            Harmony harmony = new Harmony("com.woolyung.psychosisplus.rimworld.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
