/*
Ayuda a crear objetos de una misma familia sin necesitar concretar y desacoplando las clases
ya que están sujetos a interfaces no a clases
*/
public class Factory {
    public void ProcessGameLogic(List<Entity> entities){
        entities.ForEach(e => e.UpdateLogic());
    }
}

public interface EnemyFactory {
    public Entity CreateEnemy();
}

public class GoombaFactory : EnemyFactory
{
    public Entity CreateEnemy()
    {
        return new Goomba();
    }
}

public class RandomEnemyFactory : EnemyFactory
{
    public Entity CreateEnemy()
    {
        //enemigo aleatorio
        return new Goomba();
    }
}

public class HardEnemyFactory : EnemyFactory
{
    public Entity CreateEnemy()
    {
        //enemigo aleatorio siempre los más difíciles
        return new Goomba();
    }
}


public class Boo : Entity
{
    public void UpdateLogic()
    {
        Console.WriteLine("Boo");
    }
}

public class Koopa: Entity
{
    public void UpdateLogic()
    {
        Console.WriteLine("Koopa");
    }
}

public class Goomba : Entity
{
    public void UpdateLogic()
    {
        Console.WriteLine("Goomba");
    }
}

public interface Entity{
    void UpdateLogic();
}