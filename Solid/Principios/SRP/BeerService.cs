public class BeerService {
    public void Create(Beer beer){
        var log = new Log();
        var database = new Database();
        //cada uno manejará su guardado de forma independiente y no afectará al otro en caso de cambiar
        log.save(beer.Name);

        database.save(beer.GetInfo());

    }
}