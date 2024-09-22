using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : Energy
    {
        private eFuelType m_FuelType;
        
        public Fuel(float i_CurrentEnergy, float i_MaxEnergy, eFuelType i_FuelType) :
            base(i_CurrentEnergy, i_MaxEnergy)
        {
            m_FuelType = i_FuelType;
        }

        public override void Refill(float i_RefillEnergy, eFuelType? i_ChosenFuelType)
        {
            if(i_RefillEnergy >= 0 && i_RefillEnergy + CurrentEnergy <= MaxEnergy && CheckIfFuelTypeMatch(i_ChosenFuelType))
            {
                CurrentEnergy += i_RefillEnergy;
                EnergyPercentage = (CurrentEnergy / MaxEnergy) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxEnergy - CurrentEnergy);
            }
        }

        public bool CheckIfFuelTypeMatch(eFuelType? i_FuelType)
        {
            bool isFuelTypeMatch = i_FuelType == m_FuelType;

            if (isFuelTypeMatch == false)
            {
                string errorMsg = String.Format("Error: Type of fuel that you chose ({0}) does not match to the fuel type of the vehicle.", i_FuelType.ToString());
                throw new ArgumentException(errorMsg);
            }

            return isFuelTypeMatch;
        }

        public eFuelType? FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public override string ToString()
        {
            return $"Fuel type: {m_FuelType}, Fuel status: {CurrentEnergy}/{MaxEnergy} ({EnergyPercentage}%)";
        }
    }
}
