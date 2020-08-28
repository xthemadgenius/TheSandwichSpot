using TheSandwichSpot.Model;
using TheSandwichSpot.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TheSandwichSpot.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            sandwiches = GetSandwich();
        }

        ObservableCollection<Sandwich> sandwiches;
        public ObservableCollection<Sandwich> Sandwiches
        {
            get { return sandwiches; }
            set
            {
                sandwiches = value;
                OnPropertyChanged();
            }
        }

        private Sandwich selectedSandwich;
        public Sandwich SelectedSandwich
        {
            get { return selectedSandwich; }
            set
            {
                selectedSandwich = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayBurger);

        private void DisplayBurger()
        {
            if (selectedSandwich != null)
            {
                var viewModel = new DetailsViewModel { SelectedSandwich = selectedSandwich, Sandwiches = sandwiches, Position = sandwiches.IndexOf(selectedSandwich) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Sandwich> GetSandwich()
        {
            return new ObservableCollection<Sandwich>
            {
                new Sandwich { Name = "CLASSIC", Price = 12.99f, Image = "sand3.png", Description = "Dutch Cruch Bread, Ham, Turkey, Lettuce, tomatoes, cheese"},
                new Sandwich { Name = "DOUBLE", Price = 19.99f, Image = "sand2.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "SHARK", Price = 17.29f, Image = "sand4.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "CHICKEN", Price = 15.99f, Image = "sand5.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "MEAT", Price = 11.99f, Image = "sand6.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "BBQ", Price = 13.99f, Image = "sand1.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "MODELO", Price = 11.99f, Image = "modelo.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "MODELO", Price = 13.99f, Image = "modelob.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "WHITE CLAW", Price = 11.99f, Image = "whiteclaw.png", Description = "Beer made for Basic Bithces and Simps"},
                new Sandwich { Name = "CORONA", Price = 13.99f, Image = "corona.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Sandwich { Name = "BUD LIGHT", Price = 11.99f, Image = "budlight.png", Description = "Lame Cheap beer"},
                new Sandwich { Name = "MOJITO", Price = 13.99f, Image = "mojito.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"}
            };
        }
    }
}