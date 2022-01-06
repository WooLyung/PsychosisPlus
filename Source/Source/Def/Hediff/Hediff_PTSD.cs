using RimWorld;
using System;
using Verse;

namespace PsychosisPlus
{
    public class Hediff_PTSD : Hediff_DangerousPsychosis, PawnDamage_Catcher.Observer
    {
        public Hediff_PTSD()
        {
            PawnDamage_Catcher.observers.Add(this);
        }

        ~Hediff_PTSD()
        {
            PawnDamage_Catcher.observers.Remove(this);
        }

        public void Notify(ref Pawn pawn, DamageInfo dinfo, float totalDamageDealt)
        {
            Log.Message(pawn.Name.ToString());
        }
    }
}