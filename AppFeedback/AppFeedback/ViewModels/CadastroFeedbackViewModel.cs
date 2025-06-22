using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppFeedback.Models;
using AppFeedback.Services;

namespace AppFeedback.ViewModels
{
    [QueryProperty("FeedbackSelecionadoId", "fId")]
    public class CadastroFeedbackViewModel : BaseViewModel
    {
        private FeedbackService fService;
        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; set; }

        public CadastroFeedbackViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            fService = new FeedbackService(token);

            SalvarCommand = new Command(async () => { await SalvarFeedback(); });
            CancelarCommand = new Command(async => CancelarCadastro());
        }

        private async void CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }

        private int id;
        private string remetente;
        private string destinatario;
        private string descricao;
        private DateTime data;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Remetente
        {
            get => remetente;
            set
            {
                remetente = value;
                OnPropertyChanged();
            }
        }

        public string Destinatario
        {
            get => destinatario;
            set
            {
                destinatario = value;
                OnPropertyChanged();
            }
        }

        public string Descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                OnPropertyChanged();
            }
        }

        public DateTime Data
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
                    Remetente = this.remetente,
                    Destinatario = this.destinatario,
                    Descricao = this.descricao,
                    Data = this.data,
                    Id = this.id
                };
                if (model.Id == 0)
                {
                    await fService.PostFeedbackAsync(model);

                }
                else
                {
                    await fService.PutFeedbackAsync(model);
                }

                await Application.Current.MainPage
                        .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async void CarregarFeedback()
        {
            try
            {
                Feedback f = await
                    fService.GetFeedbackAsync(int.Parse(feedbackSelecionadoId));

                this.remetente = f.Remetente;
                this.destinatario = f.Destinatario;
                this.descricao = f.Descricao;
                this.data = f.Data;
                this.id = f.Id;

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private string feedbackSelecionadoId;
        public string FeedbackSelecionadoId
        {
            set
            {
                if (value != null)
                {
                    feedbackSelecionadoId = Uri.UnescapeDataString(value);
                    CarregarFeedback();
                }
            }
        }

    }
}
