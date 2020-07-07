using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelloWorld.Annotations;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class HelloWorldViewModel : INotifyPropertyChanged
    {
        private string _text;

        public HelloWorldViewModel()
        {
            Text = "Hello, World!";
            
            ResetCommand = new Command(() =>
            {
                Text = String.Empty;
            });
        }

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }
        
        public Command ResetCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}