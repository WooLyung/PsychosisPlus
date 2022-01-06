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
        int wanderCool = 0;
        int wanderTime = 0;

        int newCool => new Random().Next(1100, 1200) - (int)(Severity * 1000);

        public override void PostMake()
        {
            base.PostMake();
            if (wanderCool == 0)
                wanderCool = newCool;
        }

        public override void Tick()
        {
            if (pawn?.jobs?.curJob?.def == JobDefOf.LayDown)
            {
                if (wanderTime++ > wanderCool && !pawn.health.Downed)
                {
                    wanderTime = 0;
                    wanderCool = newCool;
                    pawn?.jobs?.EndCurrentJob(JobCondition.InterruptOptional);
                    pawn?.mindState?.mentalStateHandler?.TryStartMentalState(DefDatabase<MentalStateDef>.GetNamed("Wander_Insomnia"));
                }
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref wanderCool, "wanderCool", 0);
            Scribe_Values.Look(ref wanderTime, "wanderTime", 0);
        }
    }
}