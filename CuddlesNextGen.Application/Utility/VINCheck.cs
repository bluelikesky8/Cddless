using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.Utility
{
    public static class VINCheck
    {

        private static readonly Dictionary<char, int> ReplaceValues = new Dictionary<char, int>();
        private static readonly int[] Weights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };

        static VINCheck()
        {
            ReplaceValues.Add('A', 1);
            ReplaceValues.Add('B', 2);
            ReplaceValues.Add('C', 3);
            ReplaceValues.Add('D', 4);
            ReplaceValues.Add('E', 5);
            ReplaceValues.Add('F', 6);
            ReplaceValues.Add('G', 7);
            ReplaceValues.Add('H', 8);
            ReplaceValues.Add('J', 1);
            ReplaceValues.Add('K', 2);
            ReplaceValues.Add('L', 3);
            ReplaceValues.Add('M', 4);
            ReplaceValues.Add('N', 5);
            ReplaceValues.Add('P', 7);
            ReplaceValues.Add('R', 9);
            ReplaceValues.Add('S', 2);
            ReplaceValues.Add('T', 3);
            ReplaceValues.Add('U', 4);
            ReplaceValues.Add('V', 5);
            ReplaceValues.Add('W', 6);
            ReplaceValues.Add('X', 7);
            ReplaceValues.Add('Y', 8);
            ReplaceValues.Add('Z', 9);
            ReplaceValues.Add('1', 1);
            ReplaceValues.Add('2', 2);
            ReplaceValues.Add('3', 3);
            ReplaceValues.Add('4', 4);
            ReplaceValues.Add('5', 5);
            ReplaceValues.Add('6', 6);
            ReplaceValues.Add('7', 7);
            ReplaceValues.Add('8', 8);
            ReplaceValues.Add('9', 9);
            ReplaceValues.Add('0', 0);
        }

        public static bool IsVINValid(string vin)
        {
            bool isVINValid = false;
            int intValue = 0;

            if (vin == null)
            {
                return false;
            }
            else if (vin.Length != 17)
            {
                return isVINValid;
            }

            vin = vin.ToUpper().Trim();
            int intCheckValue = 0;
            char check = vin[8];
            char year = vin[9];

            if (!char.IsDigit(check) && check != 'X')
            {
                return isVINValid;
            }
            else
            {
                if (check != 'X')
                {
                    char[] d = new char[] { check };
                    var bytes = Encoding.UTF8.GetBytes(d);
                    intCheckValue = int.Parse(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                }
                else
                {
                    intCheckValue = 10;
                }
            }

            //Make sure it is a Valid Year 
            if (!ReplaceValues.ContainsKey(year) && year != '0')
            {
                return isVINValid;
            }

            //Make sure characters that are in the VIN are the ones allowed. 
            for (int i = 0; i < vin.Length; i++)
            {
                if (!ReplaceValues.ContainsKey(vin[i]))
                {
                    return false;
                }
                intValue += (Weights[i] * ((int)ReplaceValues[vin[i]]));
            }

            if ((intValue % 11) == intCheckValue)
            {
                isVINValid = true;
            }

            return isVINValid;
        }

    }
}