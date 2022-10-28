using BolWallet.Helpers;

namespace BolWallet.Extensions;

public static class RegistrationExtensions
{
	public static IServiceCollection RegisterViewAndViewModelSubsystem(this IServiceCollection services)
	{
		services.AddSingleton<IViewModelToViewBinder>(new ViewModelToViewBinder());
		services.AddSingleton<IViewModelToViewResolver, ViewModelToViewResolver>();
		
		services
			.BindViewModelToView<MainViewModel, MainPage>()
			.BindViewModelToView<CreateCodenameViewModel, CreateCodenamePage>();
		
		return services;
	}
	
	private static IServiceCollection BindViewModelToView<TViewModel, TView>(this IServiceCollection services)
		where TViewModel : class
		where TView: class
	{
		services.AddTransient<TViewModel>();
		services.AddTransient<TView>();

		var binder = services.BuildServiceProvider().GetService<IViewModelToViewBinder>();
		
		if (binder is null)
		{
			binder = new ViewModelToViewBinder();
			services.AddSingleton(binder);
		}
		
		binder.Bind<TViewModel, TView>();

		return services;
	}
}