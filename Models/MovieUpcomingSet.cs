
namespace MovieCSProj_Luis_20220321.Models;

public class MovieUpcomingSet {
    public MovieUpcomingDate? dates { get; set; }
    public int page { get; set; }
    public List<MovieUpcoming>? results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}
