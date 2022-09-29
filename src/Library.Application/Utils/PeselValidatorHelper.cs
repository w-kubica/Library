namespace Library.Application.Utils
{
    public static class PeselValidatorHelper
    {
        public static bool IsValidPesel(this string input)
        {
            var result = false;
            if (IsDigit(input))
            {
                if (input.Length != 11) return result;

                int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

                var controlSum = CalculateControlSum(input, weights);
                var controlNum = controlSum % 10;
                controlNum = 10 - controlNum;

                if (controlNum == 10)
                {
                    controlNum = 0;
                }

                var lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private static bool IsDigit(this string input)
        {
            var result = true;
            foreach (var ch in input)
            {
                if (!char.IsDigit(ch))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            var controlSum = 0;
            for (var i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
    }
}
