
namespace MovieCSProj_Luis_20220321;

public class Fetch{
    public TrendingSet? trendingSet;
    public MovieUpcomingSet? movieUpcomingSet;
    public PosterSet? posterSet;
    public MovDetails? movieDetails;
    public VideoSet? videoSet;
    public CastSet? castSet;
    public Actor? actorDetails;
    public ProfileSet? profileSet;
    public HttpClient request = new HttpClient();
    public HttpResponseMessage RespMessage = new HttpResponseMessage();
    public const string API_PREFIX = "https://api.themoviedb.org/3/";
    public const string API_KEY = "b5a5beafd36eebba20564e5ee6a1fbf1";
    public string? searchList {get; set;}
    public string? Details {get; set;}
    public string? Videos {get; set;}
    public string? Cast {get; set;}
    public int age;
    
    //########################################################################
    //----Method gets the latest movie trends over the past week------
    public async Task GetTrending(){
        ClearHeaders();
        RespMessage = await request.GetAsync(API_PREFIX 
            +"trending/movie/week?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            searchList = await RespMessage.Content.ReadAsStringAsync();
            trendingSet = JsonSerializer.Deserialize<TrendingSet>(searchList);
        }
        else{
            searchList = null;
        }
    }

    //########################################################################
    //----Method gets the upcoming movies at the theaters------
    public async Task GetUpcoming(){
        ClearHeaders();
        RespMessage = await request.GetAsync(API_PREFIX
            +"movie/upcoming?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            searchList = await RespMessage.Content.ReadAsStringAsync();
            movieUpcomingSet = JsonSerializer.Deserialize<MovieUpcomingSet>(searchList);
        }
        else{
            searchList = null;
        }
    }

    //########################################################################
    //----Method recieves a argument string from Index.cshtml.cs(search)------
    public async Task MovieSearch(string search){
        ClearHeaders();
        RespMessage = await request.GetAsync(API_PREFIX 
            +"search/movie?api_key="+API_KEY+"&query="+ search);
        if(RespMessage.IsSuccessStatusCode){
            searchList = await RespMessage.Content.ReadAsStringAsync();
            posterSet = JsonSerializer.Deserialize<PosterSet>(searchList);
        }
        else{
            await GetTrending();
            await GetUpcoming();
            searchList = null;
        }
    }

    //########################################################################
    //----Method recieves a argument string from Index.cshtml.cs(movieID)-----
    public async Task GetMovieDetails(string movieID){
        ClearHeaders();
        //To use for movieDetails
        RespMessage = await request.GetAsync(API_PREFIX +"movie/" + movieID 
            + "?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            Details = await RespMessage.Content.ReadAsStringAsync();
            movieDetails = JsonSerializer.Deserialize<MovDetails>(Details);
            await GetTrending();
        }
        
        //To use for Videos inside <div>movieDetails 
        RespMessage = await request.GetAsync(API_PREFIX +"movie/" + movieID 
            + "/videos?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            Videos = await RespMessage.Content.ReadAsStringAsync();
            videoSet = JsonSerializer.Deserialize<VideoSet>(Videos);
        }

        //To use for cast actors list inside <div>movieDetails 
        RespMessage = await request.GetAsync(API_PREFIX +"movie/" + movieID 
            + "/credits?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            Cast = await RespMessage.Content.ReadAsStringAsync();
            castSet = JsonSerializer.Deserialize<CastSet>(Cast);
        }
    }

    //########################################################################
    //----Method recieves a argument string from Index.cshtml.cs(movieID)-----
    public async Task GetActorDetails(string id){
        ClearHeaders();
        RespMessage = await request.GetAsync(API_PREFIX +"person/" + id 
            + "?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            Details = await RespMessage.Content.ReadAsStringAsync();
            actorDetails = JsonSerializer.Deserialize<Actor>(Details);
        }

        RespMessage = await request.GetAsync(API_PREFIX +"person/" + id 
            + "/images?api_key="+API_KEY);
        if(RespMessage.IsSuccessStatusCode){
            Details = await RespMessage.Content.ReadAsStringAsync();
            profileSet = JsonSerializer.Deserialize<ProfileSet>(Details);
        }
    }

    //########################################################################
    public void ClearHeaders(){
        request.DefaultRequestHeaders.Accept.Clear();
        request.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.
            MediaTypeWithQualityHeaderValue("applicationException/json"));
    }

}