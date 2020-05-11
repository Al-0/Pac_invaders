using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UII_Ex
{
    class Shots
    {
        public PictureBox PB = new PictureBox();
        StringBuilder tmp = new StringBuilder("L_p"); // Auxiliar, contiene el nombre de las imágenes
        public int state = 1;

        public Shots(int x, int y, int whom, Game u)
        {
            PB.Location = new Point(x, y);
            if (whom == 1)
            {
                tmp[2] = 'g';
            }
            //Establecer parámetros de la Picture Box
            var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
            PB.Image = (Bitmap)value;
            PB.Size = new Size(3,15);
            PB.Visible = true;
            PB.Name = Convert.ToString(tmp);
            u.Controls.Add(PB);
        }
    }
}
