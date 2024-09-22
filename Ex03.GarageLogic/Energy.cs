using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_CurrentEnergy;
        private float m_MaxEnergy;
        private float m_EnergyPercentage;
        
        public Energy(float i_CurrentEnergy, float i_MaxEnergy)
        {
            m_MaxEnergy = i_MaxEnergy;
            if (i_CurrentEnergy >= 0 && i_CurrentEnergy <= m_MaxEnergy)
            {
                m_CurrentEnergy = i_CurrentEnergy;
                m_EnergyPercentage = (m_CurrentEnergy / m_MaxEnergy) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergy);
            }
        }

        public abstract void Refill(float i_RefillEnergy, eFuelType? i_ChosenFuelType = null);

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                if (value >= 0 && value <= m_MaxEnergy)
                {
                    m_CurrentEnergy = value;
                    EnergyPercentage = (m_CurrentEnergy / m_MaxEnergy) * 100;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxEnergy);
                }
            }
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public float MaxEnergyToRefill()
        {
            return m_MaxEnergy - m_CurrentEnergy;
        }
    }
}
