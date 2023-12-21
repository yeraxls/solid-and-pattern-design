/*
El patrón Mediator es un patrón de diseño de comportamiento que permite reducir las dependencias caóticas entre objetos. 
El patrón restringe las comunicaciones directas entre los objetos y los obliga a colaborar solo a través de un objeto mediador.
En .NET Core, el patrón Mediator se puede implementar utilizando la biblioteca MediatR. 
MediatR proporciona una base de clases para implementar el patrón Mediator, así como una serie de funciones auxiliares para facilitar su uso.
Ejemplo paso a paso
Para ilustrar el uso del patrón Mediator en .NET Core, consideremos el siguiente ejemplo:
Una aplicación web tiene una pantalla de inicio de sesión que permite a los usuarios iniciar sesión en el sistema. 
La pantalla de inicio de sesión debe comunicarse con el servidor para verificar las credenciales del usuario.
Una forma de implementar este escenario sería crear dos clases: una clase LoginScreen que represente la pantalla de inicio de sesión 
y una clase LoginService que represente el servicio de inicio de sesión. La clase LoginScreen llamaría al método Login 
de la clase LoginService para verificar las credenciales del usuario.
Este enfoque tiene el inconveniente de crear una dependencia directa entre la clase LoginScreen y la clase LoginService. 
Si la clase LoginService cambia, la clase LoginScreen también debe cambiar.
Para evitar este problema, podemos utilizar el patrón Mediator. En este caso, el mediador sería una clase que encapsularía la comunicación
 entre la clase LoginScreen y la clase LoginService.
El siguiente código muestra cómo implementar este escenario utilizando el patrón Mediator:
*/
public interface ILoginMediator{
    public Task<bool> LoginAsync(LoginCommand command);
}
public interface ILoginService{
    public Task<bool> LoginAsync(string username, string password);
}
public class LoginMediator : ILoginMediator
{
    private readonly ILoginService _loginService;

    public LoginMediator(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<bool> LoginAsync(LoginCommand command)
    {
        return await _loginService.LoginAsync(command.Username, command.Password);
    }
}

public class LoginScreen
{
    private readonly ILoginMediator _loginMediator;

    public LoginScreen(ILoginMediator loginMediator)
    {
        _loginMediator = loginMediator;
    }

    public async Task<bool> LoginAsync()
    {
        var command = new LoginCommand
        {
            Username = "user",
            Password = "password"
        };

        return await _loginMediator.LoginAsync(command);
    }
}

public class LoginCommand
{
    public string Username { get; set; }
    public string Password { get; set; }
}


/*
En este ejemplo, la clase LoginMediator encapsula la comunicación entre la clase LoginScreen y la clase LoginService. 
La clase LoginScreen no tiene conocimiento directo de la clase LoginService. 
En su lugar, llama al método LoginAsync de la clase LoginMediator para verificar las credenciales del usuario.
El método LoginAsync de la clase LoginMediator llama al método LoginAsync de la clase LoginService para realizar la verificación de las credenciales.
Este enfoque tiene la ventaja de reducir la dependencia entre la clase LoginScreen y la clase LoginService. 
Si la clase LoginService cambia, la clase LoginScreen no necesita cambiar.
Ventajas del patrón Mediator
El patrón Mediator tiene las siguientes ventajas:

Reduce las dependencias entre objetos.
Facilita la prueba de objetos.
Hace que el código sea más fácil de mantener y depurar.

Desventajas del patrón Mediator
El patrón Mediator tiene las siguientes desventajas:

Puede aumentar la complejidad del código.
Puede dificultar la comprensión de cómo se comunican los objetos.

Conclusión
El patrón Mediator es una herramienta útil para reducir las dependencias entre objetos. 
Puede ser una buena opción para aplicaciones que requieren un alto grado de flexibilidad y mantenibilidad.
*/