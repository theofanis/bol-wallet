﻿using System.Text.Encodings.Web;

namespace BolWallet;
internal class Constants
{
    public const string BirthDateFormat = "yyyy-MM-dd";
    public const string MainNet = "mainnet";
    public const string TestNet = "testnet";
    
    public static readonly JsonSerializerOptions WalletJsonSerializerDefaultOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };
}
