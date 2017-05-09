using System.Text;

namespace Lab05P1
{
    public class PhoneTranslator
    {
        string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Numbers = "22233344455566677778889999";

        public PhoneTranslator()
        {
        }

        public string ToNumber(string alphanumericPhoneNumber)
        {
            StringBuilder NumericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alphanumericPhoneNumber))
            {
                alphanumericPhoneNumber = alphanumericPhoneNumber.ToUpper();
                foreach (var c in alphanumericPhoneNumber)
                {
                    if ("0123456789".Contains(c.ToString()))
                        NumericPhoneNumber.Append(c);
                    else
                    {
                        int index = Letters.IndexOf(c);
                        if (index >= 0)
                            NumericPhoneNumber.Append(Numbers[index]);
                    }
                }
            }
            return NumericPhoneNumber.ToString();
        }
    }
}