using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
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

        //logic
        ILoadLogic logic;

        //profilok listája
        public ObservableCollection<string> Profiles { get; set; }



        //properties
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



        //icommandok
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




        //ctor
        public LoadWindowViewModel(ILoadLogic logic)
        {
            this.logic = logic;
            logic.LoadAssets();

            Profiles = new ObservableCollection<String>(logic.PlayerList);


            LoadPlayerCommand = new RelayCommand(
                () => { logic.LoadPlayer(selectedProfile); },
                () => { return selectedProfile != null; }
                );
            DeletePlayerCommand = new RelayCommand(
                () => { logic.DeletePlayer(selectedProfile); },
                () => { return selectedProfile != null; }
                );


            //Messenger.Register<ShopWindowViewModel, string, string>(this, "LoadInfo", (recipient, msg) =>
            //{
            //    OnPropertyChanged("CurrentAmmo");


            //});

        }



    }
}
