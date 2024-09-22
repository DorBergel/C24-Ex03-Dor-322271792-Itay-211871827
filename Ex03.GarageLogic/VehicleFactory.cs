using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_LicensePlate)
        {
            Vehicle vehicle = null;

            if (i_VehicleType == eVehicleType.RegularMotorcycle || i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                vehicle = new Motorcycle(i_LicensePlate);
            }
            else if (i_VehicleType == eVehicleType.RegularCar || i_VehicleType == eVehicleType.ElectricCar)
            {
                vehicle = new Car(i_LicensePlate);
            }
            else
            {
                vehicle = new Truck(i_LicensePlate);
            }

            return vehicle;
        }
    }
}
