using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;

namespace ConsoleApp1
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {
            String[] menuItems =
            {
                "List All Videos",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Search Videos",
                "Exit"
            };

            var selection = 0;
            selection = ShowMenu(menuItems);
            Console.Clear();
            while (selection != 6)
            {
                Console.Clear();
                Console.WriteLine($"You chose: {selection} - {menuItems[selection - 1]}\n");
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideo();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    case 5:
                        SearchVideos();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nPress Enter to go back!");
                Console.ReadLine();
                Console.Clear();
                selection = ShowMenu(menuItems);
            }
            Console.Clear();
            Console.WriteLine("Bye bye!\n\nPress Enter to Exit!");
            Console.ReadLine();
        }

        private static void SearchVideos()
        {
            Console.WriteLine("Type what you want to search for:");
            var searchText = Console.ReadLine();
            Console.WriteLine("Here's the result:\n");
            bllFacade.VideoService.GetAll().Where(v => v.Title.ToLower().Contains(searchText.ToLower())).ToList().
                ForEach(v => Console.WriteLine($"ID: {v.Id} | Title: {v.Title}"));
            Console.WriteLine("");
        }

        private static void EditVideo()
        {
            ListVideos();
            var videoFound = GetVideoByID();
            if (videoFound != null)
            {
                Console.WriteLine("\nTitle:");
                videoFound.Title = Console.ReadLine();
                bllFacade.VideoService.Update(videoFound);
            }
            else
            {
                Console.WriteLine("\nVideo not found!");
            }
        }

        private static VideoBO GetVideoByID()
        {
            Console.WriteLine("Type in the ID of the video:\n");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {
            ListVideos();
            Console.WriteLine("");
            var customerFound = GetVideoByID();
            if (customerFound != null)
            {
                bllFacade.VideoService.Delete(customerFound.Id);
            }
            var response = customerFound == null ? "\nVideo not found" : "\nVideo was deleted";
            Console.WriteLine(response);
        }

        private static void AddVideo()
        {
            Console.WriteLine("Title:");
            var title = Console.ReadLine();
            Console.WriteLine("\nDirector:");
            var director = Console.ReadLine();
            Console.WriteLine("\nThe video has been added!");
        }

        private static bool AddMoreVideos()
        {
            Console.WriteLine("Do you want to add another video?\nInsert 'yes' or 'no'");
            string answer = Console.ReadLine();

            while (answer != "yes" || answer != "no")
            {
                Console.WriteLine("Please insert 'yes' or 'no'");
                answer = Console.ReadLine();
            }
            if (answer == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void ListVideos()
        {
            Console.WriteLine("List of Customers:\n");
            bllFacade.VideoService.GetAll().ForEach(v =>
                Console.WriteLine($"ID: {v.Id} | Title: {v.Title}"));
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}:{menuItems[i]}");
            }
            Console.WriteLine("");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6)
            {
                Console.WriteLine("You need to select a number between 1-6");
            }

            Console.WriteLine("");
            return selection;
        }
    }
}