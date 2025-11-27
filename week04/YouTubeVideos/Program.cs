using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Skateboard", "Devon Hibbert", 420);
        video1.AddComment(new Comment("Sam", "Great tutorial!"));
        video1.AddComment(new Comment("Alex", "I finally learned to ollie."));
        video1.AddComment(new Comment("Chris", "More skate content please!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("AI for Beginners", "John Tech", 600);
        video2.AddComment(new Comment("Emily", "This made things so clear."));
        video2.AddComment(new Comment("Marcus", "Awesome explanation!"));
        video2.AddComment(new Comment("Tina", "Please make a part 2."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Easy Meal Prep", "Chef Lisa", 300);
        video3.AddComment(new Comment("David", "Tried this today. Amazing!"));
        video3.AddComment(new Comment("Rosa", "Super helpful for busy people."));
        video3.AddComment(new Comment("Kevin", "Great video as always."));
        videos.Add(video3);

        // Display video info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}
