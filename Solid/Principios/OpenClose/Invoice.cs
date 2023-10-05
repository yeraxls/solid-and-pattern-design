/*
Esto haría que al trabajar con interfaces, y cada clase lleva su propia lógica,
en caso de ampliarse el número de bebidas en el futuro, 
simplemente habría que crear la nueva clase, 
pero el método para calcular el precio no haría falta.
abierto a la extensión, pero cerrado a la modificación.
Al mismo tiempo se le ha añadido una clase abstracta, ya que no trabajaremos con ella
para reutilizar parámetros, haciendo un override para pisar el método GetPrice
*/
public class Invoice
{
    public decimal GetTotal(List<IDrink> lstDrinks)
    {
        decimal total = 0;
        foreach (var drink in lstDrinks)
        {
            total += drink.GetPrice();
        }
        return total;
    }
}

public interface IDrink
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Invoice { get; set; }
    public decimal GetPrice();
}
public abstract class Drink : IDrink
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Invoice { get; set; }
    public abstract decimal GetPrice();
}

public class Water : Drink
{
    public override decimal GetPrice()
    {
        return Price * Invoice;
    }
}

public class Alcohol : Drink
{
    public decimal Promo { get; set; }
    public override decimal GetPrice()
    {
        return (Price * Invoice) - Promo;
    }
}

public class Sugary : Drink
{
    public decimal Expiration { get; set; }
    public override decimal GetPrice()
    {
        return (Price * Invoice) - Expiration;
    }
}
public class Energizing : Drink
    {
        public decimal Expiration { get; set; }
        public override decimal GetPrice()
        {
            return (Price * Invoice) - Expiration;
        }
    }