using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : Energy
    {
        eFuelType? m_FuelType;
        
        public Fuel(float i_CurrentEnergy, float i_MaxEnergy, eFuelType? i_FuelType) :
            base(i_CurrentEnergy, i_MaxEnergy)
        {
            m_FuelType = i_FuelType;
        }

        public override void Refill(float i_RefillEnergy, eFuelType? i_ChosenFuelType)
        {
            if(i_RefillEnergy + CurrentEnergy <= MaxEnergy && i_ChosenFuelType == m_FuelType)
            {
                CurrentEnergy = i_RefillEnergy;
            }
            else
            {
                // TODO Value out of range exception
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
    }
}
