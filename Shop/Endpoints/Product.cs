using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;

namespace dbdemo.Endpoints;

public static class EndpointsProduct
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/products", () =>
        {
            List<Product> products = ProductADO.GetAll(dbConn);
            return Results.Ok(products);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            Product product = ProductADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(product)
                : Results.NotFound(new { message = $"Product with Id {id} not found." });


        });




        // POST /products
        app.MapPost("/products", (ProductRequest req) =>
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Code = req.Code,
                Name = req.Name,
                Price = req.Price
            };

            ProductADO.Insert(dbConn, product);

            return Results.Created($"/products/{product.Id}", product);
        });
    }


}

public record ProductRequest(string Code, string Name, decimal Price);  // Com ha de llegir el POST

