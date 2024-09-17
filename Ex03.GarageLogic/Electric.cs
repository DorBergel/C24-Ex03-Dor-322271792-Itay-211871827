using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric : Energy
    {
        public Electric(float i_CurrentEnergy, float i_MaxEnergy) :
            base(i_CurrentEnergy, i_MaxEnergy)
        { }

        public override void Refill(float i_RefillEnergy, eFuelType? i_ChosenFuelType = null)
        {
            if (i_RefillEnergy + CurrentEnergy <= MaxEnergy)
            {
                CurrentEnergy = i_RefillEnergy;
            }
            else
            {
                // TODO Value out of range exception
            }
        }
    }
}
