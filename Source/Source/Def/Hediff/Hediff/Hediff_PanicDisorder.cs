using RimWorld;
using System;
using Verse;

namespace PsychosisPlus
{
    public class Hediff_PanicDisorder : Hediff_DangerousPsychosis
    {
        int panicCool = 0;
        int panicTime = 0;

        int newCool => new Random().Next(120000, 300000);

        public override void PostMake()
        {
            base.PostMake();
            if (panicCool == 0)
                panicCool = newCool;
        }

        public override void Tick()
        {
            if (panicTime++ > panicCool)
            {
                panicTime = 0;
                panicCool = newCool;
                pawn?.health?.AddHediff(DefDatabase<HediffDef>.GetNamed("PanicAttack"));
                pawn?.needs?.mood?.thoughts?.memories?.TryGainMemory(DefDatabase<ThoughtDef>.GetNamed("PanicAttack"));
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref panicCool, "panicCool", 0);
            Scribe_Values.Look(ref panicTime, "panicTime", 0);
        }
    }
}