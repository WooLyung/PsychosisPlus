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
    public class Hediff_Insomnia : Hediff_MildPsychosis
    {
        public override void Tick()
        {
            if (pawn?.jobs?.curJob?.def == JobDefOf.LayDown)
            {
                pawn?.jobs?.EndCurrentJob(JobCondition.InterruptForced);
                pawn?.mindState?.mentalStateHandler?.TryStartMentalState(DefDatabase<MentalStateDef>.GetNamed("Wander_Insomnia"));
            }
        }
    }
}