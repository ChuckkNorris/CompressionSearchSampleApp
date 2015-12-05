using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionSearchSampleApp.ViewModels {
    public class State : INotifyPropertyChanged {

        private string _State;
        public string Name {
            get { return _State; }
            set {
                _State = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        private double _FontSize = 15;
        public double FontSize {
            get { return _FontSize; }
            set {
                _FontSize = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FontSize"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class SearchViewModel { 
        public ObservableCollection<State> States { get; set; }
        public string SearchTerm { get; set; }

        private List<string> AllStates = new List<string>() { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };

        public SearchViewModel() {
            States = new ObservableCollection<State>();
            AllStates.ForEach(state => States.Add(new State() { Name = state }));
        }

        public void OnSearchTermChanged(string value) {
          //  States.Clear();
            var searchTerm = value.ToLower();
           // var statesContainingSearchTerm = States.Where(state => state.Name.ToLower().Contains(searchTerm));
            foreach (var state in States) {
                if (state.Name.ToLower().Contains(searchTerm)) {
                    state.FontSize += 10;
                }
                else
                    state.FontSize = 15;
               // States.Add(new State() { Name=state, FontSize=20 });
            }
        }
    }
}
