using Microsoft.AspNetCore.Identity;
using RaefTech.Shared.Entities;

namespace RaefTech.Server.Components.Account;

internal sealed class IdentityUserAccessor(UserManager<RaefTechUser> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<RaefTechUser> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
