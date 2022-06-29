namespace Checkout.Payment.Api.Extensions
{
    public static class MaskingExtensions
    {
        public static string Mask(this string input)
        {
            if (input.Length > 4) {
                return input.Substring(input.Length - 4).PadLeft(input.Length, '*');
            };
            return input;
        }
    }
}

