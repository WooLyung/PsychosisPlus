using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace PsychosisPlus
{
    internal class Hediff_PTSD_Explosion : Hediff_PTSD, Explosion_Catcher.Observer
    {
        public Hediff_PTSD_Explosion()
        {
            Explosion_Catcher.observers.Add(this);
        }

        ~Hediff_PTSD_Explosion()
        {
            Explosion_Catcher.observers.Remove(this);
        }

        public void Notify(IntVec3 center, Map map, float radius, DamageDef damType, Thing instigator, int damAmount = -1, float armorPenetration = -1, SoundDef explosionSound = null, ThingDef weapon = null, ThingDef projectile = null, Thing intendedTarget = null, ThingDef postExplosionSpawnThingDef = null, float postExplosionSpawnChance = 0, int postExplosionSpawnThingCount = 1, bool applyDamageToExplosionCellsNeighbors = false, ThingDef preExplosionSpawnThingDef = null, float preExplosionSpawnChance = 0, int preExplosionSpawnThingCount = 1, float chanceToStartFire = 0, bool damageFalloff = false, float? direction = null, List<Thing> ignoredThings = null)
        {
            if (center.InHorDistOf(pawn.Position, 20f))
            {
                pawn.mindState.mentalStateHandler.TryStartMentalState(DefDatabase<MentalStateDef>.GetNamed("Wander_Insomnia"));

                IntVec3 dir = pawn.Position - center;
                (float, float) toNormal = ((float)dir.x, (float)dir.z);
                float scale = (float)Math.Sqrt(toNormal.Item1 * toNormal.Item1 + toNormal.Item2 * toNormal.Item2);
                toNormal = (toNormal.Item1 / scale, toNormal.Item2 / scale);

                for (int i = 10; i < 30; i++)
                {
                    IntVec3 to = pawn.Position + new IntVec3((int)(toNormal.Item1 * i), pawn.Position.y, (int)(toNormal.Item2 * i));
                    if (pawn.Map.thingGrid.ThingsAt(to).EnumerableCount() == 0)
                    {
                        Job job = new Job(JobDefOf.FleeAndCower, to);
                        pawn.jobs.StartJob(job);
                        break;
                    }
                }
            }
        }
    }
}
