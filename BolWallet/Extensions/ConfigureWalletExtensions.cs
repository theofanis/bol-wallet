using Bol.Core.Abstractions;
using Bol.Core.Accessors;
using Bol.Core.Model;
using Bol.Core.Services;
using Microsoft.Extensions.Options;

namespace BolWallet.Extensions;
public static class ConfigureWalletExtensions
{
    public static IServiceCollection ConfigureWalletServices(this IServiceCollection services)
    {
        // Register a custom IContextAccessor by decorating the default one defined in BoL SDK.
        services.AddSingleton<WalletContextAccessor>();
        services.AddSingleton<IContextAccessor, BolWalletContextAccessor>();

        services.AddTransient<IBolService, BolService>();

        services.AddTransient<IOptions<WalletConfiguration>>((sp) =>
        {
            ISecureRepository secureRepository = sp.GetRequiredService<ISecureRepository>();

            List<AppCodename> codenames = secureRepository.Get<List<AppCodename>>(Constants.AppCodenamesKey);
            var activeCodename = codenames?.FirstOrDefault(c => c.IsActive)?.Codename;
            var userData = !string.IsNullOrEmpty(activeCodename) ? secureRepository.Get<UserData>(activeCodename) : new UserData();

            return Options.Create(new WalletConfiguration { Password = userData?.WalletPassword });
        });

        services.AddTransient<IOptions<Bol.Core.Model.BolWallet>>((sp) =>
        {
            ISecureRepository secureRepository = sp.GetRequiredService<ISecureRepository>();

            List<AppCodename> codenames = secureRepository.Get<List<AppCodename>>(Constants.AppCodenamesKey);
            var activeCodename = codenames?.FirstOrDefault(c => c.IsActive)?.Codename;
            var userData = !string.IsNullOrEmpty(activeCodename) ? secureRepository.Get<UserData>(activeCodename) : new UserData();

            return Options.Create(userData?.BolWallet);
        });

        return services;
    }
}
