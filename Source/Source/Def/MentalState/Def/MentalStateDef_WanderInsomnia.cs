using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PsychosisPlus
{
    public class MentalStateDef_WanderInsomnia : MentalStateDef
    {
        public MentalStateDef_WanderInsomnia()
        {
            stateClass = typeof(MentalState_WanderInsomnia);
        }
    }
}