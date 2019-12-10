using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public class MyCultureComparer : IEqualityComparer
    {
        public CaseInsensitiveComparer MyComparer;

        public MyCultureComparer()
        {
            MyComparer = CaseInsensitiveComparer.DefaultInvariant;
        }

        public MyCultureComparer(CultureInfo myCulture)
        {
            MyComparer = new CaseInsensitiveComparer(myCulture);
        }

        public bool Equals(object x, object y)
        {
            return MyComparer.Compare(x, y) == 1;
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
