//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string DevCompany { get; set; }
        public System.DateTime RelizeDate { get; set; }
        public int GenreID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> BasketID { get; set; }
    
        public virtual Basket Basket { get; set; }
        public virtual Genres Genres { get; set; }
    }
}
