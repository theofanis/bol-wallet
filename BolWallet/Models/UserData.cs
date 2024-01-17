﻿using Bol.Core.Model;

namespace BolWallet.Models;
public class UserData
{
    public NaturalPerson Person { get; set; }
    public string Codename { get; set; }
    public List<Country> Citizenships { get; set; }
    public string Edi { get; set; }
    public string BirthCountryCode { get; set; }
    public GenericHashTable GenericHashTable { get; set; }
    public List<EncryptedCitizenshipForm> EncryptedCitizenshipForms { get; set; } = new List<EncryptedCitizenshipForm>();
    public Bol.Core.Model.BolWallet BolWallet { get; set; }
    public string WalletPassword { get; set; }
}
