using RimWorld;
using Verse;

namespace PsychosisPlus
{
    public class Hediff_PTSD_Fire : Hediff_PTSD
    {
        public override void Tick()
        {
            base.Tick();

            if (pawn != null && pawn.IsHashIntervalTick(40))
            {
                if (pawn.jobs.curJob.def != JobDefOf.FleeAndCower)
                {
                    if (pawn.IsBurning())
                    {
                        Trauma(null);
                    }
                    else
                    {
                        foreach (Fire fire in pawn.Map.listerThings.ThingsOfDef(ThingDefOf.Fire))
                        {
                            if (fire.Position.InHorDistOf(pawn.Position, 10.0f) && GenSight.LineOfSight(fire.Position, pawn.Position, pawn.Map, skipFirstCell: true))
                            {
                                Trauma(fire.Position);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}