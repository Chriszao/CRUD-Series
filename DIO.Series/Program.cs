using System;
using Entities;
using Entities.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thanks for using our services =)");
            Console.ReadKey();
        }
        private static void ListSeries()
        {
            Console.WriteLine("\t\t\t*****List Series***** ");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No series registered");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.ReturnDeleted();

                Console.WriteLine($"#ID: {serie.ReturnId()} - {serie.ReturnTitle()}{(deleted ? " *Excluido*" : "")}.");
            }
            Console.ReadKey();
        }

        private static void InsertSeries()
        {
            Console.Clear();

            Console.WriteLine("\t\t\t*****Insert new serie*****");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Enter the genre as shown above: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the title of the serie: ");
            string titleInput = Console.ReadLine();

            Console.Write("Enter the year of release of the series: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the serie description: ");
            string descriptionInput = Console.ReadLine();

            Serie newSerie = new Serie(
                id: repository.NextId(),
                genre: (Genre)genreInput,
                title: titleInput,
                year: yearInput,
                description: descriptionInput
            );
            repository.Insert(newSerie);
            Console.WriteLine("Registration successfully inserted. Press enter to go back to the title screen");
            Console.ReadKey();
        }
        private static void UpdateSeries()
        {
            Console.Write("Enter serie Id: ");
            int index = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Enter the genre as shown above: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the title of the serie: ");
            string titleInput = Console.ReadLine();

            Console.Write("Enter the year of release of the series: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the serie description: ");
            string descriptionInput = Console.ReadLine();

            Serie updateSerie = new Serie(
                id: index,
                genre: (Genre)genreInput,
                title: titleInput,
                year: yearInput,
                description: descriptionInput
            );
            repository.Update(index, updateSerie);
            Console.WriteLine("Registration successfully updated. Press enter to go back to the title screen");
            Console.ReadKey();
        }
        private static void DeleteSeries()
        {
            Console.Write("Enter serie Id: ");
            int index = int.Parse(Console.ReadLine());

            Console.Write("Are you sure you want to delete the series? (Y/N)");
            char option = char.Parse(Console.ReadLine().ToUpper());

            if (option == 'Y')
            {
                repository.Delete(index);
                return;
            }
            return;
        }
        private static void ViewSeries()
        {
            Console.Write("Enter the series Id: ");
            int index = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(index);
            Console.WriteLine(serie);
            Console.WriteLine("\nPress enter to go back to the title screen...");
            Console.ReadKey();
        }

        private static string GetUserOption()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\t***** DIO series catalog*****");
            Console.WriteLine("1 - List series;");
            Console.WriteLine("2 - Insert new series;");
            Console.WriteLine("3 - Update series;");
            Console.WriteLine("4 - Delete series;");
            Console.WriteLine("5 - View series;");
            Console.WriteLine("C - Clear screen;");
            Console.WriteLine("X - Exit.");
            Console.WriteLine();

            Console.Write("\t\t\tSelect an option: \n");
            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
