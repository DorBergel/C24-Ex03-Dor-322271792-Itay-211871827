using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_VehicleVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_VehicleWheel, 
            Energy i_VehicleEnergy, Dictionary<string, string> i_ExtraProperties)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.RegularMotorcycle:
                    newVehicle = new Motorcycle(i_VehicleVendor, i_LicensePlate, i_NumOfWheels, i_VehicleWheel, i_VehicleEnergy, 
                        (eLicenseType)Enum.Parse(typeof(eLicenseType), i_ExtraProperties["LicenseType"]), int.Parse(i_ExtraProperties["EngineVolume"]));
                    break;

                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_VehicleVendor, i_LicensePlate, i_NumOfWheels, i_VehicleWheel, i_VehicleEnergy, 
                        (eLicenseType)Enum.Parse(typeof(eLicenseType), i_ExtraProperties["LicenseType"]), int.Parse(i_ExtraProperties["EngineVolume"]));
                    break;

                case eVehicleType.RegularCar:
                    newVehicle = new Car(i_VehicleVendor, i_LicensePlate, i_NumOfWheels, i_VehicleWheel, i_VehicleEnergy, 
                        (eCarColor)Enum.Parse(typeof(eCarColor), i_ExtraProperties["CarColor"]), (eNumOfCarDoors)Enum.Parse(typeof(eNumOfCarDoors), i_ExtraProperties["NumOfDoors"]));
                    break;

                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_VehicleVendor, i_LicensePlate, i_NumOfWheels, i_VehicleWheel, i_VehicleEnergy, 
                        (eCarColor)Enum.Parse(typeof(eCarColor), i_ExtraProperties["CarColor"]), (eNumOfCarDoors)Enum.Parse(typeof(eNumOfCarDoors), i_ExtraProperties["NumOfDoors"]));
                    break;

                case eVehicleType.Truck:
                    newVehicle = new Truck(i_VehicleVendor, i_LicensePlate, i_NumOfWheels, i_VehicleWheel, i_VehicleEnergy, 
                        Boolean.Parse(i_ExtraProperties["IsIncludeHazardousMaterials"]), float.Parse(i_ExtraProperties["LuggageVolume"]));
                    break;
            }

            return newVehicle;
        }
    }
}
