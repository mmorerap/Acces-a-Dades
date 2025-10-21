

using dbdemo.DTO;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class FamiliaValidator
{
    public static Result Validate(FamiliaRequest familia)
    {
        if (familia.Nom is null )
        {
            return Result.Failure("No ha posat cap Nom a la familia","NOM_EMPTY");
        }
        return Result.Ok();
    }

}