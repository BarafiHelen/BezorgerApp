using BezorgerApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BezorgerApp.ViewModels
{
    public class SignatureViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        public string SignatureBase64 { get; set; }
        public string SignedBy { get; set; }
        public int OrderId { get; set; }

        public ICommand UploadSignatureCommand { get; }

        public SignatureViewModel(ApiService apiService)
        {
            _apiService = apiService;
            UploadSignatureCommand = new Command(async () => await UploadSignature());
        }

        private async Task UploadSignature()
        {
            if (string.IsNullOrEmpty(SignatureBase64))
            {
                await Shell.Current.DisplayAlert("Fout", "Geen handtekening gevonden.", "OK");
                return;
            }

            var success = await _apiService.UploadSignatureAsync(OrderId, SignatureBase64);
            if (success)
                await Shell.Current.DisplayAlert("Succes", "Handtekening opgeslagen", "OK");
            else
                await Shell.Current.DisplayAlert("Fout", "Opslaan mislukt", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
