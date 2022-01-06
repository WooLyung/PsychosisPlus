using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace PsychosisPlus
{
    public class ThoughtWorker_Insomnia : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            Hediff_Insomnia hediff = null;

            foreach (var entry in p?.health?.hediffSet?.GetHediffs<Hediff_Insomnia>())
                hediff = entry;

            if (hediff == null || p.needs.rest.CurLevel >= 0.7f)
            {
                return ThoughtState.Inactive;
            }
            else
            {   
                if (hediff.Severity < 0.15f)
                    return ThoughtState.ActiveAtStage(0);
                else if (hediff.Severity < 0.30f)
                    return ThoughtState.ActiveAtStage(1);
                else if (hediff.Severity < 0.62f)
                    return ThoughtState.ActiveAtStage(2);
                else
                    return ThoughtState.ActiveAtStage(3);
            }
        }
    }
}