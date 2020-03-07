using System;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public int GetDifferenceInDays(string firstDate, string secondDate)
        {
            this.startDate = DateTime.Parse(firstDate);
            this.endDate = DateTime.Parse(secondDate);

            var result = (int)((this.startDate - this.endDate).TotalDays);
            return Math.Abs(result);
        }
    }
}
