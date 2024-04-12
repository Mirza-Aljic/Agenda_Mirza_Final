using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda_Mirzav3.AgendaMirzaDB;

namespace Agenda_Mirzav3.Service.DAO
{
    public class DAO_ToDoList : DAO_Task
    {
        // Supprimer une liste
        public void DeleteToDoList(ToDoList todolist)
        {
            using (var context = new AgendaMirzaContext())
            { 
                context.ToDoLists.Remove(todolist);
                context.SaveChanges();
            }
        }

        // Ajouter une liste
        public void AddToDoList(ToDoList todolist)
        {
            using (var context = new AgendaMirzaContext()) 
            {
                context.ToDoLists.Add(todolist);
                context.SaveChanges();
            }
        }

        // Chercher toutes les listes
        public IEnumerable<ToDoList> GetToDoList()
        {
            using (var context = new AgendaMirzaContext()) 
            {
                return context.ToDoLists.ToList();
            }
        }

        // Modifier une liste
        public void UpdateToDoList(ToDoList todolist)
        {
            using (var context = new AgendaMirzaContext()) 
            {
                context.ToDoLists.Update(todolist);
                context.SaveChanges();
            }
        }
    }
}
