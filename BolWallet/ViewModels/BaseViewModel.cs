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

        userData = _secureRepository.Get<UserData>(Constants.UserDataKey);
    }
}
