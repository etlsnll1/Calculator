using Calculator.InterfaceSpecifications;
using System;
using System.Collections.Generic;

namespace Steves.CalculatorService
{
    public class CalculatorService : IArrayService
    {
        public T[] DeletePart<T>(T[] vals, int position)
        {
            if (vals == null)
                throw new ArgumentNullException("vals");

            if (position < 1 || position > vals.Length)
                throw new ArgumentException("position", "Outside of range of array supplied in vals parameter");

            var output = new List<T>();
            for (var i = 0; i < vals.Length; i++)
            {
                if (i != position - 1)
                    output.Add(vals[i]);
            }

            return output.ToArray();
        }

        public T[] Reverse<T>(T[] vals)
        {
            if (vals == null)
                throw new ArgumentNullException("vals");

            var output = new List<T>();
            for (var i = vals.Length - 1; i >= 0; i--)
                output.Add(vals[i]);

            return output.ToArray();
        }
    }
}
