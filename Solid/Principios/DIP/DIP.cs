/*
Inversión de dependencia
los módulos de alto nivel no deben depender de los módulos de bajo nivel
así al sustituir un módulo, no afecta al funcionamiento de los otrosp
*/
using System.Reflection;
using System.Text.Json;
public class Inicio
{
    string origin = @"E:\proyectos\solid-and-pattern-design\Solid\Principios\DIP\posts.json";
    private readonly IMonitor _monitor;
    public Inicio(IMonitor monitor)
    {
        _monitor = monitor;
    }

    public async void prueba()
    {
        await _monitor.Show(origin);
    }
}
public class Monitor : IMonitor
{
    private readonly IInfoByFile _infoByFile;
    public Monitor(IInfoByFile infoByFile)
    {
        _infoByFile = infoByFile;
    }
    public async Task Show(string origin)
    {
        var posts = await _infoByFile.Get(origin);
        foreach (var post in posts)
        {
            Console.WriteLine(post.Title);
        }
    }
}
public interface IMonitor{
    public Task Show(string origin);
}
public class InfoByFile : IInfoByFile
{
    public async Task<IEnumerable<Post>> Get(string path)
    {
        var contentStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        IEnumerable<Post> posts =
            await JsonSerializer
                .DeserializeAsync<IEnumerable<Post>>(contentStream);
        return posts;
    }
}
public interface IInfoByFile{
    public Task<IEnumerable<Post>> Get(string path);
}
public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
}