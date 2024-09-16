using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : Energy
    {
        eFuelType m_FuelType;
        
        public Fuel(float i_CurrentEnergy, float i_MaxEnergy, eFuelType i_FuelType) :
            base(i_CurrentEnergy, i_MaxEnergy)
        {
            m_FuelType = i_FuelType;
        }

        public override void Refill(float i_RefillEnergy)
        {
            if(i_RefillEnergy + CurrentEnergy <= MaxEnergy)
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
