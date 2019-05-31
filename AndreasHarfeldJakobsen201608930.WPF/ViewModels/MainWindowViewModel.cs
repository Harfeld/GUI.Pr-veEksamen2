using AndreasHarfeldJakobsen201608930.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AndreasHarfeldJakobsen201608930.WPF.DAL;
using AndreasHarfeldJakobsen201608930.WPF.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace AndreasHarfeldJakobsen201608930.WPF.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        BereauRepository database = new BereauRepository();

        public MainWindowViewModel()
        {
            CurrentModel = null;
            CurrentAssignment = null;
        }

        #region Properties

        public ObservableCollection<Model> ListofModels
        {
            get
            {
                var listofModels = database.GetAllModels().Result;
                return listofModels;
            }
        }

        public ObservableCollection<Assignment> ListofUnplannedAssignments
        {
            get
            {
                var listofUnplannedAssignments = database.GetUnplannedAssignments().Result;
                return listofUnplannedAssignments;
            }
        }

        public ObservableCollection<Assignment> ListofPlannedAssignments
        {
            get
            {
                var listofPlannedAssignments = database.GetPlannedAssignments().Result;
                return listofPlannedAssignments;
            }
        }

        Model currentModel = null;

        public Model CurrentModel
        {
            get { return currentModel; }
            set { SetProperty(ref currentModel, value); }
        }

        Assignment currentAssignment = null;

        public Assignment CurrentAssignment
        {
            get { return currentAssignment; }
            set { SetProperty(ref currentAssignment, value); }
        }

        #endregion

        ICommand _AddModelCommand;

        public ICommand AddModelCommand
        {
            get
            {
                return _AddModelCommand ?? (_AddModelCommand = new DelegateCommand(() =>
                {
                    // Initialize the dialog
                    var vm = new AddModelViewModel();
                    AddModelWindow addModelDlg = new AddModelWindow
                    {
                        DataContext = vm,
                        Owner = Application.Current.MainWindow.Owner

                    };
                    if(addModelDlg.ShowDialog() == true) { }

                }));
            }
        }
    }
}
