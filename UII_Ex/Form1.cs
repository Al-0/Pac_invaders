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
    public partial class Form1 : Form
    {
        //Sonidos
        SoundPlayer Ambient = new SoundPlayer(Properties.Resources.Start_ambient);
        SoundPlayer Button = new SoundPlayer(Properties.Resources.Button_sound);
        SoundPlayer Start = new SoundPlayer(Properties.Resources.Game_start);

        //Control
        Controller input = new Controller(); // Control
        
        //Pantalla de juego principal
        Game Game_screen = new Game();

        int delay = 0;  //Delay para la música de introducción
        static public int current_difficulty = 0;  //Determina el label a mostrar y las opciones de carga en la pantalla de juego

        public Form1()
        {
            InitializeComponent();
            Ambient.Play();
        }

        private void T_start_Tick(object sender, EventArgs e)
        {
            if (input.value == 1000000) this.Close();   //Sí no se detecto el gamepad.
            delay++;
            if (delay == 30)
            {
                //Música ha terminado, se muestra el menú principal
                delay = 35;
                PB_dif.Visible = true;
                PB_l.Visible = true;
                PB_r.Visible = true;
                PB_sel.Visible = true;
                Ambient.Stop();
            }
            if (delay == 35)
            {
                delay--;
                input.Pull();
                switch(input.key)
                {
                    case "PointOfViewControllers0":
                        //Selección de dificultad
                        if (input.value == 27000)
                        {
                            Button.Play();
                            current_difficulty = (current_difficulty + 3 - 1) % 3;
                            switch (current_difficulty)
                            {
                                case 0:
                                    PB_dif.Image = Properties.Resources.Easy;
                                    break;
                                case 1:
                                    PB_dif.Image = Properties.Resources.Medium;
                                    break;
                                case 2:
                                    PB_dif.Image = Properties.Resources.Hard;
                                    break;
                            }
                        }
                        else if (input.value == 9000)
                        {
                            Button.Play();
                            current_difficulty = (current_difficulty + 1) % 3;
                            switch (current_difficulty)
                            {
                                case 0:
                                    PB_dif.Image = Properties.Resources.Easy;
                                    break;
                                case 1:
                                    PB_dif.Image = Properties.Resources.Medium;
                                    break;
                                case 2:
                                    PB_dif.Image = Properties.Resources.Hard;
                                    break;
                            }
                        }
                        break;
                    case "Buttons2":
                        //Empezar el juego
                        Start.Play();
                        T_start.Enabled = false;
                        Game_screen.Show();
                        this.Hide();
                        break;
                    case "Buttons9":
                        //Cerrar el juego
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
