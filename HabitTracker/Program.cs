using System.Globalization;
using Microsoft.Data.Sqlite;

namespace habit_tracker
{
    class Program
    {
        static readonly string _connectionString = "Data Source=habit-tracker.db";

        static void Main()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS habits (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Habit TEXT,
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
                Console.WriteLine("Type 2 to View Records for a specific habit");
                Console.WriteLine("Type 3 to Insert record");
                Console.WriteLine("Type 4 to Delete record");
                Console.WriteLine("Type 5 to Update record");
                Console.WriteLine("-------------------------------------\n");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("\nGoodbye!\n");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        GetAllRecords();
                        break;
                    case "2":
                        GetHabitRecords();
                        break;
                    case "3":
                        Insert();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        Update();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 - 5.\n");
                        break;
                }
            }
        }

        private static void GetAllRecords()
        {
            Console.Clear();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = 
                    $"SELECT * FROM habits";

                List<HabitRecord> tableData = new();
                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new HabitRecord
                            {
                                Id = reader.GetInt32(0),
                                Habit = reader.GetString(1),
                                Date = DateTime.ParseExact(reader.GetString(2), "dd-MM-yy", new CultureInfo("en-US")),
                                Quantity = reader.GetInt32(3)
                            });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                
                connection.Close();

                Console.WriteLine("-------------------------------------\n");
                Console.WriteLine("ID | HABIT | DATE | QUANTITY");
                foreach (var record in tableData)
                {
                    Console.WriteLine($"{record.Id} - {record.Habit} - {record.Date.ToString("dd-MMM-yyyy")} - {record.Quantity}");
                }
                
                Console.WriteLine("\n-------------------------------------\n");
            }
        }

        private static void GetHabitRecords()
        {
            Console.Clear();

            Console.WriteLine("\n\nPlease type the name of the habit you would like to retrieve records for.\n\n");

            string habit = Console.ReadLine();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    $"SELECT * FROM habits WHERE Lower(Habit) = '{habit.ToLower()}'";

                List<HabitRecord> tableData = new();
                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new HabitRecord
                            {
                                Id = reader.GetInt32(0),
                                Habit = reader.GetString(1),
                                Date = DateTime.ParseExact(reader.GetString(2), "dd-MM-yy", new CultureInfo("en-US")),
                                Quantity = reader.GetInt32(3)
                            });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }

                connection.Close();

                Console.WriteLine("-------------------------------------\n");
                Console.WriteLine("ID | HABIT | DATE | QUANTITY");
                foreach (var record in tableData)
                {
                    Console.WriteLine(
                        $"{record.Id} - {record.Habit} - {record.Date.ToString("dd-MMM-yyyy")} - {record.Quantity}");
                }

                Console.WriteLine("\n-------------------------------------\n");
            }

        }

        private static void Insert()
        {
            string date = GetDateInput();

            string habit = GetHabitInput("\n\nPlease type the habit you would like to track or type 0 to go to the main menu.\n\n");
            
            int quantity =
                GetNumberInput(
                    "\n\nPlease insert quantity to track (no decimals allowed)\n\n");
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"INSERT INTO habits(habit, date, quantity) VALUES('{habit}', '{date}', '{quantity}')";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        private static void Delete()
        {
            Console.Clear();
            GetAllRecords();

            var recordId = GetNumberInput("\n\nPlease type the ID of the record you want to delete or type 0 to go to the main menu.\n\n");

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"DELETE from habits where Id = '{recordId}'";

                int rowCount = tableCmd.ExecuteNonQuery();

                if (rowCount == 0)
                {
                    Console.WriteLine($"\n\nRecord with ID {recordId} doesn't exist.\n\n");
                    Delete();
                }

                Console.WriteLine($"Record with ID {recordId} has been deleted. Press any key to continue.\n\n");
                Console.ReadKey();
                GetUserInput();
            }
        }

        private static void Update()
        {
            GetAllRecords();

            var recordId =
                GetNumberInput(
                    "\n\nPlease type the ID of the habit record you would like to update. Type 0 to return to the main menu.\n\n");

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var checkCmd = connection.CreateCommand();
                checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM habits WHERE id = {recordId})";
                int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (checkQuery == 0)
                {
                    Console.WriteLine($"\n\nRecord with Id {recordId} doesn't exist.\n\n");
                    connection.Close();
                    Update();
                }

                string date = GetDateInput();
                string habit = GetHabitInput("\n\nPlease enter the name of the habit to update.\n\n");
                int quantity =
                    GetNumberInput(
                        "\n\nPlease insert quantity to track (no decimals allowed)\n\n");
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = $"UPDATE habits SET habit = '{habit}', date = '{date}', quantity = {quantity} WHERE Id = {recordId}";

                tableCmd.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        private static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to the main menu.\n\n");

            string dateInput = Console.ReadLine();

            if (dateInput == "0") GetUserInput();

            while (!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\n\nInvalid date. (Format: dd-mm-yy). Type 0 to return to the main menu.\n\n");
                dateInput = Console.ReadLine();
            }

            return dateInput;
        }

        private static int GetNumberInput(string message)
        {
            Console.WriteLine(message);

            string numberInput = Console.ReadLine();

            if (numberInput == "0") GetUserInput();

            while (!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.WriteLine("\n\nInvalid number. Try again.\n\n");
                numberInput = Console.ReadLine();
            }

            int finalInput = Convert.ToInt32(numberInput);

            return finalInput;
        }

        private static string GetHabitInput(string message)
        {
            Console.WriteLine(message);

            string habitInput = Console.ReadLine();
            
            if (habitInput == "0") GetUserInput();

            return habitInput;
            
        }
    }

    public class HabitRecord
    {
        public int Id { get; init; }
        public string Habit { get; init; }
        public DateTime Date { get; init; }
        public int Quantity { get; init; }
    }
}



