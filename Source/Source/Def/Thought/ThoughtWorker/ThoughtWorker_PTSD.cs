using RimWorld;
using System;
using Verse;

namespace PsychosisPlus
{
    public class ThoughtWorker_PTSD : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            foreach (var hediff in p?.health?.hediffSet?.GetHediffs<Hediff_PTSD>())
                return ThoughtState.ActiveDefault;
            return ThoughtState.Inactive;
        }
    }
}