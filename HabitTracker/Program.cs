using Microsoft.Data.Sqlite;

namespace habit_tracker
{
    class Program
    {
        static string connectionString = "Data Source=habit-tracker.db";

        static void Main()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drinking_water (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
            )";
                tableCmd.ExecuteNonQuery();
                connection.Close();
            }

            GetUserInput();
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application");
                Console.WriteLine("Type 1 to View All Records");
                Console.WriteLine("Type 2 to Insert record");
                Console.WriteLine("Type 3 to Delete record");
                Console.WriteLine("Type 4 to Update record");
                Console.WriteLine("-------------------------------------\n");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("\nGodobye!\n");
                        closeApp = true;
                        break;
                    case "1":
                        GetAllRecords();
                        break;
                    case "2":
                        Insert();
                        break;
                    // case "3":
                    //     Delete();
                    //     break;
                    // case "4":
                    //     Update();
                    //     break;
                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 - 4.\n");
                        break;
                }


            }
        }

        private static void Insert()
        {
            string date = GetDateInput();

            int quantity =
                GetNumberInput(
                    "\n\nPlease insert number of glasses or other measure of your choice (no decimals allowed)\n\n");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', '{quantity}')";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        private static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to the main menu.\n\n");

            string dateInput = Console.ReadLine();

            if (dateInput == "0") GetUserInput();

            return dateInput;
        }

        private static int GetNumberInput(string message)
        {
            Console.WriteLine(message);

            string numberInput = Console.ReadLine();

            if (numberInput == "0") GetUserInput();

            int finalInput = Convert.ToInt32(numberInput);

            return finalInput;
        }
    }
}



