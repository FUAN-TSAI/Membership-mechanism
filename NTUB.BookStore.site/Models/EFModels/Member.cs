namespace NTUB.BookStore.site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        [Required]
        [StringLength(70)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }

        public bool IsConfirmed { get; set; }

        [StringLength(50)]
        public string ConfirmCode { get; set; }
    }
}
