using System.Globalization;
using habit_tracker;
using Microsoft.Data.Sqlite;



namespace habit_tracker
{
    class Program
    {
        static readonly string ConnectionString = "Data Source=habit-tracker.db";
        static readonly HabitRecord[] Data = new HabitRecord[]
{
    // Day 1
    new HabitRecord { Date = new DateTime(2026, 1, 1), Habit = "Water", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 1), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 1), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 1), Habit = "Reading", Quantity = 20 },
    new HabitRecord { Date = new DateTime(2026, 1, 1), Habit = "Meditation", Quantity = 1 },

    // Day 2
    new HabitRecord { Date = new DateTime(2026, 1, 2), Habit = "Water", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 2), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 2), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 2), Habit = "Reading", Quantity = 25 },
    new HabitRecord { Date = new DateTime(2026, 1, 2), Habit = "Meditation", Quantity = 1 },

    // Day 3
    new HabitRecord { Date = new DateTime(2026, 1, 3), Habit = "Water", Quantity = 10 },
    new HabitRecord { Date = new DateTime(2026, 1, 3), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 3), Habit = "Sleep", Quantity = 6 },
    new HabitRecord { Date = new DateTime(2026, 1, 3), Habit = "Reading", Quantity = 30 },
    new HabitRecord { Date = new DateTime(2026, 1, 3), Habit = "Meditation", Quantity = 0 },

    // Day 4
    new HabitRecord { Date = new DateTime(2026, 1, 4), Habit = "Water", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 4), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 4), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 4), Habit = "Reading", Quantity = 15 },
    new HabitRecord { Date = new DateTime(2026, 1, 4), Habit = "Meditation", Quantity = 1 },

    // Day 5
    new HabitRecord { Date = new DateTime(2026, 1, 5), Habit = "Water", Quantity = 11 },
    new HabitRecord { Date = new DateTime(2026, 1, 5), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 5), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 5), Habit = "Reading", Quantity = 40 },
    new HabitRecord { Date = new DateTime(2026, 1, 5), Habit = "Meditation", Quantity = 1 },

    // Day 6
    new HabitRecord { Date = new DateTime(2026, 1, 6), Habit = "Water", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 6), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 6), Habit = "Sleep", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 6), Habit = "Reading", Quantity = 10 },
    new HabitRecord { Date = new DateTime(2026, 1, 6), Habit = "Meditation", Quantity = 0 },

    // Day 7
    new HabitRecord { Date = new DateTime(2026, 1, 7), Habit = "Water", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 7), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 7), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 7), Habit = "Reading", Quantity = 22 },
    new HabitRecord { Date = new DateTime(2026, 1, 7), Habit = "Meditation", Quantity = 1 },

    // Day 8
    new HabitRecord { Date = new DateTime(2026, 1, 8), Habit = "Water", Quantity = 10 },
    new HabitRecord { Date = new DateTime(2026, 1, 8), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 8), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 8), Habit = "Reading", Quantity = 35 },
    new HabitRecord { Date = new DateTime(2026, 1, 8), Habit = "Meditation", Quantity = 1 },

    // Day 9
    new HabitRecord { Date = new DateTime(2026, 1, 9), Habit = "Water", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 9), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 9), Habit = "Sleep", Quantity = 6 },
    new HabitRecord { Date = new DateTime(2026, 1, 9), Habit = "Reading", Quantity = 18 },
    new HabitRecord { Date = new DateTime(2026, 1, 9), Habit = "Meditation", Quantity = 0 },

    // Day 10
    new HabitRecord { Date = new DateTime(2026, 1, 10), Habit = "Water", Quantity = 12 },
    new HabitRecord { Date = new DateTime(2026, 1, 10), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 10), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 10), Habit = "Reading", Quantity = 50 },
    new HabitRecord { Date = new DateTime(2026, 1, 10), Habit = "Meditation", Quantity = 1 },

    // Day 11
    new HabitRecord { Date = new DateTime(2026, 1, 11), Habit = "Water", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 11), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 11), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 11), Habit = "Reading", Quantity = 12 },
    new HabitRecord { Date = new DateTime(2026, 1, 11), Habit = "Meditation", Quantity = 1 },

    // Day 12
    new HabitRecord { Date = new DateTime(2026, 1, 12), Habit = "Water", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 12), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 12), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 12), Habit = "Reading", Quantity = 28 },
    new HabitRecord { Date = new DateTime(2026, 1, 12), Habit = "Meditation", Quantity = 0 },

    // Day 13
    new HabitRecord { Date = new DateTime(2026, 1, 13), Habit = "Water", Quantity = 10 },
    new HabitRecord { Date = new DateTime(2026, 1, 13), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 13), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 13), Habit = "Reading", Quantity = 33 },
    new HabitRecord { Date = new DateTime(2026, 1, 13), Habit = "Meditation", Quantity = 1 },

    // Day 14
    new HabitRecord { Date = new DateTime(2026, 1, 14), Habit = "Water", Quantity = 11 },
    new HabitRecord { Date = new DateTime(2026, 1, 14), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 14), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 14), Habit = "Reading", Quantity = 45 },
    new HabitRecord { Date = new DateTime(2026, 1, 14), Habit = "Meditation", Quantity = 1 },

    // Day 15
    new HabitRecord { Date = new DateTime(2026, 1, 15), Habit = "Water", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 15), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 15), Habit = "Sleep", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 15), Habit = "Reading", Quantity = 20 },
    new HabitRecord { Date = new DateTime(2026, 1, 15), Habit = "Meditation", Quantity = 0 },

    // Day 16
    new HabitRecord { Date = new DateTime(2026, 1, 16), Habit = "Water", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 16), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 16), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 16), Habit = "Reading", Quantity = 38 },
    new HabitRecord { Date = new DateTime(2026, 1, 16), Habit = "Meditation", Quantity = 1 },

    // Day 17
    new HabitRecord { Date = new DateTime(2026, 1, 17), Habit = "Water", Quantity = 10 },
    new HabitRecord { Date = new DateTime(2026, 1, 17), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 17), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 17), Habit = "Reading", Quantity = 26 },
    new HabitRecord { Date = new DateTime(2026, 1, 17), Habit = "Meditation", Quantity = 1 },

    // Day 18
    new HabitRecord { Date = new DateTime(2026, 1, 18), Habit = "Water", Quantity = 12 },
    new HabitRecord { Date = new DateTime(2026, 1, 18), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 18), Habit = "Sleep", Quantity = 6 },
    new HabitRecord { Date = new DateTime(2026, 1, 18), Habit = "Reading", Quantity = 55 },
    new HabitRecord { Date = new DateTime(2026, 1, 18), Habit = "Meditation", Quantity = 0 },

    // Day 19
    new HabitRecord { Date = new DateTime(2026, 1, 19), Habit = "Water", Quantity = 9 },
    new HabitRecord { Date = new DateTime(2026, 1, 19), Habit = "Exercise", Quantity = 1 },
    new HabitRecord { Date = new DateTime(2026, 1, 19), Habit = "Sleep", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 19), Habit = "Reading", Quantity = 30 },
    new HabitRecord { Date = new DateTime(2026, 1, 19), Habit = "Meditation", Quantity = 1 },

    // Day 20
    new HabitRecord { Date = new DateTime(2026, 1, 20), Habit = "Water", Quantity = 8 },
    new HabitRecord { Date = new DateTime(2026, 1, 20), Habit = "Exercise", Quantity = 0 },
    new HabitRecord { Date = new DateTime(2026, 1, 20), Habit = "Sleep", Quantity = 7 },
    new HabitRecord { Date = new DateTime(2026, 1, 20), Habit = "Reading", Quantity = 24 },
    new HabitRecord { Date = new DateTime(2026, 1, 20), Habit = "Meditation", Quantity = 1 }
};

        static void Main()
        {
            using (var connection = new SqliteConnection(ConnectionString))
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
            
            SeedData();

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

        private static void SeedData()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            foreach (var habit in Data)
            {
                var cmd = connection.CreateCommand();
                cmd.Transaction = transaction;

                cmd.CommandText =
                    @"INSERT INTO Habits (Date, Habit, Quantity)
          VALUES ($date, $habit, $quantity);";

                cmd.Parameters.AddWithValue("$date", habit.Date);
                cmd.Parameters.AddWithValue("$habit", habit.Habit);
                cmd.Parameters.AddWithValue("$quantity", habit.Quantity);

                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
        }

        private static void GetAllRecords()
        {
            Console.Clear();

            using (var connection = new SqliteConnection(ConnectionString))
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

            using (var connection = new SqliteConnection(ConnectionString))
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
            using (var connection = new SqliteConnection(ConnectionString))
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

            using (var connection = new SqliteConnection(ConnectionString))
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

            using (var connection = new SqliteConnection(ConnectionString))
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



