using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace UII_Ex
{
    public partial class Game : Form
    {
        Controller input = new Controller(); // Control

        //Sonidos
        SoundPlayer Waka = new SoundPlayer(Properties.Resources.pacman_chomp);
        SoundPlayer Death = new SoundPlayer(Properties.Resources.pacman_death);
        SoundPlayer Laser = new SoundPlayer(Properties.Resources.Enemy_laser);
        SoundPlayer Win = new SoundPlayer(Properties.Resources.Victory_theme);
        SoundPlayer Defeat = new SoundPlayer(Properties.Resources.Game_over_theme);
        
        //Lista de clase con cada fantasma
        List<Ghost> Enemies = new List<Ghost>(1);

        //Lista de clase de disparos de pacman
        List<Shots> Lasers_pacman = new List<Shots>(1);

        //Lista de clase de disparos de los fantasmas
        List<Shots> Lasers_ghosts = new List<Shots>(1);

        StringBuilder tmp;  // Auxiliar, contiene el nombre de las imágenes

        long aux = 0;       //Control de acciones
        int level = 0;      //Línea mas baja
        int shifts = 0;     //Cuantos movimientos en horizontal se han realizado
        int disp;           //Guía para animación de disparo
        int shot_delay = 0; //Delay para evitar ametralladora
        char death_state = 'a';  //Auxiliar para la animación de muerte
        int b = 0;       //Oportunidad base de disparar por parte de los fantasmas
        int n_ghosts;   //Cantidad original de fantasmas, utilizada para incrementar las propabilidades de disparo
        Random ind = new Random();  //RNG para los disparos de los fantasmas
        int chance = 0; //Indica el número al cual debe ser menor o igual el RNG para generar un disparo
        int win_state = 0;  //Control de la animación de victoria
        bool flag;          //Indica si hubo un disparo enemigo

        public Game()
        {
            InitializeComponent();
        }

        private void T_G_Tick(object sender, EventArgs e)
        {
            if (Ghost.total == 0)
            {
                T_G.Enabled = false;
                T_W.Enabled = true;
            }
            if (disp != 0)  //Animación de disparo y creación del disparo
            {
                tmp = new StringBuilder("PB_u");
                if (disp == 1 || disp == 5)
                {
                    tmp[1] = 'C';
                }
                else if (disp == 6)
                {
                    tmp[1] = 'O';
                }
                else if (disp == 2)
                {
                    tmp[1] = 'B';
                    Waka.Play();
                    Lasers_pacman.Add(new Shots(PBP.Left + 14, PBP.Top - 15, 0, this));
                }
                var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                PBP.Image = (Bitmap)value;
                disp = (disp + 1) % 7;
            }

            if (aux % 6 == 0)   //Acciones de pacman
            {
                input.Pull();
                switch (input.key)
                {
                    case "PointOfViewControllers0": 
                        //Movimiento
                        if (input.value == 27000)
                        {
                            PBP.Left = Math.Max(PBP.Left - 18, 12);
                        }
                        else if (input.value == 9000)
                        {
                            PBP.Left = Math.Min(PBP.Left + 18, 442);
                        }
                        break;
                    case "Buttons2":
                        //Disparo
                        if (input.value == 128)
                        {
                            shot_delay = (shot_delay + 1) % 1;
                            if (shot_delay == 0)
                            {
                                disp = 1;
                            }
                        }
                        break;
                    case "Buttons9":
                        System.Windows.Forms.Application.Exit();  
                        break;
                    default:
                        break;
                }
            }
            //Movimiento y disparo enemigo
            if ((aux % 20 == 0 && Form1.current_difficulty == 0) || (aux % 30 == 0 && Form1.current_difficulty == 1) || (aux % 45 == 0 && Form1.current_difficulty == 2))
            {
                //Movimiento
                move();
                //Disparos
                flag = false;
                chance = b + (((n_ghosts - Ghost.total) * 20) / n_ghosts);
                foreach (Ghost x in Enemies)
                {
                    int y = ind.Next(0, 100);
                    if (y <= chance)
                    {
                        flag = true;
                        Lasers_ghosts.Add(new Shots(x.PB.Left + 14, x.PB.Top + 30, 1, this));
                    }
                }
                if (flag == true)
                {
                    Laser.Play();
                }
            }

            //Movimiento de los misiles, 5px cada ciclo
            foreach (Shots x in Lasers_pacman)
            {
                x.PB.Top -= 5;
                if (x.PB.Top <= 12)
                {
                    x.state = 0;
                    x.PB.Visible = false;
                }
                else
                {
                    foreach (Ghost y in Enemies)
                    {
                        if (y.PB.Bounds.IntersectsWith(x.PB.Bounds) && y.current_life > -1)
                        {
                            x.state = 0;
                            x.PB.Visible = false;
                            y.shot();
                        }
                    }
                }
            }
            Lasers_pacman.RemoveAll(x => x.state == 0);
            //Misiles de los fantasmas, ligeramente más lentos
            if (aux % 4 == 0)
            {
                foreach (Shots x in Lasers_ghosts)
                {
                    x.PB.Top += 5;
                    x.PB.BringToFront();
                    if (x.PB.Top > 332)
                    {
                        x.state = 0;
                        x.PB.Visible = false;
                    }
                    else
                    {
                        if (PBP.Bounds.IntersectsWith(x.PB.Bounds))
                        {
                            x.state = 0;
                            x.PB.Visible = false;
                            T_G.Enabled = false;
                            T_D.Enabled = true;
                        }
                    }
                }
                Lasers_ghosts.RemoveAll(x => x.state == 0);
            }

            aux++;
        }

        private void move()
        {
            if (level % 2 == 0)     // Movimiento a la derecha
            {
                if (shifts == 14)   //Bajar
                {
                    foreach (Ghost x in Enemies)
                    {
                        if (x.current_life == -1)
                        {
                            x.PB.Visible = false;
                            Ghost.total--;
                        }
                        else
                        {
                            x.PB.Top += 33;
                            tmp = new StringBuilder(x.PB.Name);
                            tmp[2] = 'd';
                            var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                            x.PB.Image = (Bitmap)value;
                            if (x.PB.Top == 276)    //Game Over
                            {
                                T_G.Enabled = false;
                                T_D.Enabled = true;
                            }
                        }
                    }
                    shifts = 0;
                    level++;
                }
                else    //Movimiento lateral
                {
                    foreach (Ghost x in Enemies)
                    {
                        if (x.current_life == -1)
                        {
                            x.PB.Visible = false;
                            Ghost.total--;
                        }
                        else
                        {
                            x.PB.Left += 5;
                            tmp = new StringBuilder(x.PB.Name);
                            tmp[2] = 'r';
                            var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                            x.PB.Image = (Bitmap)value;
                        }
                    }
                    shifts++;
                }
            }
            else    //Movimiento a la izquierda
            {
                if (shifts == 14)
                {
                    foreach (Ghost x in Enemies)
                    {
                        if (x.current_life == -1)
                        {
                            x.PB.Visible = false;
                            Ghost.total--;
                        }
                        else
                        {
                            x.PB.Top += 33;
                            tmp = new StringBuilder(x.PB.Name);
                            tmp[2] = 'd';
                            var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                            x.PB.Image = (Bitmap)value;
                            if (x.PB.Top == 276)
                            {
                                T_G.Enabled = false;
                                T_D.Enabled = true;
                            }
                        }
                    }
                    shifts = 0;
                    level++;
                }
                else
                {
                    foreach (Ghost x in Enemies)
                    {
                        if (x.current_life == -1)
                        {
                            x.PB.Visible = false;
                            Ghost.total--;
                        }
                        else
                        {
                            x.PB.Left -= 5;
                            tmp = new StringBuilder(x.PB.Name);
                            tmp[2] = 'l';
                            var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                            x.PB.Image = (Bitmap)value;
                        }
                    }
                    shifts++;
                }
            }
            Enemies.RemoveAll(x => x.current_life == -1);
        }

        private void Game_Shown(object sender, EventArgs e)
        {
            int start = 0;
            int end = 0;
            switch (Form1.current_difficulty)
            {
                case 0:
                    start = 12;
                    end = 45;
                    level = 2;
                    shifts = 6;
                    b = 0;
                    n_ghosts = 13;
                    break;
                case 1:
                    start = 12;
                    end = 111;
                    level = 4;
                    shifts = 6;
                    b = 0;
                    n_ghosts = 26;
                    break;
                case 2:
                    start = 45;
                    end = 144;
                    level = 5;
                    shifts = 8;
                    b = 5;
                    n_ghosts = 26;
                    break;
            }
            for (int i = start; i <= end; i += 66)
            {
                for (int j = 42; j <= 402; j += 60)
                {
                    Enemies.Add(new Ghost(j, i, Form1.current_difficulty, this));
                    if (j != 402)
                    {
                        Enemies.Add(new Ghost(j + 30, i + 33, Form1.current_difficulty, this));
                    }
                }
            }
            T_G.Enabled = true; // Empieza el juego
        }

        private void T_D_Tick(object sender, EventArgs e)
        {
            if (death_state == 'm')
            {
                //Fin de la animación
                T_D.Interval = 500;
                PBP.Image = null;
                PBP.BackColor = Color.Transparent;
                death_state++;
            }
            else if (death_state == 'n')
            {
                T_D.Interval = 4000;
                //Esconder las gráficas
                PB_fl.Visible = false;
                foreach(Ghost x in Enemies)
                {
                    x.PB.Visible = false;
                }
                foreach(Shots x in Lasers_pacman)
                {
                    x.PB.Visible = false;
                }
                foreach (Shots x in Lasers_ghosts)
                {
                    x.PB.Visible = false;
                }
                this.BackgroundImage = Properties.Resources.Lose;
                Defeat.Play();
                death_state++;
            }
            else if (death_state == 'o')
            {
                T_D.Interval = 100;
                PB_go_win.Image = Properties.Resources.game_over;
                PB_go_win.Visible = true;
                PB_press.Visible = true;
                PB_press.Image = Properties.Resources.Press_start_go;
                input.Pull();
                switch (input.key)
                {
                    case "Buttons9":
                        System.Windows.Forms.Application.Exit();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //Animación
                if (death_state == 'a')
                {
                    tmp = new StringBuilder("Da_u");
                    Death.Play();
                }
                tmp[1] = death_state;
                var value = Properties.Resources.ResourceManager.GetObject(Convert.ToString(tmp), Properties.Resources.Culture);
                PBP.Image = (Bitmap)value;
                death_state++;
            }
        }

        private void T_W_Tick(object sender, EventArgs e)
        {
            if (win_state == 0)
            {
                this.BackgroundImage = Properties.Resources.rainbow;
                PB_fl.Visible = false;
            }
            else if (win_state == 2 )
            {
                this.BackgroundImage = Properties.Resources.rainbow;
            }
            else if (win_state == 1)
            {
                this.BackgroundImage = Properties.Resources.Cage;
            }
            else if (win_state == 3)
            {
                //Esconder las gráficas
                T_D.Interval = 4000;
                Win.Play();
                foreach (Ghost x in Enemies)
                {
                    x.PB.Visible = false;
                }
                foreach (Shots x in Lasers_pacman)
                {
                    x.PB.Visible = false;
                }
                foreach (Shots x in Lasers_ghosts)
                {
                    x.PB.Visible = false;
                }
                this.BackgroundImage = null;
                this.BackColor = Color.Black;
                PB_win.Visible = true;
                PB_go_win.Image = Properties.Resources.Win;
                PB_go_win.Visible = true;
                PBP.Visible = false;
            }
            else
            {
                T_W.Interval = 50;
                PB_press.Image = Properties.Resources.Press_start_win;
                PB_press.Visible = true;
                input.Pull();
                switch (input.key)
                {
                    case "Buttons9":
                        System.Windows.Forms.Application.Exit();
                        break;
                    default:
                        break;
                }
            }
            win_state++;
        }
    }
}
