//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovik
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exkursion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exkursion()
        {
            this.Operation = new HashSet<Operation>();
        }
    
        public int IdExkursion { get; set; }
        public string Name { get; set; }
        public string Opisanie { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> MaxMan { get; set; }
        public Nullable<int> Time { get; set; }
        public Nullable<double> skidka { get; set; }
        public byte[] Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operation { get; set; }
    }
}