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
using Agenda_Mirzav3.AgendaMirzaDB;
using Agenda_Mirzav3.Service.DAO;
using Agenda_Mirzav3.View;

namespace Agenda_Mirzav3.View
{
    /// <summary>
    /// Logique d'interaction pour PageContact.xaml
    /// </summary>
    public partial class PageContact : UserControl

    {
        DAO_Contact Contact_DB;
        public PageContact()
        {
            InitializeComponent();
            Contact_DB = new DAO_Contact();
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts();
        }

        private void BTN_AddContact_Click(object sender, RoutedEventArgs e)
        {

            GD_AddContact.Children.Clear();
            View.Add_Contact contact = new View.Add_Contact();
            GD_AddContact.Children.Add(contact);
        }

        private void BTN_Modify_Click(object sender, RoutedEventArgs e)
        {
            if (DG_Contact.SelectedItem == null)
            {
                MessageBox.Show("Selectionnez un contact pour le modifier");
                return;
            }

            Contact contact = DG_Contact.SelectedItem as Contact;
            Contact_DB.UpdateContact(contact);
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts();
            MessageBox.Show("Contact modifier");
            return;
        }

        private void BTN_Delate_Click(object sender, RoutedEventArgs e)
        {

            if (DG_Contact.SelectedItem == null)
            {
                MessageBox.Show("Selectionnez un contact pour le supprimer");
                return;
            }

            Contact contact = DG_Contact.SelectedItem as Contact;
            Contact_DB.DelateContact(contact.Idcontact);
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts();

        }

        private void BTN_Amis_Click(object sender, RoutedEventArgs e)
        {
            // Afficher uniquement les contacts de Status "Amis"
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts().Where(contact => contact.Status == "Amis").ToList();
        }

        private void BTN_Famille_Click(object sender, RoutedEventArgs e)
        {
            // Afficher uniquement les contacts de Status "Famille"
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts().Where(contact => contact.Status == "Famille").ToList();
        }

        private void BTN_Collegue_Click(object sender, RoutedEventArgs e)
        {
            // Afficher uniquement les contacts de Status "Collègue"
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts().Where(contact => contact.Status == "Collègue").ToList();
        }

    }


}
