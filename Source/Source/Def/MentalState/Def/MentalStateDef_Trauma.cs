using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PsychosisPlus
{
    public class MentalStateDef_Trauma : MentalStateDef
    {
        public MentalStateDef_Trauma()
        {
            stateClass = typeof(MentalState_Trauma);
        }
    }
}
