using System;
using System.Collections.Generic;
using HarmonyLib;
using Verse; 

namespace PsychosisPlus
{
    [HarmonyPatch(typeof(Pawn))]
    [HarmonyPatch("PostApplyDamage")]
    [HarmonyPatch(new Type[] { typeof(DamageInfo), typeof(float) })]
    public class PawnDamage_Catcher
    {
        public interface Observer
        {
            void Notify(ref Pawn pawn, DamageInfo dinfo, float totalDamageDealt);
        }

        public static List<Observer> observers = new List<Observer>();

        static void Postfix(ref Pawn __instance, DamageInfo dinfo, float totalDamageDealt)
        {
            foreach (var observer in observers)
                observer.Notify(ref __instance, dinfo, totalDamageDealt);
        }
    }

    [HarmonyPatch(typeof(GenExplosion))]
    [HarmonyPatch("DoExplosion")]
    [HarmonyPatch(new Type[] { typeof(IntVec3), typeof(Map), typeof(float), typeof(DamageDef), typeof(Thing), typeof(int), typeof(float), typeof(SoundDef), typeof(ThingDef), typeof(ThingDef), typeof(Thing), typeof(ThingDef), typeof(float), typeof(int), typeof(bool), typeof(ThingDef), typeof(float), typeof(int), typeof(float), typeof(bool), typeof(float?), typeof(List<Thing>) })]
    public class Explosion_Catcher
    {
        public interface Observer
        {
            void Notify(IntVec3 center, Map map, float radius, DamageDef damType, Thing instigator, int damAmount = -1, float armorPenetration = -1f, SoundDef explosionSound = null, ThingDef weapon = null, ThingDef projectile = null, Thing intendedTarget = null, ThingDef postExplosionSpawnThingDef = null, float postExplosionSpawnChance = 0f, int postExplosionSpawnThingCount = 1, bool applyDamageToExplosionCellsNeighbors = false, ThingDef preExplosionSpawnThingDef = null, float preExplosionSpawnChance = 0f, int preExplosionSpawnThingCount = 1, float chanceToStartFire = 0f, bool damageFalloff = false, float? direction = null, List<Thing> ignoredThings = null);
        }

        public static List<Observer> observers = new List<Observer>();

        static void Postfix(IntVec3 center, Map map, float radius, DamageDef damType, Thing instigator, int damAmount = -1, float armorPenetration = -1f, SoundDef explosionSound = null, ThingDef weapon = null, ThingDef projectile = null, Thing intendedTarget = null, ThingDef postExplosionSpawnThingDef = null, float postExplosionSpawnChance = 0f, int postExplosionSpawnThingCount = 1, bool applyDamageToExplosionCellsNeighbors = false, ThingDef preExplosionSpawnThingDef = null, float preExplosionSpawnChance = 0f, int preExplosionSpawnThingCount = 1, float chanceToStartFire = 0f, bool damageFalloff = false, float? direction = null, List<Thing> ignoredThings = null)
        {
            foreach (var observer in observers)
                observer.Notify(center, map, radius, damType, instigator, damAmount, armorPenetration, explosionSound, weapon, projectile, intendedTarget, postExplosionSpawnThingDef, postExplosionSpawnChance, postExplosionSpawnThingCount, applyDamageToExplosionCellsNeighbors, preExplosionSpawnThingDef, preExplosionSpawnChance, preExplosionSpawnThingCount, chanceToStartFire, damageFalloff, direction, ignoredThings);
        }
    }
}
