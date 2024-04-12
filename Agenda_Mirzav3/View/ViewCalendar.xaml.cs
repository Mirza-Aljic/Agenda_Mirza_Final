using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Agenda_Mirzav3.Service.DAO;
using Google.Apis.Calendar.v3.Data;


namespace Agenda_Mirzav3.View
{
    public partial class ViewCalendar : UserControl
    {
        public ObservableCollection<Event> Events { get; set; }

     
        DAO_Google_Calendar DAO_Google_Calendar;

        public ViewCalendar()
        {

            InitializeComponent();


            Events = new ObservableCollection<Event>();
            DataContext = this;


 
            DAO_Google_Calendar = new DAO_Google_Calendar();

            LoadEvents();
        }

        private void LoadEvents()
        {
            DAO_Google_Calendar daoGoogleCalendar = new DAO_Google_Calendar(); // Création de l'instance de DAO_Google_Calendar
            var events = daoGoogleCalendar.GetEvents(); // Appel à la méthode GetEvents()
            foreach (var evt in events)
            {
                Events.Add(evt);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
           // Rafraîchir les événements
            Events.Clear();
            LoadEvents();
        }
    }
}
