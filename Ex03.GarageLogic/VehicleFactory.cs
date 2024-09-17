using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_VehicleVendor, string i_LicensePlate, string i_WheelsVendor, int i_NumOfWheels, float i_MaxAirPressure, 
            float i_CurrentAirPressure, eEngineType i_EngineType, float i_CurrentEnergy, float i_MaxEnergy, Dictionary<string, string> i_ExtraProperties, eFuelType? i_FuelType = null)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.RegularMotorcycle:
                    newVehicle = new Motorcycle(i_VehicleVendor, i_LicensePlate, i_WheelsVendor, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, (eLicenseType)Enum.Parse(typeof(eLicenseType), i_ExtraProperties["LicenseType"]), int.Parse(i_ExtraProperties["EngineVolume"]), i_FuelType);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_VehicleVendor, i_LicensePlate, i_WheelsVendor, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, (eLicenseType)Enum.Parse(typeof(eLicenseType), i_ExtraProperties["LicenseType"]), int.Parse(i_ExtraProperties["EngineVolume"]));
                    break;

                case eVehicleType.RegularCar:
                    newVehicle = new Car(i_VehicleVendor, i_LicensePlate, i_WheelsVendor, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, (eCarColor)Enum.Parse(typeof(eCarColor), i_ExtraProperties["CarColor"]), (eNumOfCarDoors)Enum.Parse(typeof(eNumOfCarDoors), i_ExtraProperties["NumOfDoors"]), i_FuelType);
                    break;

                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_VehicleVendor, i_LicensePlate, i_WheelsVendor, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, (eCarColor)Enum.Parse(typeof(eCarColor), i_ExtraProperties["CarColor"]), (eNumOfCarDoors)Enum.Parse(typeof(eNumOfCarDoors), i_ExtraProperties["NumOfDoors"]));
                    break;

                case eVehicleType.Truck:
                    newVehicle = new Truck(i_VehicleVendor, i_LicensePlate, i_WheelsVendor, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, Boolean.Parse(i_ExtraProperties["IsIncludeHazardousMaterials"]), float.Parse(i_ExtraProperties["LuggageVolume"]), i_FuelType);
                    break;
            }

            return newVehicle;
        }
    }
}
