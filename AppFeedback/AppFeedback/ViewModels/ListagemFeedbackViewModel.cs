using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            //_ = ObterFeedbacks();

            NovoFeedbackCommand = new Command(async () => { await ExibirCadastroFeedback(); });
            RemoverFeedbackCommand = new Command<Feedback>(async (Feedback f) => { await RemoverFeedback(f); });
        }

        public ICommand NovoFeedbackCommand { get; }
        public ICommand RemoverFeedbackCommand { get; set; }
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
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "OK");
            }
        }

        public async Task ExibirCadastroFeedback()
        {
            try
            {
                await Shell.Current.GoToAsync("cadFeedbackView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private Feedback feedbackSelecionado;
        public Feedback FeedbackSelecionado
        {
            get { return feedbackSelecionado; }
            set{
                if (value != null)
                {
                    feedbackSelecionado = value;

                    Shell.Current
                        .GoToAsync($"cadFeedbackView?fId={feedbackSelecionado.Id}");
                }
            }

        }

        public async Task RemoverFeedback(Feedback f)
        {
            try
            {
                if (await Application.Current.MainPage
                    .DisplayAlert("Confirmação", $"Confirmar remoção do feedback feito por {f.Remetente}?", "Sim", "Não"))
                {
                    await fService.DeleteFeedbackAsync(f.Id);
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Feedback removido com sucesso!", "Ok");

                    _ = ObterFeedbacks();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}
