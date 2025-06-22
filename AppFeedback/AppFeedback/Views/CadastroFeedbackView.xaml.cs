using AppFeedback.ViewModels;

namespace AppFeedback.Views;

public partial class CadastroFeedbackView : ContentPage
{
	private CadastroFeedbackViewModel cadViewModel;
	public CadastroFeedbackView()
	{
		InitializeComponent();

		cadViewModel = new CadastroFeedbackViewModel();
		BindingContext = cadViewModel;
		Title = "Novo Feedback";
	}
}