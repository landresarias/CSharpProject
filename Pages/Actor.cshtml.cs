
namespace MovieCSProj_Luis_20220321.Pages;

public class ActorModel : PageModel{
    public Fetch fetch = new Fetch();
    public int age;

    public async Task OnGet(string id){
        await fetch.GetActorDetails(id);
        string birthDate = fetch.actorDetails.birthday;
        string birthYear = birthDate.Substring(0,4);
        age = DateTime.Now.Year - Convert.ToInt16(birthYear);
    }

}
