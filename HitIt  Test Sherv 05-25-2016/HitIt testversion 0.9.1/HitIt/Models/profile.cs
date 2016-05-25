//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HitIt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    public partial class profile
    {
        public profile()
        {
            this.collaborations = new HashSet<collaborations>();
            this.talent = new HashSet<talent>();
        }
    
        public int id { get; set; }
        public string profileName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string languages { get; set; }
        public string rating { get; set; }
        public string about { get; set; }
        public byte[] picture { get; set; }
        public string picturePath { get; set; }
        public byte[] teaser { get; set; }
        public string UserName { get; set; }

    
        public virtual ICollection<collaborations> collaborations { get; set; }
        public virtual ICollection<talent> talent { get; set; }
    }
}
