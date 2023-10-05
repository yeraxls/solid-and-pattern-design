/*
si tienes una clase padre y una hija que hereda
la clase hija no debe modificar el funcionamiento de la clase padre
una clase hija puede usarse como su padre sin que tenga problemas en el software
una clase hija puede sustituir a la clase padre
En Open close se está aplicando esto con la bebida
*/
public class Liskov
{
    public void Sustituir()
    {
        T t = new S1();
        Console.WriteLine(t.GetName());
        t = new S2();
        Console.WriteLine(t.GetName());
    }
}

public abstract class T
{
    public abstract string GetName();
}
public class S1 : T
{
    public override string GetName()
    {
        return "S1";
    }
}
public class S2 : T
{
    public override string GetName()
    {
        return "S2";
    }
}