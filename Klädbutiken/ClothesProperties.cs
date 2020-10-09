using System;
using System.Collections.Generic;
using System.Text;

namespace Klädbutiken
{
    class ClothesProperties
    {

        public enum Types
        {
            Tröja = 1,
            TShirt,
            Byxor,
            Skor
        }

        public enum ClothingSizes
        {
            XS = 1,
            S,
            M,
            L,
            XL,
            XXL
        }

        public enum Colors
        {
            Black = 1,
            White,
            Grey,
            Blue,
            Red,
            Green
        }

        public static int GetEnumColorLength()
        {
            int enumLength = Enum.GetNames(typeof(Colors)).Length;
            return enumLength;
        }

        public static int GetEnumTypesLength()
        {
            int enumLength = Enum.GetNames(typeof(Types)).Length;
            return enumLength;
        }

        public static int GetEnumClothingSizesLength()
        {
            int enumLength = Enum.GetNames(typeof(ClothingSizes)).Length;
            return enumLength;
        }



    }
}
