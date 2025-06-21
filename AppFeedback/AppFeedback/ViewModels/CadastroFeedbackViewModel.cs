using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppFeedback.Models;
using AppFeedback.Services;

namespace AppFeedback.ViewModels
{
    public class CadastroFeedbackViewModel : BaseViewModel
    {
        private FeedbackService fService;
        public ICommand SalvarCommand { get; }

        public CadastroFeedbackViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            fService = new FeedbackService(token);

        }
        public int id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string remetente
        {
            get => remetente;
            set
            {
                remetente = value;
                OnPropertyChanged();
            }
        }

        public string destinatario
        {
            get => destinatario;
            set
            {
                destinatario = value;
                OnPropertyChanged();
            }
        }

        public string descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                OnPropertyChanged();
            }
        }

        public DateTime data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public async Task SalvarFeedback()
        {
            try
            {
                Feedback model = new Feedback()
                {
                    Id = this.id,
                    Remetente = this.remetente,
                    Destinatario = this.destinatario,
                    Descricao = this.descricao,
                    Data = this.data
                };
                if (model.Id == 0)
                {
                    await fService.PostFeedbackAsync(model);

                    await Application.Current.MainPage
                        .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

                    await Shell.Current.GoToAsync(".."); // Remove a página atual da pilha de páginas
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
