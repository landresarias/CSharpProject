
namespace MovieCSProj_Luis_20220321.Models;

public class TrendingSet{
    public int page { get; set; }
    public List<Trending> results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}

