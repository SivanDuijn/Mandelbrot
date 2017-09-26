using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eyes_volgen_muis
{
    public partial class Form1 : Form
    {
        int mouseX;
        int mouseY;

        public Form1()
        {
            this.Text = spijker(78124);
            this.Size = new Size(500, 450);
            this.BackColor = Color.LightGray;
            this.Paint += Tekenscherm;
            this.MouseMove += Muisbewoog;
            this.DoubleBuffered = true;

            

        }

        static string streepjes(int a)
        {
            string resultaat = "";
            while (a > 0)
            {
                resultaat += "| ";
                a--;
            }
            return resultaat;
        }


        static string spijker(int x)
        {
            string resultaat = "";
            while (x > 0)
            {
                int a = x % 10;
                resultaat = streepjes(a) + "- " + resultaat;
                x = (x - a) / 10;
            }
            
            return "- " + resultaat;
        }

        void Muisbewoog(object obj, MouseEventArgs args)
        {
            
            mouseX = args.X;
            mouseY = args.Y;

            Invalidate();
        }

        void TekenOog(Graphics gr, int posX, int posY )
        {
            gr.DrawEllipse(Pens.Black, posX, posY, 70, 70);
            int middenellipseX = posX + 35;
            int middenellipseY = posY + 35;

            double dx = mouseX - middenellipseX;
            double dy = mouseY - middenellipseY;
            double d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            double ey = (25 / d) * dy;
            double ex = (25 / d) * dx;
            float oogX = (float)(posX + 35 + ex - 10);       // posX + 35 is de cirkel van het midden van het oog waar het oog kan zijn, dit moet - 10 om het oog netjes te krijgen
            float oogY = (float)(posY + 35 + ey - 10);

            if (25 > d)
            {
                oogX = mouseX - 10;
                oogY = mouseY - 10;
            }

            int red = (mouseX + 1) / 2;
            int green = (mouseY + 1) /2;

            Brush kwast = new SolidBrush(Color.FromArgb(red, green,  50));

            gr.FillEllipse(kwast, oogX, oogY, 20, 20);
        }

        void Tekenscherm(object obj, PaintEventArgs pea)
        {
            TekenOog(pea.Graphics, 40, 40);
            TekenOog(pea.Graphics, 130, 40);
            TekenOog(pea.Graphics, 200, 200);
            TekenOog(pea.Graphics, 290, 200);
            TekenOog(pea.Graphics, 10, 300);
            TekenOog(pea.Graphics, 100, 300);


        }


    }
}
