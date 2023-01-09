using collectables.Models;
using collectables.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace collectables.ViewModels
{
    internal class VerzamelingViewModel : BaseViewModel
    {
        private Verzameling _selectedVerzameling;

        public ObservableCollection<Verzameling> Verzamelingen { get; }
        public Command LoadVerzamelingCommand { get; }
        public Command AddVerzamelingCommand { get; }
        public Command<Verzameling> VerzamelingTapped { get; }

        public VerzamelingViewModel()
        {
            Title = "Browse";
            Verzamelingen = new ObservableCollection<Verzameling>();
            LoadVerzamelingCommand = new Command(async () => await ExecuteLoadVerzamelingCommand());

            VerzamelingTapped = new Command<Verzameling>(OnVerzamelingSelected);

            AddVerzamelingCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadVerzamelingCommand()
        {
            IsBusy = true;

            try
            {
                Verzamelingen.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in Verzamelingen)
                {
                    Verzamelingen.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedVerzameling = null;
        }

        public Verzameling SelectedVerzameling
        {
            get => _selectedVerzameling;
            set
            {
                SetProperty(ref _selectedVerzameling, value);
                OnVerzamelingSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnVerzamelingSelected(Verzameling item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.VerzamelingID}");
        }
    }
}
