﻿namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 21,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                }
           );


           modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Title = "This Is How You Lose the Time War",
                    Description = "Among the ashes of a dying world, an agent of the Commandment finds a letter. It reads: Burn before reading.\r\n\r\nThus begins an unlikely correspondence between two rival agents hellbent on securing the best possible future for their warring factions. Now, what began as a taunt, a battlefield boast, becomes something more. Something epic. Something romantic. Something that could change the past and the future.\r\n\r\nExcept the discovery of their bond would mean the death of each of them. There’s still a war going on, after all. And someone has to win. That’s how war works, right?\r\n\r\nCowritten by two beloved and award-winning sci-fi writers, This Is How You Lose the Time War is an epic love story spanning time and space.",
                    ImageUrl = "https://m.media-amazon.com/images/I/413wMSCwmML._SX331_BO1,204,203,200_.jpg",
                    Price = 9.99m,
                    CategoryId = 1
                    
                },
                new Product
                {
                    Id = 2,
                    Title = "Lessons in Chemistry: A Novel",
                    Description = "Chemist Elizabeth Zott is not your average woman. In fact, Elizabeth Zott would be the first to point out that there is no such thing as an average woman. But it’s the early 1960s and her all-male team at Hastings Research Institute takes a very unscientific view of equality. Except for one: Calvin Evans; the lonely, brilliant, Nobel–prize nominated grudge-holder who falls in love with—of all things—her mind. True chemistry results. \r\n\r\nBut like science, life is unpredictable. Which is why a few years later Elizabeth Zott finds herself not only a single mother, but the reluctant star of America’s most beloved cooking show Supper at Six. Elizabeth’s unusual approach to cooking (“combine one tablespoon acetic acid with a pinch of sodium chloride”) proves revolutionary. But as her following grows, not everyone is happy. Because as it turns out, Elizabeth Zott isn’t just teaching women to cook. She’s daring them to change the status quo.  \r\n\r\nLaugh-out-loud funny, shrewdly observant, and studded with a dazzling cast of supporting characters, Lessons in Chemistry is as original and vibrant as its protagonist.",
                    ImageUrl = "https://m.media-amazon.com/images/I/71yNgTMEcpL.jpg",
                    Price = 12.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "The Body Keeps the Score: Brain, Mind, and Body in the Healing of Trauma",
                    Description = "Trauma is a fact of life. Veterans and their families deal with the painful aftermath of combat; one in five Americans has been molested; one in four grew up with alcoholics; one in three couples have engaged in physical violence. Dr. Bessel van der Kolk, one of the world’s foremost experts on trauma, has spent over three decades working with survivors. In The Body Keeps the Score, he uses recent scientific advances to show how trauma literally reshapes both body and brain, compromising sufferers’ capacities for pleasure, engagement, self-control, and trust. He explores innovative treatments—from neurofeedback and meditation to sports, drama, and yoga—that offer new paths to recovery by activating the brain’s natural neuroplasticity. Based on Dr. van der Kolk’s own research and that of other leading specialists, The Body Keeps the Score exposes the tremendous power of our relationships both to hurt and to heal—and offers new hope for reclaiming lives.",
                    ImageUrl = "https://m.media-amazon.com/images/I/41T-XHe8-EL._SX323_BO1,204,203,200_.jpg",
                    Price = 21.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Price = 4.99m,
                    Title = "The Matrix",
                    Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                    CategoryId = 21
                },
                new Product
                {
                    Id = 5,
                    Price = 3.99m,
                    Title = "Back to the Future",
                    Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                    CategoryId = 21
                },
                new Product
                {
                    Id = 6,
                    Price = 2.99m,
                    Title = "Toy Story",
                    Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                    CategoryId = 21

                },
                new Product
                {
                    Id = 7,
                    Title = "Half-Life 2",
                    Price = 49.99m,
                    Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 8,
                    Title = "Diablo II",
                    Price = 9.99m,
                    Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 9,
                    Price = 14.99m,
                    Title = "Day of the Tentacle",
                    Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 10,
                    Price = 159.99m,
                    Title = "Xbox",
                    Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 11,
                    Price = 79.99m,
                    Title = "Super Nintendo Entertainment System",
                    Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                    CategoryId = 3,
                }
            );
        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}


    }
}
