using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsIncludeHazardousMaterials;
        private float m_LuggageVolume;

        public Truck(string i_LicensePlate) : base(i_LicensePlate)
        { }

        public Truck(string i_TruckVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_TruckWheel, Energy i_TruckEnergy, bool i_IsIncludeHazrdousMaterials, float i_LuggageVolume)
            : base(i_TruckVendor, i_LicensePlate, i_NumOfWheels, i_TruckWheel, i_TruckEnergy)
        {
            m_IsIncludeHazardousMaterials = i_IsIncludeHazrdousMaterials;
            m_LuggageVolume = i_LuggageVolume;
        }

        public override void InitVehicleData(string i_VehicleVendor, int i_NumOfWheels, Wheel i_VehicleWheel, Energy i_VehicleEnergy, Dictionary<string, string> i_ExtraProperties)
        {
            VehicleVendor = i_VehicleVendor;
            VehicleEnergySource = i_VehicleEnergy;
            m_IsIncludeHazardousMaterials = i_ExtraProperties["IsIncludeHazardousMaterials"] == "Yes" ? true : false;
            m_LuggageVolume = float.Parse(i_ExtraProperties["LuggageVolume"]);
            WheelsCollection = new List<Wheel>(i_NumOfWheels);
            for (int i = 1; i <= i_NumOfWheels; i++)
            {
                WheelsCollection.Add(i_VehicleWheel);
            }
        }

        public bool IsIncludeHazardousMaterials
        {
            get
            {
                return m_IsIncludeHazardousMaterials;
            }
        }

        public float LuggageVolume
        {
            get
            {
                return m_LuggageVolume;
            }
        }

        public override string ToString()
        {
            string output = String.Format("{0}" +
                "{2}{1}" +
                "Luggage volume: {3}{1}",
                base.ToString(), Environment.NewLine, 
                m_IsIncludeHazardousMaterials ? "Including hazardous materials" : "Not include hazardous materials",
                m_LuggageVolume);

            return output;
        }
    }
}
