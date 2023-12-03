using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentMaker.Models
{
    public class AppointmentModel
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        [DisplayName("Patient's Full Name")]
        public string? PatientName { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        [DisplayName("Street Address")]
        public string? PatientStreetAddress { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        [DisplayName("City")]
        public string? PatientCity { get; set; }

        [Required]
        [Range(10000, 99999)]
        [DisplayName("Zip/Postal Code")]
        public int PatientZipCode { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string? PatientEmail { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 10)]
        [DisplayName("Phone Number (10 digits)")]
        public string? PatientPhone { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Appontment Request Date")]
        public DateTime DateTime { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Patient's Approximate Net Worth")]
        public decimal PatientNetWorth { get; set; }
        
        [DisplayName("Primary Doctor's Last Name")]
        public string? DoctorName { get; set; }
        
        [Required]
        [Range(1, 10)]
        [DisplayName("Percieved Pain Level [ 1 (low) - 10 (high) ]")]
        public int Painlevel { get; set; }

        public AppointmentModel(string? patientName, string? patientStreetAddress, string? patientCity, int patientZipCode, string? patientEmail, string patientPhone, DateTime dateTime, decimal patientNetWorth, string? doctorName, int painlevel)
        {
            PatientName = patientName;
            PatientStreetAddress = patientStreetAddress;
            PatientCity = patientCity;
            PatientZipCode = patientZipCode;
            PatientEmail = patientEmail;
            PatientPhone = patientPhone;
            DateTime = dateTime;
            PatientNetWorth = patientNetWorth;
            DoctorName = doctorName;
            Painlevel = painlevel;
        }

        public AppointmentModel()
        {

        }
    }
}
