/*
Crear interfaces pequeñas para que las clases donde se implementen sean pequeñas
va muy de la mano de sustitución de Liskov, pero liskov es sustitución y herencia
esto es interfaces, implementaciones de múltiples interfaces
por lo tanto hay que categorizar las interfaces para que no sobren campos
la segregación de interfaces es dividirla en interfaces pequeñas
*/
public class ISP {
    
}

public interface IBasicActions<T>{
    public T Get (int id);
    public List<T> GetList ();
    public void Add (T entity);
}
public interface IEditableActions<T>{
    public void Update (T entity);
    public void Delete (T entity);
}
public class UserService : IBasicActions<User>, IEditableActions<User>{
    public User Get (int id){
        Console.WriteLine("Get");
        return new();
    }
    public List<User> GetList (){
        Console.WriteLine("Getlist");
        return new List<User>();
    }
    public void Add (User entity){
        Console.WriteLine("Añadir");
    }
    public void Update (User entity){
        Console.WriteLine("Update");
    }
    public void Delete (User entity){
        Console.WriteLine("entity");
    }
}
public class SaleService : IBasicActions<Sale>{
    public Sale Get (int id){
        Console.WriteLine("Get");
        return new();
    }
    public List<Sale> GetList (){
        Console.WriteLine("Getlist");
        return new List<Sale>();
    }
    public void Add (Sale entity){
        Console.WriteLine("Añadir");
    }
}
public class User {
    public int Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}
}

public class Sale {
    public decimal Ammount {get; set;}
    public DateTime Date {get; set;}
}