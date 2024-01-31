using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project_2
{
    internal class Program
    {
        static Dictionary<string, int> doctorAppointments = new Dictionary<string, int>();
        static Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();

        static string filePath = @"C:\Users\Home Computers\Desktop\patients_data.txt";
        static string filePath2 = @"C:\Users\Home Computers\Desktop\patients_data.txt";
        static string[,] doctorsData = new string[,]
        {
        {"1", "John Doe", "E12345", "555-123-4567", "2022-05-15"},
        {"2", "Jane Smith", "E23456", "555-234-5678", "2021-08-22"},
        {"3", "Alex Johnson", "E34567", "555-345-6789", "2023-01-10"},
        {"4", "Emily Davis", "E45678", "555-456-7890", "2022-11-30"},
        {"5", "Robert Brown", "E56789", "555-567-8901", "2023-03-05"},
        {"6", "Sarah White", "E67890", "555-678-9012", "2021-12-18"},
        {"7", "Michael Lee", "E78901", "555-789-0123", "2022-07-03"},
        {"8", "Olivia Miller", "E89012", "555-890-1234", "2023-09-14"},
        {"9", "Daniel Clark", "E90123", "555-901-2345", "2022-04-02"},
        {"10", "Sophia Brown", "E01234", "555-012-3456", "2023-06-20"}
        };
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\"HOSPITAL MANAGEMENT SYSTEM\"\n");
            while (true)
            {
                Console.WriteLine("\n1. Patient\n2. Doctor\n3. HOD\n4. Exit");
                Console.Write("\nSelect user type: ");
                int userType = int.Parse(Console.ReadLine());

                switch (userType)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        SearchDoctor();
                        break;
                    case 3:
                        HODOptions();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }
        static void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\"FOR PATIENTS\"");
            Console.Write("\nEnter patient's name: ");
            string name = Console.ReadLine().ToLower();
            Console.Write("Enter patient's ID: ");
            string id = Console.ReadLine().ToLower();
            Console.Write("Enter patient's date of birth: ");
            string dob = Console.ReadLine().ToLower();
            Console.Write("Enter patient's age: ");
            string age = Console.ReadLine().ToLower();
            Console.Write("Enter patient's phone number: ");
            string phoneNumber = Console.ReadLine().ToLower();
            Console.Write("Enter patient's disease: ");
            string disease = Console.ReadLine().ToLower();

            Console.WriteLine("Which doctor would you like to consult:");
            string doctorChoice = Console.ReadLine().ToLower();

            if (doctorAppointments.ContainsKey(doctorChoice))
            {
                doctorAppointments[doctorChoice]++;
                if (doctorPatients.ContainsKey(doctorChoice))
                {
                    doctorPatients[doctorChoice].Add(name);
                }
                else
                {
                    doctorPatients.Add(doctorChoice, new List<string> { name });
                }
            }
            else
            {
                doctorAppointments.Add(doctorChoice, 1);
                doctorPatients.Add(doctorChoice, new List<string> { name });
            }

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string patientData = $"{id} | {name} | {dob} | {age} | {phoneNumber} | {disease} | {doctorChoice} | {currentDate}";

            // Saving patient data with a separate heading in the text file
            File.AppendAllText(filePath, "Patients" + Environment.NewLine);
            File.AppendAllText(filePath, patientData + Environment.NewLine);
            Console.WriteLine("Patient added successfully!");

            bool habi = false;
            string[] habitual = new string[5];
            habitual[0] = "ali";
            habitual[1] = "saba";
            habitual[2] = "zainab";
            habitual[3] = "muqaddas";
            habitual[4] = "amema";
            habitual[4] = "bushra";
            habitual[4] = "haleema";
            habitual[4] = "asma";
            for (int i = 0; i < 5; i++)
            {
                if (name == habitual[i])
                {
                    habi = true;
                    break; ;
                }

            }
            if (habi == true)
            {
                Console.WriteLine("\nYou are a habitual patient. Congratulations! You will get a discount!");
            }
            else
            {
                Console.WriteLine("\nWelcome! You are a new patient.");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("\tEnter prescription details:");
            Console.WriteLine("\nEnter medicines and their prices (press enter to finish):");
            double totpay = 0, dis = 0, pay;

            while (true)
            {
                Console.Write("\nMedicine name: ");
                string medicine = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(medicine))
                {
                    break;
                }
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());
                totpay += price;
            }
            if (habi == true)
            {
                dis = totpay * 0.5;
                pay = totpay - dis;
            }
            else
            {
                dis = 0;
                pay = totpay;
            }
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\"PRISCRIPTION RECEIPT\"");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Date: {0}\t\tDoctor: {1}", currentDate, doctorChoice);
            Console.WriteLine("\nName:{0}\nPhone no:{1}\n\n\n\t\tTotal Amount:  {2}\n\t\tDiscount = {3}\n\t\tTotal Payment = {4}", name, phoneNumber, totpay, dis, pay);
            Console.WriteLine("\n\n\t\tHOPE YOU GET WELL SOON!");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        static void SearchDoctor()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\"FOR DOCTORS\"");
            Console.Write("\nEnter doctor's name: ");
            string doctorName = Console.ReadLine().ToLower();

            bool doctorFound = false;

            for (int i = 0; i < doctorsData.GetLength(0); i++)
            {
                if (doctorsData[i, 1].Equals(doctorName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nDoctor found:");
                    Console.WriteLine("S.No: {0}, Name: {1}, Employee No.: {2}, Phone No.: {3}, Date of Joining: {4}",
                        doctorsData[i, 0], doctorsData[i, 1], doctorsData[i, 2], doctorsData[i, 3], doctorsData[i, 4]);

                    doctorFound = true;
                    break;
                }
            }

            if (!doctorFound)
            {
                Console.WriteLine("Doctor not found!");
                return;
            }

            if (doctorAppointments.ContainsKey(doctorName))
            {
                int appointments = doctorAppointments[doctorName];
                Console.WriteLine($"\nDoctor {doctorName} has {appointments} appointment(s) today.");
                if (doctorPatients.ContainsKey(doctorName))
                {
                    Console.WriteLine("\nPatients who have appointments:");
                    foreach (var patient in doctorPatients[doctorName])
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nDoctor {doctorName} has no appointments today.");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }


        static void HODOptions()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\n\t\t\t\"FOR HEAD OF DEPARTMENT\"");
                Console.WriteLine("\n1. Inspect\n2. Change\n3. Exit");
                Console.Write("Select option: ");
                int hodOption = int.Parse(Console.ReadLine());

                switch (hodOption)
                {
                    case 1:
                        InspectData();
                        break;
                    case 2:
                        ChangeData();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void InspectData()
        {
            Console.WriteLine("\n1. Patient\n2. Doctor");
            Console.Write("Select data type to inspect: ");
            int dataType = int.Parse(Console.ReadLine());

            switch (dataType)
            {
                case 1:
                    DisplayPatientData();
                    break;
                case 2:
                    DisplayDoctorData();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void DisplayPatientData()
        {
            Console.Clear();
            string[] allPatients = File.ReadAllLines(filePath);
            bool patientDataFound = false;

            Console.WriteLine("\nAll Patients:\n");
            foreach (var dataLine in allPatients)
            {
                if (dataLine == "Patients")
                {
                    // Skip the heading
                    continue;
                }

                Console.WriteLine(dataLine);
                patientDataFound = true;
            }

            if (!patientDataFound)
            {
                Console.WriteLine("No patient data found.");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }
        static void DisplayDoctorData()
        {
            Console.Clear();
            Console.WriteLine("\nAll Doctors:\n");
            for (int i = 0; i < doctorsData.GetLength(0); i++)
            {
                Console.WriteLine("S.No: {0}, Name: {1}, Employee No.: {2}, Phone No.: {3}, Date of Joining: {4}",
                    doctorsData[i, 0], doctorsData[i, 1], doctorsData[i, 2], doctorsData[i, 3], doctorsData[i, 4]);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

        }

        static void ChangeData()
        {
            Console.WriteLine("\n1. Patient\n2. Doctor");
            Console.Write("Select data type to change: ");
            int dataType = int.Parse(Console.ReadLine());

            switch (dataType)
            {
                case 1:
                    UpdatePatientData();
                    break;
                case 2:
                    UpdateDoctorData();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void UpdatePatientData()
        {
            Console.Clear();
            Console.Write("Enter patient's ID to update: ");
            string patientId = Console.ReadLine();

            string[] allPatients = File.ReadAllLines(filePath);
            bool patientFound = false;

            for (int i = 0; i < allPatients.Length; i++)
            {
                if (allPatients[i] == "Patients")
                {
                    // Skip the heading
                    continue;
                }

                string[] patientFields = allPatients[i].Split('|');
                if (patientFields[0].Trim().Equals(patientId, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Select field to update:\n1. Name\n2. ID\n3. Date of Birth\n4. Age\n5. Phone Number");
                    Console.Write("Enter choice: ");
                    int fieldChoice = int.Parse(Console.ReadLine());

                    Console.Write("\nEnter new value: ");
                    string newValue = Console.ReadLine().Trim();

                    switch (fieldChoice)
                    {
                        case 1:
                            patientFields[1] = newValue;
                            break;
                        case 2:
                            patientFields[0] = newValue;
                            break;
                        case 3:
                            patientFields[2] = newValue;
                            break;
                        case 4:
                            patientFields[3] = newValue;
                            break;
                        case 5:
                            patientFields[4] = newValue;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. No changes made.");
                            return;
                    }

                    allPatients[i] = string.Join("|", patientFields);
                    File.WriteAllLines(filePath, allPatients);

                    Console.WriteLine("\n\tPatient data updated successfully!");
                    patientFound = true;
                    break;
                }
            }

            if (!patientFound)
            {
                Console.WriteLine("Patient not found!");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }

        static void UpdateDoctorData()
        {
            Console.Clear();
            Console.Write("\nEnter doctor's Employee No. to update: ");
            string doctorEmployeeNo = Console.ReadLine().ToLower();

            for (int i = 0; i < doctorsData.GetLength(0); i++)
            {
                if (doctorsData[i, 2].Equals(doctorEmployeeNo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nSelect field to update:\n1. Name\n2. Employee No.\n3. Phone No.\n4. Date of Joining");
                    Console.Write("Enter choice: ");
                    int fieldChoice = int.Parse(Console.ReadLine());

                    Console.Write("\nEnter new value: ");
                    string newValue = Console.ReadLine().Trim();

                    switch (fieldChoice)
                    {
                        case 1:
                            doctorsData[i, 1] = newValue;
                            break;
                        case 2:
                            doctorsData[i, 2] = newValue;
                            break;
                        case 3:
                            doctorsData[i, 3] = newValue;
                            break;
                        case 4:
                            doctorsData[i, 4] = newValue;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. No changes made.");
                            return;
                    }

                    UpdateFileFromDoctorsData();
                    Console.WriteLine("\n\tDoctor data updated successfully!");
                    return;
                }
            }

            Console.WriteLine("Doctor not found!");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }

        static void UpdateFileFromDoctorsData()
        {
            using (StreamWriter writer = new StreamWriter(filePath2))
            {
                for (int i = 0; i < doctorsData.GetLength(0); i++)
                {
                    string doctorData = string.Format("{0} | {1} | {2} | {3} | {4}",
                        doctorsData[i, 0], doctorsData[i, 1], doctorsData[i, 2], doctorsData[i, 3], doctorsData[i, 4]);
                    writer.WriteLine(doctorData);
                }
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        }
    }
}