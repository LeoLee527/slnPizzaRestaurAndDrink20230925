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
    
    public partial class StockDealDetailTable
    {
        public int StockDealDetailID { get; set; }
        public int StockDealID { get; set; }
        public int StockItemID { get; set; }
        public double Discount { get; set; }
        public int VisibleStatusID { get; set; }
        public int CreatedBy_UserID { get; set; }
    
        public virtual StcokDealTable StcokDealTable { get; set; }
        public virtual StockItemTable StockItemTable { get; set; }
        public virtual VisibleStatusTable VisibleStatusTable { get; set; }
    }
}
