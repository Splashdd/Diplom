//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Progect_accounting.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projects
    {
        public int ID { get; set; }
        public int Group_ID { get; set; }
        public string FullName { get; set; }
        public int ProjectType { get; set; }
        public string ProjectName { get; set; }
        public int Supervisor_ID { get; set; }
        public Nullable<System.DateTime> CompleteDate { get; set; }
        public int Mark { get; set; }
        public byte[] Files { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual Supervisors Supervisors { get; set; }
    }
}
