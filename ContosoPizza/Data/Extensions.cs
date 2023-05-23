namespace ContosoPizza.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PizzaContext>();

                context.Database.EnsureCreated();   //EnsureCreated cria um novo banco de dados se ele não existir
                DbInitializer.Initializer(context); //passa o PizzaContext como um parâmetro para o DB
            }
        }
    }
}
