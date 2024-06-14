using Reviewer.Infrastructure.Models;
using Reviewer.Services.Models.Admin;

namespace Reviewer.Services.Abstractions.Admin
{
    public interface IAdminLanguagesService : IBaseAdminService<CreateLanguageRequest, UpdateLanguageRequest, Language, LanguageResponse>
    {
    }
}
