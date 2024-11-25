using CommunityToolkit.Maui.Alerts;

namespace BolWallet.Views;

public partial class GetCertifiedPage : ContentPage
{
    private CancellationTokenSource _cts;

    public GetCertifiedPage(GetCertifiedViewModel getCertifiedViewModel)
	{
		InitializeComponent();
		BindingContext = getCertifiedViewModel;

        if (DeviceInfo.Platform != DevicePlatform.iOS &&
            DeviceInfo.Platform != DevicePlatform.MacCatalyst)
        {
            return;
        }
        
        var saveLogfileToolbarItem = ToolbarItems.First(x => x.Text == "Save Logfile");
        saveLogfileToolbarItem.Order = ToolbarItemOrder.Primary;
        saveLogfileToolbarItem.Priority = 0;
        saveLogfileToolbarItem.IconImageSource = ImageSource.FromFile("zip");

        var closeWalletToolbarItem = ToolbarItems.First(x => x.Text == "Close Wallet");
        closeWalletToolbarItem.Order = ToolbarItemOrder.Primary;
        closeWalletToolbarItem.Priority = 1;
        closeWalletToolbarItem.IconImageSource = ImageSource.FromFile("logout");
        
        ToolbarItems.Clear();
        ToolbarItems.Add(saveLogfileToolbarItem);
        ToolbarItems.Add(closeWalletToolbarItem);
    }
	protected override async void OnAppearing()
	{
		base.OnAppearing();
        _cts = new CancellationTokenSource();
		await ((GetCertifiedViewModel)BindingContext).Initialize(_cts.Token);
	}

    protected override void OnDisappearing()
    {
        _cts.Cancel();
        base.OnDisappearing();
    }

    private void OnTapCopy(object sender, EventArgs e)
	{
		if (sender is Label label)
		{
			Clipboard.Default.SetTextAsync(label.Text);

            ((GetCertifiedViewModel)BindingContext).CertifierCodename = label.Text;
			Toast.Make("Copied to Clipboard").Show();
		}
	}
}
