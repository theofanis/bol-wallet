namespace BolWallet.Models;
public class AppCodename
{
    public string Codename { get; set; }
    public bool IsActive { get; set; }

    public AppCodename(string codename, bool isActive)
    {
        this.Codename = codename;
        this.IsActive = isActive;
    }
}
