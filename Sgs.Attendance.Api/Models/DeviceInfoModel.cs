namespace Sgs.Attendance.Api.Models
{
    public class DeviceInfoModel : ISameerApiViewModel
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; }

        public string LocationArabic { get; set; }

        public string LocationEnglish { get; set; }

        public string Model { get; set; }

        public string RefrenceNumber { get; set; }

        public bool Connected { get; set; }

        public string Note { get; set; }
    }
}
