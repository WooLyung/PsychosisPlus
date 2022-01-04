﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace PsychosisPlus
{
    public class MentalState_WanderInsomnia : MentalState
    {
        public override RandomSocialMode SocialModeMax()
        {
            return RandomSocialMode.Off;
        }

        public override bool AllowRestingInBed
        {
            get
            {
                if (pawn.needs.rest.CurLevel <= 0.05f)
                    return true;
                else
                    return false;
            }
        }
    }
}
