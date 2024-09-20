using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_Garage;

        public UI()
        {
            m_Garage = new Garage();
        }

        // Method to manage the app should be here

        public void InitOptionsMenu()
        {
            string optionMenuMsg =
                String.Format("Welcome to the Garage! Please enter the digit of action you want to select:" + Environment.NewLine
                + "1. Inserting new vehicle to the garage" + Environment.NewLine
                + "2. Showing all the license plates that in the garage (with option to filter by vehicle status in the garage)" + Environment.NewLine
                + "3. Changing the vehicle status in the garage" + Environment.NewLine
                + "4. Inflating the vehicle's wheels to the maximum" + Environment.NewLine
                + "5. Refilling a vehicle powered by fuel" + Environment.NewLine
                + "6. Charging an electric vehicle" + Environment.NewLine
                + "7. Showing complete vehicle data by license plate");
            Console.WriteLine(optionMenuMsg);
        }

        public string ChooseFromListOfOptions(string[] i_OptionsToList)
        {
            string userDigitInput = null;
            int intUserDigitInput;
            bool isValidInput = false;
            StringBuilder messageInList = new StringBuilder();

            for (int i = 0; i < i_OptionsToList.Length; i++)
            {
                messageInList.AppendLine($"{i + 1}. {i_OptionsToList[i]}");
            }

            do
            {
                try
                {
                    Console.WriteLine("Enter the digit (between 1 to {0}) of your desired selection", i_OptionsToList.Length);
                    Console.WriteLine(messageInList.ToString());
                    userDigitInput = Console.ReadLine();
                    isValidInput = checkIfDigitInRange(userDigitInput, i_OptionsToList.Length);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
                
            } while (!isValidInput);

            intUserDigitInput = userDigitInput != null ? int.Parse(userDigitInput) : -1;

            return intUserDigitInput != -1 ? i_OptionsToList[intUserDigitInput - 1] : null;
        }

        private bool checkIfDigitInRange(string i_UserDigitInput, int i_MaxDigit)
        {
            int intUserInput;
            bool isDigitInRange = true;

            if (!int.TryParse(i_UserDigitInput, out intUserInput))
            {
                isDigitInRange = false;
                throw new FormatException("Error: Only digits are allowed!");
            }
            else if (intUserInput > i_MaxDigit || intUserInput < 1)
            {
                isDigitInRange = false;
                throw new ValueOutOfRangeException(1, i_MaxDigit);
            }

            return isDigitInRange;
        }

        public string GetUserInput<T>(string i_InstructionsToInput)
        {
            string userInput = null;
            bool isValidInput = false;

            do
            {
                try
                {
                    Console.WriteLine(i_InstructionsToInput);
                    userInput = Console.ReadLine();
                    isValidInput = checkIsValidInput<T>(userInput);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            } while (!isValidInput);

            return userInput;
        }

        private bool checkIsValidInput<T>(string i_UserInput)
        {
            bool isValidInput = true;

            if (typeof(T) == typeof(int))
            {
                if (!int.TryParse(i_UserInput, out _))
                {
                    isValidInput = false;
                    throw new FormatException("Error: Only digits are allowed!");
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (!float.TryParse(i_UserInput,out _))
                {
                    isValidInput = false;
                    throw new FormatException("Error: Only digits are allowed!");
                }
            }
            else if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrEmpty(i_UserInput))
                {
                    throw new ArgumentException("Error: Input cannot be empty!");
                }
            }

            return isValidInput;
        }

        // Need to think again
        public void InsertNewVehicleToGarage()
        {
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                Console.WriteLine("The vehicle is already in the garage.");
                m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].VehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                eFuelType fuelType;
                float currentEnergy;
                string stringCurrentEnergy;
                Energy vehicleEnergy;

                string stringVehicleType = ChooseFromListOfOptions(Enum.GetNames(typeof(eVehicleType)));
                eVehicleType vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), stringVehicleType);
                string wheelsVendor = GetUserInput<string>("Enter the vendor of your vehicle's wheels.");
                string stringCurrentAirPressure = GetUserInput<float>("Enter current air pressure of all wheels.");
                float wheelsCurrentAirPressure = float.Parse(stringCurrentAirPressure);
                string stringEnergyType = ChooseFromListOfOptions(Enum.GetNames(typeof(eEngineType)));
                eEngineType energyType = (eEngineType)Enum.Parse(typeof (eEngineType), stringEnergyType);
                
                switch (energyType)
                {
                    case eEngineType.Fuel:
                        string stringFuelType = ChooseFromListOfOptions(Enum.GetNames(typeof(eFuelType)));
                        fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), stringFuelType);
                        stringCurrentEnergy = GetUserInput<float>("Enter your vehicle's current energy (or fuel).");
                        currentEnergy = float.Parse(stringCurrentEnergy);
                        break;

                    case eEngineType.Electric:
                        stringCurrentEnergy = GetUserInput<float>("Enter your vehicle's current energy (or fuel).");
                        currentEnergy = float.Parse(stringCurrentEnergy);
                        break;
                }

                switch (vehicleType)
                {

                }
            }
        }

        public void ShowLicensePlatesList()
        {
            List<string> licensePlatesList;
            string[] vehicleStatusFilter = new string[4];
            vehicleStatusFilter[0] = eVehicleStatus.InRepair.ToString();
            vehicleStatusFilter[1] = eVehicleStatus.Repaired.ToString();
            vehicleStatusFilter[2] = eVehicleStatus.Paid.ToString();
            vehicleStatusFilter[3] = "None";

            Console.Clear();
            Console.WriteLine("You chose to see list of license plates in the garage. Please enter the type of filter you would like to perform.");
            string userChoice = ChooseFromListOfOptions(vehicleStatusFilter);
            licensePlatesList = userChoice == "None" ? m_Garage.GetLicensePlatesList() : 
                m_Garage.GetLicensePlatesList((eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), userChoice));
            Console.WriteLine(Environment.NewLine);
            foreach(string licensePlate in licensePlatesList)
            {
                Console.WriteLine(licensePlate);
            }
        }

        public void ChangeVehicleStatus()
        {
            Console.Clear();
            Console.WriteLine("You chose to change status of vehicle in the garage. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            Console.WriteLine("Please chose new status of vehicle with license plate: {0}", vehicleLicensePlate);
            string choiceOfStatus = ChooseFromListOfOptions(Enum.GetNames(typeof(eVehicleStatus)));
            eVehicleStatus newVehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), choiceOfStatus);
            m_Garage.ChangeVehicleStatus(vehicleLicensePlate, newVehicleStatus);
            Thread.Sleep(100);
            Console.WriteLine("The status of vehicle with license plate {0} successfully changed to {1}.");
        }

        public void InflateWheelsAirPressure()
        {
            Console.Clear();
            Console.WriteLine("You chose to inflate air pressure of the wheels to maximum. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            m_Garage.InflateWheelsToMaximum(vehicleLicensePlate);
            Thread.Sleep(100);
            Console.WriteLine("The air pressure in all wheels of vehicle with license plate {0} is inflated to the maximum {1}", 
                vehicleLicensePlate, m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ClientVehicle.GetMaxAirPressure());
        }

        public void RefillRegularVehicle()
        {
            Console.Clear();
            Console.WriteLine("You chose to fill fuel to a regular vehicle. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            Console.WriteLine("Please chose fuel type of vehicle with license plate: {0}", vehicleLicensePlate);
            string choiceOfFuelType = ChooseFromListOfOptions(Enum.GetNames(typeof(eFuelType)));
            string choiceOfFuelAmount = GetUserInput<float>("Enter amount of fuel that you would like to fill (in liters):");
            m_Garage.RefillRegularVehicle(vehicleLicensePlate, (eFuelType)Enum.Parse(typeof(eFuelType), choiceOfFuelType), float.Parse(choiceOfFuelAmount));
            Thread.Sleep(100);
            Console.WriteLine("Filling fuel for the vehicle with license plate {0} completed! The current amount of fuel is {1} liters", 
                vehicleLicensePlate, m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.CurrentEnergy);
        }

        public void RefillElectricVehicle()
        {
            Console.Clear();
            Console.WriteLine("You chose to charge an elecrtic vehicle. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            string choiceOfMinutesToCharge = GetUserInput<float>("Enter the number of minutes you wolud like to charge the vehicle:");
            m_Garage.RefillElectricVehicle(vehicleLicensePlate, int.Parse(choiceOfMinutesToCharge));
            Thread.Sleep(100);
            Console.WriteLine("Charging the vehicle with license plate {0} completed! The current battery is {1} hours",
                vehicleLicensePlate, m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.CurrentEnergy);
        }

        // Need to implement method that showing specific vehicle details
    }
}
