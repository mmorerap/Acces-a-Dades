

/*
DTO (Data Transfer Object): És una representació simplificada de les dades que es volen transferir 
entre les capes. Sovint és una estructura més lleugera que una entitat del model de dades, amb només 
les propietats necessàries per ser transportades entre les capes. 

Per exemple, el ProductRequest és un DTO perquè encapsula només les propietats necessàries per crear o 
actualitzar un producte a través de la API, sense necessitar totes les propietats que podrien formar part 
del model de dades intern.
*/
using dbdemo.Model;

namespace dbdemo.DTO;

public record FamiliaRequest( string Name, string Descripcio) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public Product ToFamilia(Guid id)   // Conversió a model
    {

        return new Product
        {
            Id = id,
            Name = Name,
            Descripcio = Descripcio
        };
    }
}
