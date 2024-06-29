namespace ConsoleAppTpFinal

{
    class Program
    {
        static async Task Main(string[] args)
        {

            string url = @"https://localhost:7154/api/Usuario";

            ConsumoApis usuarioHttp = new ConsumoApis(url);

            List<UsuarioEntitie> usuarios = await usuarioHttp.FiltrarAsync();

            foreach (UsuarioEntitie usuario in usuarios)
            {
                Console.WriteLine($"Usuario: {usuario.Nombre}");
            }
        }
    }
}