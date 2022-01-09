using RimWorld;
using System;
using Verse;
using Verse.AI;

namespace PsychosisPlus
{
    public abstract class Hediff_PTSD : Hediff_DangerousPsychosis
    {
        public virtual void Trauma(IntVec3? fear)
        {
            pawn?.mindState?.mentalStateHandler?.TryStartMentalState(DefDatabase<MentalStateDef>.GetNamed("Wander_Trauma"));
            pawn?.needs?.mood?.thoughts?.memories?.TryGainMemory(DefDatabase<ThoughtDef>.GetNamed("PTSDTrauma"));

            if (fear != null)
            {
                IntVec3 dir = (IntVec3)(pawn.Position - fear);
                (float, float) toNormal = ((float)dir.x, (float)dir.z);
                float scale = (float)Math.Sqrt(toNormal.Item1 * toNormal.Item1 + toNormal.Item2 * toNormal.Item2);
                toNormal = (toNormal.Item1 / scale, toNormal.Item2 / scale);

                for (int i = 10; i < 30; i++)
                {
                    IntVec3 to = pawn.Position + new IntVec3((int)(toNormal.Item1 * i), pawn.Position.y, (int)(toNormal.Item2 * i));
                    if (pawn.Map.thingGrid.ThingsAt(to).EnumerableCount() == 0)
                    {
                        Job job = new Job(JobDefOf.FleeAndCower, to);
                        pawn.jobs.StartJob(job, JobCondition.Succeeded);
                        break;
                    }
                }
            }
        }
    }
}