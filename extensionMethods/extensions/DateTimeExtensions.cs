using System.Globalization;

namespace System {
    static class DateTimeExtensions {
        public static string ElapsedTime(this DateTime thisObj) {
            TimeSpan duration = DateTime.Now.Subtract(thisObj);

            if (duration.TotalHours < 24) {
                return GetFormatedDouble(duration.TotalHours) + " Hours";
            } else {
                return GetFormatedDouble(duration.TotalDays) + " Days";
            }
        }

        private static string GetFormatedDouble(double value) {
            return value.ToString("F1", CultureInfo.InvariantCulture);
        }
    }
}