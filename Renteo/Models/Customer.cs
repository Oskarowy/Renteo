using Renteo.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Renteo.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Imię i nazwisko")]
        public string Name { get; set; }

        [Display(Name = "Zasubskrybować?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Typ członkostwa")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Data urodzenia")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}