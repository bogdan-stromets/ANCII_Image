using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ANCII_Image
{
    public class Converter
    {
        private readonly Bitmap b;
        private readonly char[] ancii_arr = { '.', ',', ':', '+', '*', '?','%','$','@'};

        public Converter(Bitmap b)
        {
            this.b = b;
        }

        public char[][] Convert()
        {
            char[][] res = new char[b.Height][];
            for (int y = 0; y < b.Height; y++)
            {
                res[y] = new char[b.Width];
                for (int x = 0; x < b.Width; x++)
                {
                    int ind = (int)Map(b.GetPixel(x,y).R,0,255,0,ancii_arr.Length - 1);
                    res[y][x] = ancii_arr[ind];
                }
            }
            
            return res;
        }

        float Map(float valueToMap, float start_1, float stop_1, float start_2, float stop_2)
        {
            return ((valueToMap - start_1) / (stop_1 - start_1) * (stop_2 - start_2) + start_2);
        }
        
    }
}
