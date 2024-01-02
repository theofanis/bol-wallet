﻿using CommunityToolkit.Maui.Alerts;

namespace BolWallet.Views;
public partial class BolCommunityPage : ContentPage
{
    public BolCommunityPage(BolCommunityViewModel bolCommunityViewModel)
    {
        InitializeComponent();
        BindingContext = bolCommunityViewModel;
    }
}