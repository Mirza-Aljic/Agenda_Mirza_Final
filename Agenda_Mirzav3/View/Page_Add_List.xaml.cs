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
    /// Logique d'interaction pour Page_Add_List.xaml
    /// </summary>
    public partial class Page_Add_List : Page
    {
       
        DAO_ToDoList DAO_todolist;
        public Page_Add_List()
        {
            InitializeComponent();

           
            DAO_todolist = new DAO_ToDoList();

        }

        private void BTN_AddList_Click(object sender, RoutedEventArgs e)
        {
            ToDoList todolist = new ToDoList();

            todolist.Titre = TB_Titre.Text;
            todolist.Date = DateOnly.FromDateTime(DP_Date.SelectedDate.Value);
            todolist.DateEnd = DateOnly.FromDateTime(DP_Date_End.SelectedDate.Value);
            todolist.Description = TB_Description.Text;
            todolist.ContactIdcontact = int.Parse(TB_ChoixContact.Text);
            MessageBox.Show("To Do List ajouter");
            DAO_todolist.AddToDoList(todolist);
           
        }
    }
}
