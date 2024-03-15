using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.Agenda_MirzaDB;

public partial class Task
{
    public int IdTask { get; set; }

    public string Name { get; set; } = null!;

    public sbyte Check { get; set; }

    public int ToDoListIdToDoList { get; set; }
}
