using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ANCII_Image
{
    internal class Program
    {
        private const double WIDTH_OFFSET = 1.5;
        private const int MAX_WIDTH = 200;

        [STAThread]
        static void Main(string[] args)
        {
            var openFile = new OpenFileDialog()
            {
                Filter = "Images | *.bmp; *.jpg; *.png; *.JPEG"
            };

            while (true)
            {
                Console.ReadLine();
                if (openFile.ShowDialog() != DialogResult.OK)
                    continue;
                Console.Clear();
                
                Bitmap bitmap = new Bitmap(openFile.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayScale();
                Converter converter = new Converter(bitmap);
                var rows = converter.Convert();

                foreach (var item in rows)
                    Console.WriteLine(item);

                Console.SetCursorPosition(0, 0);
            }
        }

        static Bitmap ResizeBitmap(Bitmap b)
        { 
            var height = b.Height / WIDTH_OFFSET * MAX_WIDTH  / b.Width;
            if (b.Height > height || b.Width > MAX_WIDTH)
                b = new Bitmap(b, new Size(MAX_WIDTH,(int)height));    
            return b;
        }
    }
}
