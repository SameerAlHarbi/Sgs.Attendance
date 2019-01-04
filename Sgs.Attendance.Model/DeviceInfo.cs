using Sameer.Shared;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public class DeviceInfo : ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} is required !")]
        [Unique(ErrorMessage ="{0} is already exist !")]
        [StringLength(8, MinimumLength = 8, ErrorMessage ="{0} length must be of {1} charachters !")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [Unique(ErrorMessage = "{0} is already exist !")]
        [MaxLength(20, ErrorMessage = "{0} length must be of {1} charachters !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        [Unique(ErrorMessage = "{0} is already exist !")]
        [MaxLength(20, ErrorMessage = "{0} length must be of {1} charachters !")]
        public string IpAddress { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        public string LocationArabic { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        public string LocationEnglish { get; set; }

        [Required(ErrorMessage = "{0} is required !")]
        public string Model { get; set; }

        [MaxLength(20, ErrorMessage = "{0} length can't be nore than {1} charachters !")]
        public string RefrenceNumber { get; set; }

        public string Note { get; set; }
        
    }
}
