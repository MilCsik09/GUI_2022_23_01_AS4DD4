using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
using GUI_2022_23_01_AS4DD4.WPF.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_2022_23_01_AS4DD4.WPF.Viewmodels
{
    public class LoadWindowViewModel : ObservableRecipient
    {

        ILoadLogic logic;
        
        public ObservableCollection<string> Profiles { get; set; }


        private String selectedProfile;
        public String SelectedProfile
        {
            get { return selectedProfile; }
            set
            {
                SetProperty(ref selectedProfile, value);
                (LoadPlayerCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();
                
            }
        }

        public ICommand LoadPlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public LoadWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<ILoadLogic>())
        {

        }

        public LoadWindowViewModel(ILoadLogic logic)
        {
            this.logic = logic;

            logic.LoadAssets();

            Profiles = new ObservableCollection<String>(logic.PlayerList);

            LoadPlayerCommand = new RelayCommand(
                () => {Window current = Application.Current.MainWindow;
                        Player player = logic.LoadPlayer(selectedProfile);
                        MainWindow mw = new MainWindow(player);
                        current.Close();
                        App.Current.MainWindow = mw;
                        mw.Show();
                        
                },
                () => selectedProfile != null
                );
            DeletePlayerCommand = new RelayCommand(
                () => {Window current = Application.Current.MainWindow;
                        logic.DeletePlayer(selectedProfile);
                        LoadWindow lw = new LoadWindow();
                        current.Close();
                        Application.Current.MainWindow = lw;
                        lw.Show();
                        
                },
                () => selectedProfile != null
                );

            Messenger.Register<LoadWindowViewModel, string, string>(this, "PlayerInfo", (recipient, msg) =>
            {
                OnPropertyChanged("LoadPlayerCommand");
                OnPropertyChanged("DeletePlayerCommand");


            });

        }

    }
}
