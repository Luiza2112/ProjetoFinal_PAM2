using AppFeedback.ViewModels;

namespace AppFeedback.Views;

public partial class ListagemFeedbackView : ContentPage
{
    private ListagemFeedbackViewModel viewModel;
    public ListagemFeedbackView()
	{
		InitializeComponent();

        viewModel = new ListagemFeedbackViewModel();
        BindingContext = viewModel;
        Title = "Feedbacks - App Feedbacks TCC";
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListagemFeedbackViewModel vm)
        {
            await vm.ObterFeedbacks();
        }
    }

}