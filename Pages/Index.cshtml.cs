
namespace MovieCSProj_Luis_20220321.Pages;

public class IndexModel : PageModel {
    public int maxVideos = 3;
    public int maxCast = 6;
    public string? convertedBudgets;
    public Fetch fetch = new Fetch();
    public string? searching;

    //########################################################################
    //----This is the class constructor--------
    public async Task OnGet(){
        await fetch.GetTrending();
        await fetch.GetUpcoming();
    }

    //########################################################################
    //---This method searches a list of requested movies and recieves an 
    //argument string from Index-searchDiv (name="search")----
    public async Task OnPostMovieSearch(string search){
        await fetch.MovieSearch(search);
        searching = search;
        await fetch.GetUpcoming();
    }

    //########################################################################
    //---This method searches a list of upcoming movies and recieves an 
    //argument string from Index-searchDiv (name="search")----
    public async Task OnPostUpcomingResults(){
        await fetch.GetUpcoming();
    }

    //########################################################################
    //---This method shows an detail of requested movie and recieves an 
    //argument string from Index-searchResults (name="movieID")----
    public async Task OnPostMovieResults(string movieID){
        await fetch.GetMovieDetails(movieID);
        //next money formating movieDetail budget 
        convertedBudgets = string.Format("{0:c}", fetch.movieDetails.budget);
        //Next adding some videos into movieDetails
        int vidCount = fetch.videoSet.results.Count;
        if(vidCount < maxVideos){
            maxVideos = vidCount;   
        }
    }

    //########################################################################
    //---This method shows an detail of requested movie and recieves an 
    //argument string from Index-castDiv (name="actorID")----
    public async Task OnPostGetActor(string actorID){
        Response.Redirect("/Actor?id="+ actorID);
    }

}
