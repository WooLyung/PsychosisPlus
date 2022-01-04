using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PsychosisPlus
{
    public class Hediff_Insomnia : Hediff_MildPsychosis
    {
        public override void Tick()
        {
            Log.Message(pawn.jobs.curJob.GetType().ToString());
        }
    }
}