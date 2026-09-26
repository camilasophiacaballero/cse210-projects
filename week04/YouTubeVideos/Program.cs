using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Product Unboxing: XPhone", "TechChannel", 420);
        video1.AddComment(new Comment("Ana", "Great unboxing, very detailed!"));
        video1.AddComment(new Comment("Luis", "I love the camera samples."));
        video1.AddComment(new Comment("María", "When is the release date?"));
        videos.Add(video1);

        Video video2 = new Video("Cooking with Flavors: Spicy Pasta", "ChefCarlos", 600);
        video2.AddComment(new Comment("Sofia", "Tried this recipe, turned out amazing."));
        video2.AddComment(new Comment("Pedro", "Can you make a vegetarian version?"));
        video2.AddComment(new Comment("Rosa", "The tips about seasoning were super helpful."));
        videos.Add(video2);

        Video video3 = new Video("Silent Nature Walk", "CalmVibes", 240);
        videos.Add(video3);

        Video video4 = new Video("Gadget Review: SmartWatch Z", "GizmoReview", 480);
        video4.AddComment(new Comment("Marta", "Battery life seems impressive."));
        video4.AddComment(new Comment("Jorge", "Does it support third party apps?"));
        video4.AddComment(new Comment("Lucia", "Nice comparison with previous model."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.LengthInSeconds);
            Console.WriteLine("Number of comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");
            if (video.GetCommentCount() == 0)
            {
                Console.WriteLine(" - (No comments)");
            }
            else
            {
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
                }
            }
            Console.WriteLine(new string('-', 40));
        }

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
