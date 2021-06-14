using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTRD
{
    public partial class RefstoreCsopistatus
    {
        public int RefcsopistatusId { get; set; }
        public string Refcsopikey { get; set; }
        public string Refcsopitoken { get; set; }
        public int? RefcsopistoreType { get; set; }
        public string RefcsopistatusExternalName { get; set; }
    }
}
