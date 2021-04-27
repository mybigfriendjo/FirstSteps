using System.Windows;
using static AutoSF.AutoMission;
using System.Data;

namespace AutoSF {
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window, IAutomissionListener {
        public SecondWindow() {
            InitializeComponent();
        }

        public void Update(DataTable dtInput) { //For multiple Threads
            if(!Dispatcher.CheckAccess()) {
                Dispatcher.Invoke(new InvokeUpdate(Update), dtInput);
                return;
            }
            else {
                DataGridTableCacheDB.ItemsSource = dtInput.DefaultView;
            }
        }
        private delegate void InvokeUpdate(DataTable table);
    }
}
