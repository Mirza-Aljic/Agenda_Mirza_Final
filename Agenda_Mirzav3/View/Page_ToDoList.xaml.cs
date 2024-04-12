using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Agenda_Mirzav3.AgendaMirzaDB;
using Agenda_Mirzav3.Service.DAO;
using Agenda_Mirzav3.View;


namespace Agenda_Mirzav3.View
{
    /// <summary>
    /// Logique d'interaction pour Page_ToDoList.xaml
    /// </summary>
    public partial class Page_ToDoList : UserControl
    {

        DAO_ToDoList DAO_todolist;

        public IEnumerable<ToDoList> toDoLists { get; set; }

        public Page_ToDoList()
        {
            InitializeComponent();

   
            DAO_todolist = new DAO_ToDoList();
            DG_ToDoList.ItemsSource = DAO_todolist.GetToDoList();
        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();
            frame.Content = new Page_Add_List();
            GD_List.Children.Add(frame);
        }

        private void BTN_Modify_Click(object sender, RoutedEventArgs e)
        {
            ToDoList todolist = DG_ToDoList.SelectedItem as ToDoList;
            
            if (todolist != null)
            {
                DAO_todolist.UpdateToDoList(todolist);
          
                DG_ToDoList.ItemsSource = DAO_todolist.GetToDoList();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une To Do List");
            }
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            ToDoList todolist = DG_ToDoList.SelectedItem as ToDoList;
            DAO_todolist.DeleteToDoList(todolist);
            DG_ToDoList.ItemsSource = DAO_todolist.GetToDoList();
            MessageBox.Show("Votre To Do liste a été supprimé");
        }
    }
}
