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
    
    public partial class TableReservationTable
    {
        public int TableReservationID { get; set; }
        public int Reservation_UserID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public System.DateTime ReservationRequestDate { get; set; }
        public System.DateTime ReservationDateTime { get; set; }
        public int NoOfPersons { get; set; }
        public int ProcessBy_UserID { get; set; }
        public int ReservationStatusID { get; set; }
        public string Description { get; set; }
    
        public virtual ReservationStatusTable ReservationStatusTable { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual UserTable UserTable1 { get; set; }
    }
}
