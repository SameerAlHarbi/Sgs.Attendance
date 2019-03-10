using Sameer.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Attendance.Model
{
    public abstract class WorkShiftCycle : ISameerObject,IValidatableObject
    {
        public int Id { get; set; }

        public int CycleOrder { get; set; }

        public int RepeatCount { get; set; }

        [Range(0, 23.99 , ErrorMessage = "{0} must be between {2} And {1}")]
        public double? ShiftStart { get; set; }

        [Range(0, 23.99, ErrorMessage = "{0} must be between {2} And {1}")]
        public double? ShiftEnd { get; set; }

        public bool IsDayOff { get; set; }

        public string DayOffDescription { get; set; }

        public double? ShiftDuration
        {
            get
            {
                if (!ShiftStart.HasValue || !ShiftEnd.HasValue)
                {
                    return null;
                }

                if (ShiftStart.Value < ShiftEnd.Value)
                {
                    return ShiftEnd.Value - ShiftStart.Value;
                }
                else if (ShiftStart.Value > ShiftEnd.Value)
                {
                    return ShiftEnd + (24d - ShiftStart);
                }
                else
                {
                    return 24;
                }
            }
        }

        public double? ShiftDurationInRamadan
        {
            get
            {
                double? start = this.ShiftStartInRamadan ?? this.ShiftStart;

                double? end = this.ShiftEndInRamadan ?? this.ShiftEnd;

                if (!start.HasValue || !end.HasValue)
                {
                    return null;
                }

                if (start.Value < end.Value)
                {
                    return end.Value - start.Value;
                }
                else if (start.Value > end.Value)
                {
                    return end + (24d - start);
                }
                else
                {
                    return 24;
                }
            }
        }

        [Range(0, 23.99, ErrorMessage = "{0} must be between {2} And {1}")]
        public double? ShiftStartInRamadan { get; set; }

        [Range(0, 23.99, ErrorMessage = "{0} must be between {2} And {1}")]
        public double? ShiftEndInRamadan { get; set; }

        public bool? IsDayOffInRamadan { get; set; }

        public string DayOffDescriptionInRamadan { get; set; }

        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();


            if (!this.IsDayOff)
            {
                if (!this.ShiftStart.HasValue)
                {
                    results.Add(new ValidationResult($"{nameof(ShiftStart)} is required !", new string[] { "ShiftStart", "IsDayOff" }));
                }

                if (!this.ShiftEnd.HasValue)
                {
                    results.Add(new ValidationResult($"{nameof(ShiftEnd)} is required !", new string[] { "ShiftEnd", "IsDayOff" }));
                }

                if (this.ShiftDuration.HasValue && (this.ShiftDuration < 0.5d || ShiftDuration > 12d))
                {
                    results.Add(new ValidationResult($"{nameof(ShiftDuration)} must be between 30 minutes And 12 hours !", new string[] { "ShiftDuration" }));
                }

            }
            else if (string.IsNullOrWhiteSpace(DayOffDescription))
            {
                results.Add(new ValidationResult($"{nameof(DayOffDescription)} is required for day off sifts !", new string[] { "DayOffDescription", "IsDayOff" }));
            }

            if (IsDayOffInRamadan.HasValue && IsDayOffInRamadan.Value && string.IsNullOrWhiteSpace(DayOffDescriptionInRamadan) && string.IsNullOrWhiteSpace(DayOffDescription))
            {
                results.Add(new ValidationResult($"{nameof(DayOffDescriptionInRamadan)} or {nameof(DayOffDescription)} is required for day off sifts !", new string[] { "DayOffDescriptionInRamadan", "IsDayOffInRamadan", "DayOffDescription", "IsDayOff" }));
            }

            if(IsDayOffInRamadan.HasValue && !IsDayOffInRamadan.Value)
            {
                if (!this.ShiftStart.HasValue && !this.ShiftStartInRamadan.HasValue)
                {
                    results.Add(new ValidationResult($"{nameof(ShiftStart)} or {nameof(ShiftStartInRamadan)} is required for day off in ramadan !", new string[] { "ShiftStart", "IsDayOff" }));
                }

                if (!this.ShiftEnd.HasValue)
                {
                    results.Add(new ValidationResult($"{nameof(ShiftEnd)} or {nameof(ShiftEndInRamadan)} is required for day off in ramadan !", new string[] { "ShiftEnd", "IsDayOff" }));
                }

                if (this.ShiftDurationInRamadan.HasValue && (this.ShiftDurationInRamadan < 0.5d || ShiftDurationInRamadan > 12d))
                {
                    results.Add(new ValidationResult($"{nameof(ShiftDurationInRamadan)} must be between 30 minutes And 12 hours !", new string[] { "ShiftDuration" }));
                }
            }

            return results;
        }
    }
}
