﻿using Bol.Core.Model;

namespace BolWallet.Models;
public class UserData
{
	public NaturalPerson Person { get; set; }
	public string Codename { get; set; }
    public string[] Citizenships { get; set; }
    public string Edi { get; set; }
    public EncryptedDigitalMatrix EncryptedDigitalMatrix { get; set; }
    public Bol.Core.Model.BolWallet BolWallet { get; set; }
    public string WalletPassword { get; set; }
}
