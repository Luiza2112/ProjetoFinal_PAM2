using AppFeedback.ViewModels;

namespace AppFeedback.Views;

public partial class ListagemFeedbackView : ContentPage
{
    ListagemFeedbackViewModel viewModel;
    public ListagemFeedbackView()
	{
		InitializeComponent();

        viewModel = new ListagemFeedbackViewModel();
        BindingContext = viewModel;
        Title = "Feedbacks - App Feedbacks TCC";
    }
}