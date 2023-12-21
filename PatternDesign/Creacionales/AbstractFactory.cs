public abstract class AbstractFactory
{
    public abstract AbstractHerbivore CreateHerbivore();
    public abstract AbstractCarnivore CreateCarnivore();
}

public abstract class AbstractHerbivore {
    public void Eat(){

    }
 }
public abstract class AbstractCarnivore {
    public void Eat(){
        
    }
 }
public class AfricaFactory : AbstractFactory
{
    public override AbstractHerbivore CreateHerbivore()
    {
        return new Wildebeest();
    }

    public override AbstractCarnivore CreateCarnivore()
    {
        return new Lion();
    }
}

public class Wildebeest : AbstractHerbivore { }

public class Lion : AbstractCarnivore { }

public class AmericaFactory : AbstractFactory
{
    public override AbstractHerbivore CreateHerbivore()
    {
        return new Bison();
    }

    public override AbstractCarnivore CreateCarnivore()
    {
        return new Wolf();
    }
}
public class Bison : AbstractHerbivore { }

public class Wolf : AbstractCarnivore { }

public class Example
{
    public void ExampleAbstractFactory()
    {
        AbstractFactory factory = new AfricaFactory();
        AbstractHerbivore herbivore = factory.CreateHerbivore();
        herbivore.Eat();
    }
}


/*
El patrón Abstract Factory es un patrón de diseño creacional que proporciona una interfaz para crear familias de objetos relacionados o dependientes sin especificar sus clases concretas.
En .NET, el patrón Abstract Factory se implementa mediante dos clases abstractas:

AbstractFactory: Esta clase declara una interfaz para crear objetos de una familia de productos.
AbstractProduct: Esta clase declara una interfaz para objetos de una familia de productos.

Las clases concretas de fábrica implementan la interfaz AbstractFactory y crean objetos de la clase concreta de producto correspondiente.
Por ejemplo, supongamos que queremos crear una aplicación que represente un zoológico. El zoológico tiene animales de dos tipos: herbívoros y carnívoros.
La clase abstracta AbstractFactory podría declarar los siguientes métodos:

CreateHerbivore(): AbstractHerbivore
CreateCarnivore(): AbstractCarnivore

La clase abstracta AbstractHerbivore podría declarar los siguientes métodos:

Eat(): void

La clase abstracta AbstractCarnivore podría declarar los siguientes métodos:

Eat(): void

Las clases concretas de fábrica podrían implementar los métodos de la clase abstracta AbstractFactory para crear objetos de las clases concretas de producto correspondientes.
Por ejemplo, la clase concreta AfricaFactory podría implementar los métodos de la clase abstracta AbstractFactory de la siguiente manera:

public class AfricaFactory : AbstractFactory
{
    public AbstractHerbivore CreateHerbivore()
    {
        return new Wildebeest();
    }

    public AbstractCarnivore CreateCarnivore()
    {
        return new Lion();
    }
}

La clase concreta AmericaFactory podría implementar los métodos de la clase abstracta AbstractFactory de la siguiente manera:

public class AmericaFactory : AbstractFactory
{
    public AbstractHerbivore CreateHerbivore()
    {
        return new Bison();
    }

    public AbstractCarnivore CreateCarnivore()
    {
        return new Wolf();
    }
}


El código cliente podría usar la clase abstracta AbstractFactory para crear objetos de las clases concretas de producto correspondientes.
Por ejemplo, el siguiente código podría crear un herbívoro de África:

AbstractFactory factory = new AfricaFactory();
AbstractHerbivore herbivore = factory.CreateHerbivore();

herbivore.Eat();
El patrón Abstract Factory tiene las siguientes ventajas:

Separa la creación de objetos de su uso. Esto hace que el código sea más flexible y fácil de mantener.
Permite la creación de familias de objetos relacionados o dependientes. Esto puede simplificar la implementación de sistemas complejos.
Permite la sustitución de clases concretas de fábrica. Esto puede utilizarse para personalizar el comportamiento de un sistema.

Algunos ejemplos de uso del patrón Abstract Factory en .NET incluyen:

La creación de objetos de interfaz de usuario.
La creación de objetos de acceso a datos.
La creación de objetos de componentes de software.

En resumen, el patrón Abstract Factory es un patrón de diseño útil que puede utilizarse para simplificar la creación de familias de objetos relacionados o dependientes.
*/