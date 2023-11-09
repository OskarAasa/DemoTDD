using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTDD
{
    public class VerifyPersonNr
    {
        public bool ValidPersonNr(string personNr)
        {
            if (personNr.Length > 13 || personNr.Length < 10) return false;
            if (string.IsNullOrEmpty(personNr)) return false;
            personNr = personNr.Replace(" ", "");
            if (personNr.Contains('-'))
            {
                if (personNr.Length > 11)
                {
                    personNr = personNr.Remove(8, 1);
                }
                else
                {
                    personNr = personNr.Remove(6, 1);
                }

            }
            if (personNr.Length > 10)
            {
                personNr = personNr.Remove(0, 2);
            }
            var pn = personNr.ToString();
            var pnNumber = pn.ToArray();
            int[] test = new int[pnNumber.Length];
            int sum = 0;
            int finalSum = 0;
            bool doubleUp = true;
            for (int i = 0; i < pnNumber.Length; i++)
            {
                var actualNumber = Convert.ToInt32(pnNumber[i]);
                test[i] = actualNumber - 48;
            }

            foreach (int i in test)
            {
                sum = 0;
                if (doubleUp)
                {
                    sum = i * 2;
                    doubleUp = false;
                }
                else
                {
                    sum = i * 1;
                    doubleUp = true;
                }
                if (sum > 9)
                {
                    var temp = sum.ToString();
                    var first = temp[0];
                    var second = temp[1];
                    finalSum += Convert.ToInt32(first) - 48;
                    finalSum += Convert.ToInt32(second) - 48;
                }
                else
                {
                    finalSum += sum;
                }

            }
            if (finalSum % 10 == 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
