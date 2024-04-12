using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agenda_Mirzav3.AgendaMirzaDB;

namespace Agenda_Mirzav3.Service.DAO
{
    public class DAO_Task
    {

        //Modifier une tache
        public void UpdateTask(Task task)
        {
            using (var context = new AgendaMirzaContext())
            {
                context.Tasks.Update(task);
                context.SaveChanges();
            }
        }

        //Ajouter une tache
        public void AddTask(Task task)
        {
            using (var context = new AgendaMirzaContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }

        //Chercher tous les taches
        public IEnumerable<Task> GetTasks()
        {
            try
            {
                using (var context = new AgendaMirzaContext())
                {
                    return context.Tasks.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Supprimer une tache
        public void DeleteTask(Task task)
        {
            using (var context = new AgendaMirzaContext())
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }
     
    }
}