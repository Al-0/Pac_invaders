using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UII_Ex
{
    class Ghost
    {
        public static int total = 0;    //Fantasmas totales
        public PictureBox PB = new PictureBox();
        char[] Life = {'B', 'P', 'O', 'R'};     //Dependiendo de la vida acutal es el color del fantasma
        public int current_life;
        StringBuilder tmp = new StringBuilder("O_r"); // Auxiliar, contiene el nombre de las imágenes

        public Ghost(int x, int y, int difficulty, Game u)
        {
            PB.Location = new Point(x, y);
            switch(difficulty)
            {
                case 0:
                    current_life = 0;
                    break;
                case 1:
                    current_life = 1;
                    break;
                case 2:
                    current_life = 3;
                    break;
                default:
                    break;
            }
            tmp[0] = Life[current_life];
            //Establecer parámetros de la Picture Box
            var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
            PB.Image = (Bitmap)value;
            PB.Size = new Size(30,30);
            PB.Visible = true;
            PB.Name = Convert.ToString(tmp);
            u.Controls.Add(PB);
            total++;
        }

        public void shot()
        {
            current_life--;
            if (current_life == -1)
            {
                PB.Image = Properties.Resources.S;
            }
            else
            {
                tmp = new StringBuilder(PB.Name);
                tmp[0] = Life[current_life];
                //Establecer parámetros de la Picture Box
                var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                PB.Image = (Bitmap)value;
                PB.Name = Convert.ToString(tmp);
            }
        }
    }
}
