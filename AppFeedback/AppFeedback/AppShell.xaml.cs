using AppFeedback.Views;

namespace AppFeedback
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadFeedbackView", typeof(CadastroFeedbackView));
        }
    }
}
