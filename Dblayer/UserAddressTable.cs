//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dblayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAddressTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAddressTable()
        {
            this.OrderTables = new HashSet<OrderTable>();
        }
    
        public int UserAddressID { get; set; }
        public int UserID { get; set; }
        public int AddressTypeID { get; set; }
        public string FullAddress { get; set; }
        public int VisibleStatusID { get; set; }
        public int CreatedBy_UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual VisibleStatusTable VisibleStatusTable { get; set; }
        public virtual AddressTypeTable AddressTypeTable { get; set; }
    }
}
