using RimWorld;
using System;
using Verse;

namespace PsychosisPlus
{
    public class ThoughtWorker_PanicAttack : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            foreach (var hediff in p?.health?.hediffSet?.GetHediffs<Hediff_PanicAttack>())
                return ThoughtState.ActiveDefault;
            return ThoughtState.Inactive;
        }
    }
}