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
            foreach (var hediff in p?.health?.hediffSet?.GetHediffs<Hediff_Insomnia>())
                return ThoughtState.ActiveDefault;
            return ThoughtState.Inactive;
            throw new NotImplementedException();
        }
    }
}
