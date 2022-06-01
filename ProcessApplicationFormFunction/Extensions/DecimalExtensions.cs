namespace ProcessApplicationFormFunction.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal? ConvertDeficitAmountToNegativeValue(this decimal? amount, bool? isDeficit)
        {
            if (isDeficit.HasValue)
            {
                return isDeficit.Value ? amount * -1.0M : amount;
            }
            return null;
        }
    }
}
