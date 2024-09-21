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

        public void ManageApp()
        {
            bool chooseToQuit = false;
            
            do
            {
                Console.WriteLine("Welcome to the garage!");
                ManageMainMenu();
                chooseToQuit = AskForAnotherAction() == "N" ? true : false;
                if (chooseToQuit)
                {
                    Console.WriteLine("{0}You chose to exit. Thank you for using our garage!", Environment.NewLine);
                    Thread.Sleep(2000);
                }
                Console.Clear();
            } while (!chooseToQuit);
        }

        public void ManageMainMenu()
        {
            int numOfUserChoice = -1;
            bool isValidChoice = false;

            InitOptionsMenu();
            do
            {
                try
                {
                    Console.Write(Environment.NewLine);
                    string userChoice = GetUserInput<int>("Please enter the digit of the action that you would like to perform: ");
                    isValidChoice = checkIfDigitInRange(userChoice, 7);
                    numOfUserChoice = isValidChoice ? int.Parse(userChoice) : -1;
                    Console.Clear();
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.Message);
                }
            } while (!isValidChoice);

            switch (numOfUserChoice)
            {
                case 1:
                    InsertNewVehicleToGarage();
                    break;

                case 2:
                    ShowLicensePlatesList();
                    break;

                case 3:
                    ChangeVehicleStatus();
                    break;

                case 4:
                    InflateWheelsAirPressure();
                    break;

                case 5:
                    RefillRegularVehicle();
                    break;

                case 6:
                    RefillElectricVehicle();
                    break;

                case 7:
                    ShowVehicleDetails();
                    break;
            }
        }

        public void InitOptionsMenu()
        {
            string optionMenuMsg =
                String.Format("Here are the actions you can perform:" + Environment.NewLine
                + "1. Inserting new vehicle to the garage" + Environment.NewLine
                + "2. Showing all the license plates that in the garage (with option to filter by vehicle status in the garage)" + Environment.NewLine
                + "3. Changing the vehicle status in the garage" + Environment.NewLine
                + "4. Inflating the vehicle's wheels to the maximum" + Environment.NewLine
                + "5. Refilling a vehicle powered by fuel" + Environment.NewLine
                + "6. Charging an electric vehicle" + Environment.NewLine
                + "7. Showing complete vehicle data by license plate");
            Console.WriteLine(optionMenuMsg);
        }

        public string ChooseFromListOfOptions(string[] i_OptionsToList, string i_Instructions)
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
                    Console.WriteLine(i_Instructions);
                    Console.WriteLine("Below is the list of options:");
                    Console.WriteLine(messageInList.ToString());
                    Console.WriteLine("Enter the digit (between 1 to {0}) of your desired selection", i_OptionsToList.Length);
                    userDigitInput = Console.ReadLine();
                    Console.WriteLine(Environment.NewLine);
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
                    Console.WriteLine(Environment.NewLine);
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

        public void InsertNewVehicleToGarage()
        {
            Console.Clear();
            Console.WriteLine("You chose to insert a new vehicle to the garage. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Please enter your license plate: ");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                Console.WriteLine("The vehicle is already in the garage. Your vehicle's status in the garage is {0}", eVehicleStatus.InRepair);
                m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].VehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                string ownerName, ownerPhoneNumber;
                Vehicle newClientVehicle = null;
                Wheel vehicleWheel = null;
                Fuel vehicleFuel = null;
                Electric vehicleElectric = null;
                Dictionary<string, string> extraProperties = new Dictionary<string, string>();

                string stringVehicleType = ChooseFromListOfOptions(Enum.GetNames(typeof(eVehicleType)), "Please choose your vehicle's type.");
                eVehicleType vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), stringVehicleType);
                string vehicleCurrentVendor = GetUserInput<string>("Please enter your car vendor: ");
                string wheelCurrentVendor = GetUserInput<string>("Please enter your wheels vendor: ");

                switch (vehicleType)
                {
                    case eVehicleType.RegularCar:
                        vehicleWheel = createWheel("Please enter the current air pressure of the wheels: ", wheelCurrentVendor, 33f);
                        vehicleFuel = createFuelEngine("Please enter your current fuel status: ", 49f, eFuelType.Octan95);
                        string carColor = ChooseFromListOfOptions(Enum.GetNames(typeof(eCarColor)), "Please choose the color of your car.");
                        string numOfDoors = ChooseFromListOfOptions(Enum.GetNames(typeof(eNumOfCarDoors)), "Please choose the number of doors in your car.");
                        extraProperties.Add("CarColor", carColor);
                        extraProperties.Add("NumOfDoors", numOfDoors);

                        newClientVehicle = VehicleFactory.CreateVehicle(eVehicleType.RegularCar,
                            vehicleCurrentVendor,
                            vehicleLicensePlate,
                            5,
                            vehicleWheel,
                            vehicleFuel,
                            extraProperties);
        
                        break;

                    case eVehicleType.ElectricCar:
                        vehicleWheel = createWheel("Please enter the current air pressure of the wheels: ", wheelCurrentVendor, 33f);
                        vehicleElectric = createElectricEngine("Please enter your current battery status: ", 5f);
                        carColor = ChooseFromListOfOptions(Enum.GetNames(typeof(eCarColor)), "Please choose the color of your car.");
                        numOfDoors = ChooseFromListOfOptions(Enum.GetNames(typeof(eNumOfCarDoors)), "Please choose the number of doors in your car.");
                        extraProperties.Add("CarColor", carColor);
                        extraProperties.Add("NumOfDoors", numOfDoors);

                        newClientVehicle = VehicleFactory.CreateVehicle(eVehicleType.ElectricCar,
                            vehicleCurrentVendor,
                            vehicleLicensePlate,
                            5,
                            vehicleWheel,
                            vehicleElectric,
                            extraProperties);

                        break;

                    case eVehicleType.RegularMotorcycle:
                        vehicleWheel = createWheel("Please enter the current air pressure of the wheels: ", wheelCurrentVendor, 31f);
                        vehicleFuel = createFuelEngine("Please enter your current fuel status: ", 6f, eFuelType.Octan98);
                        string licenseType = ChooseFromListOfOptions(Enum.GetNames(typeof(eLicenseType)), "Please choose type of the license.");
                        string engineVolume = GetUserInput<int>("Please enter your engine volume: ");
                        extraProperties.Add("LicenseType", licenseType);
                        extraProperties.Add("EngineVolume", engineVolume);

                        newClientVehicle = VehicleFactory.CreateVehicle(eVehicleType.RegularMotorcycle,
                            vehicleCurrentVendor,
                            vehicleLicensePlate,
                            5,
                            vehicleWheel,
                            vehicleFuel,
                            extraProperties);

                        break;

                    case eVehicleType.ElectricMotorcycle:
                        vehicleWheel = createWheel("Please enter the current air pressure of the wheels: ", wheelCurrentVendor, 31f);
                        vehicleElectric = createElectricEngine("Please enter your current battery status: ", 2.7f);
                        licenseType = ChooseFromListOfOptions(Enum.GetNames(typeof(eLicenseType)), "Please choose type of the license.");
                        engineVolume = GetUserInput<int>("Please enter your engine volume: ");
                        extraProperties.Add("LicenseType", licenseType);
                        extraProperties.Add("EngineVolume", engineVolume);

                        newClientVehicle = VehicleFactory.CreateVehicle(eVehicleType.ElectricCar,
                            vehicleCurrentVendor,
                            vehicleLicensePlate,
                            5,
                            vehicleWheel,
                            vehicleElectric,
                            extraProperties);
                        break;

                    case eVehicleType.Truck:
                        vehicleWheel = createWheel("Please enter the current air pressure of the wheels: ", wheelCurrentVendor, 28f);
                        vehicleFuel = createFuelEngine("Please enter your current fuel status: ", 130f, eFuelType.Soler);
                        string[] boolArr = new string[2] {"Yes", "No"};
                        string isIncludeHazrdousMaterials = ChooseFromListOfOptions(boolArr, "Is the truck transporting hazardous materials?");
                        string luggageVolume = GetUserInput<float>("Please enter your luggage volume: ");
                        extraProperties.Add("IsIncludeHazardousMaterials", isIncludeHazrdousMaterials);
                        extraProperties.Add("LuggageVolume", luggageVolume);

                        newClientVehicle = VehicleFactory.CreateVehicle(eVehicleType.Truck,
                            vehicleCurrentVendor,
                            vehicleLicensePlate,
                            14,
                            vehicleWheel,
                            vehicleFuel,
                            extraProperties);
                        break;
                }

                ownerName = GetUserInput<string>("Please enter your name");
                ownerPhoneNumber = GetUserInput<int>("Please enter your phone number");
                m_Garage.AddNewClient(ownerName, ownerPhoneNumber, newClientVehicle);
                if (m_Garage.IsVehicleExists(vehicleLicensePlate))
                {
                    Console.WriteLine("Inserting vehicle with license plate {0} completed!");
                }
            }
        }

        private Wheel createWheel(string i_Instructions, string i_WheelVendor, float i_MaxAirPressure)
        {
            Wheel wheel = null;
            bool isValid = false;
            
            do
            {
                try
                {
                    string userInput = GetUserInput<float>(i_Instructions);
                    wheel = new Wheel(i_WheelVendor, float.Parse(userInput), i_MaxAirPressure);
                    isValid = true;
                }
                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.Message);
                }
            } while (!isValid);

            return wheel;
        }

        private Fuel createFuelEngine(string i_Instructions, float i_MaxFuel, eFuelType i_FuelType)
        {
            Fuel fuelEngine = null;
            bool isValid = false;

            do
            {
                try
                {
                    string currentFuel = GetUserInput<float>(i_Instructions);
                    fuelEngine = new Fuel(float.Parse(currentFuel), i_MaxFuel, i_FuelType);
                    isValid = true;
                }
                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.Message);
                }
            } while (!isValid);

            return fuelEngine;
        }

        private Electric createElectricEngine(string i_Instructions, float i_MaxBattery)
        {
            Electric elecrticEngine = null;
            bool isValid = false;

            do
            {
                try
                {
                    string currentBattery = GetUserInput<float>(i_Instructions);
                    elecrticEngine = new Electric(float.Parse(currentBattery), i_MaxBattery);
                    isValid = true;
                }
                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine(outOfRangeException.Message);
                }
            } while (!isValid);

            return elecrticEngine;
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
            if (m_Garage.GarageClients.Count > 0)
            {
                Console.WriteLine("You chose to see list of license plates in the garage. Follow the instructions.");
                string userChoice = ChooseFromListOfOptions(vehicleStatusFilter, "Please select the desired filter type. If you don't want to filter, select 4.");
                licensePlatesList = userChoice == "None" ? m_Garage.GetLicensePlatesList() :
                    m_Garage.GetLicensePlatesList((eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), userChoice));
                Console.WriteLine(Environment.NewLine);
                foreach (string licensePlate in licensePlatesList)
                {
                    Console.WriteLine(licensePlate);
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage.");
            }
        }

        public void ChangeVehicleStatus()
        {
            Console.Clear();
            Console.WriteLine("You chose to change status of vehicle in the garage. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                string instructionsMsg = String.Format("Please chose new status of vehicle with license plate: {0}", vehicleLicensePlate);
                string choiceOfStatus = ChooseFromListOfOptions(Enum.GetNames(typeof(eVehicleStatus)), instructionsMsg);
                eVehicleStatus newVehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), choiceOfStatus);
                m_Garage.ChangeVehicleStatus(vehicleLicensePlate, newVehicleStatus);
                Thread.Sleep(1000);
                Console.WriteLine("The status of vehicle with license plate {0} successfully changed to {1}.");
            }
            else
            {
                Console.WriteLine("Vehicle does not exist in the garage");
            }
        }

        public void InflateWheelsAirPressure()
        {
            Console.Clear();
            Console.WriteLine("You chose to inflate air pressure of the wheels to maximum. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                m_Garage.InflateWheelsToMaximum(vehicleLicensePlate);
                Thread.Sleep(1000);
                Console.WriteLine("The air pressure in all wheels of vehicle with license plate {0} is inflated to the maximum {1}",
                    vehicleLicensePlate, m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ClientVehicle.GetMaxAirPressure());
            }
            else
            {
                Console.WriteLine("Vehicle does not exist in the garage!");
            }
        }

        public void RefillRegularVehicle()
        {
            bool isCompleted = false;
            
            Console.Clear();
            Console.WriteLine("You chose to fill fuel to a regular vehicle. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                do
                {
                    try
                    {
                        string instructionsMsg = String.Format("Please chose fuel type of vehicle with license plate: {0}", vehicleLicensePlate);
                        string choiceOfFuelType = ChooseFromListOfOptions(Enum.GetNames(typeof(eFuelType)), instructionsMsg);
                        string choiceOfFuelAmount = GetUserInput<float>("Enter amount of fuel that you would like to fill (in liters):");
                        m_Garage.RefillRegularVehicle(vehicleLicensePlate, (eFuelType)Enum.Parse(typeof(eFuelType), choiceOfFuelType), float.Parse(choiceOfFuelAmount));
                        Thread.Sleep(1000);
                        Console.WriteLine("Filling fuel for the vehicle with license plate {0} completed! The current amount of fuel is {1} liters",
                            vehicleLicensePlate, m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.CurrentEnergy);
                        isCompleted = true;
                    }
                    catch (ArgumentException arguemntException)
                    {
                        Console.WriteLine(arguemntException.Message);
                    }
                    catch (ValueOutOfRangeException outOfRangeException)
                    {
                        Console.WriteLine(outOfRangeException.Message);
                    }
                } while (!isCompleted);
            }
            else
            {
                Console.WriteLine("Vehicle does not exist in the garage!");
            } 
        }

        public void RefillElectricVehicle()
        {
            bool isCompleted = false;

            Console.Clear();
            Console.WriteLine("You chose to charge an elecrtic vehicle. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                do
                {
                    try
                    {
                        string choiceOfMinutesToCharge = GetUserInput<float>("Enter the number of minutes you wolud like to charge the vehicle:");
                        m_Garage.RefillElectricVehicle(vehicleLicensePlate, int.Parse(choiceOfMinutesToCharge));
                        Thread.Sleep(1000);
                        Console.WriteLine("Charging the vehicle with license plate {0} completed! The current battery is {1} hours",
                            vehicleLicensePlate, m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.CurrentEnergy);
                        isCompleted = true;
                    }
                    catch (ArgumentException argumentException)
                    {
                        Console.WriteLine(argumentException.Message);
                    }
                    catch (ValueOutOfRangeException outOfRangeException)
                    {
                        Console.WriteLine(outOfRangeException.Message);
                    }
                } while (!isCompleted); 
            }
            else
            {
                Console.WriteLine("Vehcile does not exist in the garage!");
            } 
        }

        public void ShowVehicleDetails()
        {
            Console.Clear();
            Console.WriteLine("You chose to see details of specific vehicle. Follow the instructions.");
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            Console.WriteLine("{0}", m_Garage.IsVehicleExists(vehicleLicensePlate) ? 
                m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].ToString() :
                "Vehicle does not exist in the garage!");
        }

        public string AskForAnotherAction()
        {
            string userInput = null;
            bool isValidInput = false;

            do
            {
                try
                {
                    string anotherActionMsg = String.Format("{0}" +
                    "If you want to do another action, enter 'Y'.{0}" +
                    "Otherwise, if you want to exit, enter 'N'.", Environment.NewLine);
                    Console.WriteLine(anotherActionMsg);
                    userInput = Console.ReadLine().ToUpper();
                    isValidInput = isYesOrNoInput(userInput);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            } while (!isValidInput);
            
            return userInput;
        }

        private bool isYesOrNoInput(string i_UserInput)
        {
            bool isValidInput = true;

            if (i_UserInput != "Y" && i_UserInput != "N")
            {
                isValidInput = false;
                throw new ArgumentException("Error: Invalid input.");
            }

            return isValidInput;
        }
    }
}