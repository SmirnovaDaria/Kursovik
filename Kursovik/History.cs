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
    
    public partial class History
    {
        public int idHistory { get; set; }
        public Nullable<int> idOperation { get; set; }
        public Nullable<bool> isFinish { get; set; }
    
        public virtual Operation Operation { get; set; }
    }
}
