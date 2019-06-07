using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Refit;
using RefitApp.Annotations;
using RefitApp.Models;
using RefitApp.Services.Concrete;
using Xamarin.Forms;

namespace RefitApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private bool _isDataDownloaded;

        public bool IsDataDownloaded
        {
            get => _isDataDownloaded;
            set
            {
                _isDataDownloaded = value;
                OnPropertyChanged(nameof(IsDataDownloaded));
            }
        }

        private bool _isExpand;

        public bool IsExpand
        {
            get => _isExpand;
            set
            {
                _isExpand = value;
                OnPropertyChanged(nameof(IsExpand));
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                CheckIsAddTitleButtonEnabled();
            }
        }

        private bool _isAddTitleButtonEnabled;

        public bool IsAddTitleButtonEnabled
        {
            get => _isAddTitleButtonEnabled;
            set
            {
                _isAddTitleButtonEnabled = value;
                OnPropertyChanged(nameof(IsAddTitleButtonEnabled));
            }
        }

        public ObservableCollection<UserResponse> Users { get; set; }

        #endregion

        #region Commands

        public ICommand GetDataCmd { get; }
        public ICommand AddCmd { get; }
        public ICommand AddTitleCmd { get; }

        #endregion


        private readonly RestApiService _apiService;

        public MainViewModel()
        {
            _apiService = new RestApiService();
            Users = new ObservableCollection<UserResponse>();
            GetDataCmd = new Command(async () => { await GetUsers(); });
            AddCmd = new Command<VisualElement>(obj => Expand(obj as StackLayout));
            AddTitleCmd = new Command(AddTitle);
        }

        private void AddTitle()
        {
            var user = new UserResponse
            {
                Title = Title
            };

            Users.Add(user);
        }

        private void Expand(StackLayout obj)
        {
            var height = 250;
            IsExpand = !IsExpand;
            obj.Children[0].HeightRequest = IsExpand ? height : 0;
        }

        public async Task GetUsers()
        {
            IsBusy = true;
            Users.Clear();
            try
            {
                var users = await _apiService.GetUsers();

                for (var i = 0; i < 10; i++)
                {
                    var random = new Random();
                    var randomIndex = random.Next(0, users.Count);
                    Users.Add(users[randomIndex]);
                }

                IsDataDownloaded = true;
            }
            catch (ApiException ex)
            {
                Debug.WriteLine($"Cannot downloaded users from API {ex.Message}");
                IsDataDownloaded = false;
            }

            finally
            {
                IsBusy = false;
            }
        }

        private void CheckIsAddTitleButtonEnabled()
        {
            IsAddTitleButtonEnabled = !string.IsNullOrEmpty(Title);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}