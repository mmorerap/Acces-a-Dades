using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;

namespace dbdemo.Endpoints;

public static class EndpointsFamilia
{
    public static void MapFamiliaEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/familia", () =>
        {
            List<Familia> familias = FamiliaADO.GetAll(dbConn);
            return Results.Ok(familias);
        });

        // GET Familia by id
        app.MapGet("/familia/{id}", (Guid id) =>
        {
            Familia familia = FamiliaADO.GetById(dbConn, id)!;

            return familia is not null
                ? Results.Ok(familia)
                : Results.NotFound(new { message = $"Familia with Id {id} not found." });


        });




        // POST /familia
        app.MapPost("/familia", (FamiliaRequest req) =>
        {
            Familia familia = new Familia
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom,
                Descripcio = req.Descripcio
            };

            FamiliaADO.Insert(dbConn, familia);

            return Results.Created($"/products/{familia.Id}", familia);
        });
    }


}

public record FamiliaRequest(string Nom, string Descripcio);  // Com ha de llegir el POST

