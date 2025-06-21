using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFeedback.Models;
using AppFeedback.Services;

namespace AppFeedback.ViewModels
{
    public class ListagemFeedbackViewModel : BaseViewModel
    {
        private FeedbackService fService;
        public ObservableCollection<Feedback> Feedbacks { get; set; }

        public ListagemFeedbackViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            fService = new FeedbackService(token);
            Feedbacks = new ObservableCollection<Feedback>();

            _ = ObterFeedbacks();
        }

        public async Task ObterFeedbacks()
        {
            try //Junto com o Catch -> Eitará que erros fechem o aplicativo
            {
                Feedbacks = await fService.GetFeedbacksAsync();
                OnPropertyChanged(nameof(Feedbacks)); // Informará a View que houve carregamento
            }
            catch (Exception ex)
            {

                //Captará o erro para exibir em tela
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }
    }
}
