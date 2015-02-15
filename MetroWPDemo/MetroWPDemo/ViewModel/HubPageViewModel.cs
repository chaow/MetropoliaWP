using MetroWPDemo.Models;
using System.Collections.ObjectModel;

namespace MetroWPDemo.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class HubPageViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<Person> _personHub1ViewModel = null;
        /// <summary>
        /// collection person
        /// </summary>
        public ObservableCollection<Person> PersonHub1ViewModel
        {
            get
            {
                if (_personHub1ViewModel == null)
                {
                    _personHub1ViewModel = new ObservableCollection<Person>();
                    LoadPersonHub1List();
                }
                return _personHub1ViewModel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<Person> _personHub2ViewModel = null;
        /// <summary>
        /// collection person
        /// </summary>
        public ObservableCollection<Person> PersonHub2ViewModel
        {
            get
            {
                if (_personHub2ViewModel == null)
                {
                    _personHub2ViewModel = new ObservableCollection<Person>();
                    LoadPersonHub2List();
                }
                return _personHub2ViewModel;
            }
        }

        public HubPageViewModel()
        {
        }

        /// <summary>
        /// load person list for hub 1
        /// </summary>
        private void LoadPersonHub1List()
        {
            if (_personHub1ViewModel.Count > 0)
            {
                _personHub1ViewModel.Clear();
            }
            for (int i = 0; i < 15; i++)
            {
                Person p = new Person();
                p.Name = "Person " + i;
                p.Nickname = "Person nickname " + i;
                p.Age = i;
                _personHub1ViewModel.Add(p);
            }
        }

        /// <summary>
        /// load person list for hub 2
        /// </summary>
        private void LoadPersonHub2List()
        {
            if (_personHub2ViewModel.Count > 0)
            {
                _personHub2ViewModel.Clear();
            }
            for (int i = 0; i < 15; i++)
            {
                Person p = new Person();
                p.Name = "Person " + (i + 100);
                p.Nickname = "Person nickname " + (i + 100);
                p.Age = (i + 100);
                _personHub2ViewModel.Add(p);
            }
        }

        /// <summary>
        /// Remove a persion from hub 1 list
        /// </summary>
        /// <param name="p"></param>
        public void RemovePersonFromPersonHub1List(Person p)
        {
            if((_personHub1ViewModel != null) && (p != null))
            {
                _personHub1ViewModel.Remove(p);
            }
        }
    }
}
