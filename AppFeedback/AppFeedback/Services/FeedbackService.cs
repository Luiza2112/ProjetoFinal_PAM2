using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFeedback.Models;

namespace AppFeedback.Services
{
    public class FeedbackService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = ""; // -> Criar Azure web com a API de Feedback e colocar link url aqui

        private string _token;
        public FeedbackService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<int> PostFeedbackAsync(Feedback f)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, f, _token);
        }
        public async Task<ObservableCollection<Feedback>> GetFeedbacksAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Feedback> listaFeedbacks = await
            _request.GetAsync<ObservableCollection<Models.Feedback>>(apiUrlBase + urlComplementar,
            _token);
            return listaFeedbacks;
        }

        public async Task<Feedback> GetFeedbackAsync(int feedbackId)
        {
            string urlComplementar = string.Format("/{0}", feedbackId);
            var feedback = await _request.GetAsync<Models.Feedback>(apiUrlBase +
            urlComplementar, _token);
            return feedback;
        }

        public async Task<int> PutFeedbackAsync(Feedback f)
        {
            var result = await _request.PutAsync(apiUrlBase, f, _token);
            return result;
        }
        public async Task<int> DeleteFeedbackAsync(int feedbackId)
        {
            string urlComplementar = string.Format("/{0}", feedbackId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token);
            return result;
        }
    }
}
