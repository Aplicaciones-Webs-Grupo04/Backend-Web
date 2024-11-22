using psymed_platform.Profiles.Domain.Model.Commands;
using psymed_platform.Profiles.Interfaces.REST.Resources;

namespace psymed_platform.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for transforming CreateProfileResource to CreateProfileCommand.
/// </summary>
public static class CreateProfileCommandFromResourceAssembler
{
    /// <summary>
    /// Transforms a CreateProfileResource to a CreateProfileCommand.
    /// </summary>
    /// <param name="resource">The resource to transform.</param>
    /// <returns>The created command.</returns>
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        if (resource == null)
            throw new ArgumentNullException(nameof(resource), "Resource cannot be null");

        return new CreateProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Weight,
            resource.Height,
            resource.Phone,
            resource.Role
        );
    }
}