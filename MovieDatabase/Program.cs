using MovieDatabase;using MovieDatabase.Models;using (MovieDBContext context = new MovieDBContext())
{
    foreach (Movie m in context.Movies)
    {
        //  Console.WriteLine(m.Title);
    }
}static List<Movie> SearchByGenre(string choice)
{
    List<Movie> result = new List<Movie>();
    using (MovieDBContext context = new MovieDBContext())
    {

        result = context.Movies.Where(m => m.Genre.ToLower().Contains(choice.ToLower())).ToList();
    }
    return result;
}static List<Movie> SearchByTitle(string choice)
{
    List<Movie> result = new List<Movie>();
    using (MovieDBContext context = new MovieDBContext())
    {
        result = context.Movies.Where(m => m.Title.ToLower().Contains(choice.ToLower())).ToList();

    }
    return result;
}
static void MovieList()
{
    using (MovieDBContext context = new MovieDBContext())
    {
        Console.WriteLine("Title: ");
        foreach (Movie m in context.Movies)
        {
            Console.WriteLine($"{m.Title}");
        }
    }
}bool RunProgram = true;
int choice1 = 0;
string choice = "";
List<Movie> movieList = new List<Movie>();

//main
    Console.WriteLine("Welcome to the Movie App.\nPick a movie by genre or title.\n");
while (RunProgram)
{
    Greeting();
    Console.Write("\nEnter 1 to search by title.\nOR \nEnter 2 to search by genre. \n\n");

    while (true)
    {
        choice1 = Validator.Validator.GetUserNumberInt();
        Console.WriteLine();

        if (choice1 == 1)
        {
            Console.Write("Please enter the title: ");
            choice = Console.ReadLine();
            movieList = SearchByTitle(choice);
            break;
        }
        else if (choice1 == 2)
        {
            Console.Write("Please enter a genre: ");
            choice = Console.ReadLine();
            movieList = SearchByGenre(choice);
            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid choice.");
        }
    }
    if (movieList.Count > 0)
    {
        Console.WriteLine(string.Format("{0,-25} {1,-10} {2,-55}", "Title", "Genre", "Runtime"));
        foreach (Movie m in movieList)
        {
            Console.WriteLine(m.ToString());
        }
    }
    else
    {
        Console.WriteLine("Sorry we dont have that.");
    }
    RunProgram = Validator.Validator.GetContinue("Do u want to search again?");
}
Console.WriteLine("Bye!");

static void Greeting()
{
    MovieList();
    Console.WriteLine("\nGenre:\nComedy\nHorror\nAction");
}





//List<Movie> movies = new List<Movie>();
//if genre {
//    movies = GetByGenre();
//}
//else if title{
//    movies = get by title
//}

//foreach (Movie m in movies)
//    Display movies
