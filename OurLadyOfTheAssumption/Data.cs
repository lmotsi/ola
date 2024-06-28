namespace OurLadyOfTheAssumption.Data;

public record Sacrament {
    public int Id {get; set;}
    public string ? Name {get; set;}
}  // end of record Church
 
public record Person {
    public string ? name {get; set;}
    public string ? role {get; set;}
}

public class ChurchDB {

    private static List<Sacrament> _sacraments = new List<Sacrament>()
   {
     new Sacrament{ Id=1, Name="Baptism" },
     new Sacrament{ Id=2, Name="Holy Communion"},
     new Sacrament{ Id=3, Name="Confirmation"} 
   };

   public static Person father = new Person{name="Fr. Sicelo Libanje OMI", role="priest"};

    public static List<Sacrament> getSacraments() {
        return _sacraments;
    } // end getSacraments

    public static Sacrament getSacrament(int id){
        return _sacraments.SingleOrDefault(sacrament => sacrament.Id == id);
    } // end getSacrament

    public static Sacrament addSacrament(Sacrament sacrament) {
        _sacraments.Add(sacrament);
        return sacrament;
    } // end of addSacrament

    public static Sacrament changeSacrament(Sacrament newSacrament) {
        _sacraments = _sacraments.Select(sacrament => {
            if (sacrament.Id == newSacrament.Id) {
                sacrament.Name = newSacrament.Name;
            }
            return sacrament;
        }).ToList();
        return newSacrament;
    } // end changeSacrament

    public static void removeSacrament(int id) {
        _sacraments = _sacraments.FindAll(sacrament => sacrament.Id != id).ToList();
    }



} // end ChurchDB