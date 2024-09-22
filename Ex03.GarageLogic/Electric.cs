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
            if (i_RefillEnergy >= 0 && i_RefillEnergy + CurrentEnergy <= MaxEnergy)
            {
                CurrentEnergy += i_RefillEnergy;
                EnergyPercentage = (CurrentEnergy / MaxEnergy) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
            }
        }

        public override string ToString()
        {
            return $"Battery status: {CurrentEnergy}/{MaxEnergy} ({EnergyPercentage}%)";
        }
    }
}
