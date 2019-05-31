using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AndreasHarfeldJakobsen201608930.WPF.DAL;
using AndreasHarfeldJakobsen201608930.WPF.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace AndreasHarfeldJakobsen201608930.WPF.ViewModels
{
    class AddModelViewModel : BindableBase
    {
        BereauRepository database = new BereauRepository();
        Model newModel = new Model();

        public AddModelViewModel()
        {
            
        }

        public Model NewModel
        {
            get { return newModel; }
            set { SetProperty(ref newModel, value); }
        }

        ICommand _AcceptCommand;
        public ICommand AcceptCommand
        {
            get
            {
                return _AcceptCommand ?? (_AcceptCommand = new DelegateCommand(() =>
                {
                    database.AddModel(NewModel);
                }));

            }
        }
    }
}
