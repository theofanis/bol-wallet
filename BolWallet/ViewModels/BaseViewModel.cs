using Blazing.Mvvm.ComponentModel;

namespace BolWallet.ViewModels;

public class BaseViewModel : ViewModelBase
{
    protected readonly INavigationService NavigationService;
    protected readonly ISecureRepository _secureRepository;

    public UserData userData;

    protected BaseViewModel(
        INavigationService navigationService,
        ISecureRepository secureRepository)
    {
        NavigationService = navigationService;
        _secureRepository = secureRepository;

        List<AppCodename> codenames = secureRepository.Get<List<AppCodename>>(Constants.AppCodenamesKey);
        var activeCodename = codenames?.FirstOrDefault(c => c.IsActive)?.Codename;
        userData = !string.IsNullOrEmpty(activeCodename) ? secureRepository.Get<UserData>(activeCodename) : new UserData();
    }
}
