namespace CarritoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var app = Startup.InicializarApp(args); //Pasamos los argumentos que son recibidos en la ejecución.

            app.Run();


        }
    }
}