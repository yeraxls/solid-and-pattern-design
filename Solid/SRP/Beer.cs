public class Beer {
    public string Name {get; set;}
    public string Brand {get; set;}

    public string GetInfo() => Name + " " + Brand;
}