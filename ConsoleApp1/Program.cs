using System;
using VideoAppBLL;
using VideoAppEntity;

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
                "Exit",
            };

            var selection = 0;

            while (selection != 5)
            {
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
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");
            Console.ReadLine();
        }

        private static void EditVideo()
        {
            var videoFound = FindVideoByID();
            if (videoFound != null)
            {
                Console.WriteLine("Title: ");
                videoFound.Title = Console.ReadLine();
                Console.WriteLine("Director: ");
                videoFound.Director = Console.ReadLine();
                bllFacade.VideoService.Update(videoFound);
            }
            else
            {
                Console.WriteLine("Video not found!");
            }
        }

        private static Video FindVideoByID()
        {
            Console.WriteLine("Type in the ID of the video:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {
            var customerFound = FindVideoByID();
            if (customerFound != null)
            {
                bllFacade.VideoService.Delete(customerFound.Id);
            }
            var response = customerFound == null ? "Video not found" : "Video was deleted";
            Console.WriteLine(response);
        }

        private static void AddVideo()
        {
            Console.WriteLine("Title:");
            var title = Console.ReadLine();

            Console.WriteLine("Director:");
            var director = Console.ReadLine();
            
            bllFacade.VideoService.Create(new Video()
            {
                Title = title,
                Director = director,
                Genre = Genre.Action
            });
        }

        private static void ListVideos()
        {
            Console.WriteLine("\nList of Customers:");
            bllFacade.VideoService.GetAll().ForEach(v =>
                Console.WriteLine($"ID: {v.Id} | Title: {v.Title} | Director: {v.Director} | Genre: {v.Genre}"));
            Console.WriteLine("");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}:{menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 5)
            {
                Console.WriteLine("You need to select a number between 1-5");
            }

            Console.WriteLine($"Selection: {selection}");
            return selection;
        }
    }
}