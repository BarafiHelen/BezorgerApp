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
        public string SignatureBase64 { get; set; }
        public string SignedBy { get; set; }

        public ICommand SaveSignatureCommand { get; }

        public SignatureViewModel()
        {
            SaveSignatureCommand = new Command(() => Save());
        }

        private void Save()
        {
            // Handtekening opslaan of versturen
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
