using PlateauJeu.Class_Cartes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlateauJeu
{
    public partial class Form1 : Form
    {
        Plateau monPlateau;
        Joueur joueur1;
        Joueur joueur2;

        public Form1()
        {
            InitializeComponent();
            /// <summary>
            /// Gestionnaires d'évènements Drag and Drop
            /// </summary>
            foreach (PictureBox pic in tableLayoutPanel1.Controls)
            {
                pic.DragEnter += new DragEventHandler(pictureBox_DragEnter);
                pic.DragDrop += new DragEventHandler(pictureBox_DragDrop);
            }
            /// <summary>
            /// Gestionnaire d'évènement du clic
            /// </summary>
            foreach (PictureBox pic in panel1.Controls)
            {
                pic.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            }             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Autorise le Drag and Drop
            /// </summary>
            foreach (PictureBox pic in tableLayoutPanel1.Controls)
            {
                pic.AllowDrop = true;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic1 = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
                pic_test.DoDragDrop(pic1.Image, DragDropEffects.Move);
        }

        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pic2 = (PictureBox)sender;
            if ((e.Data.GetDataPresent(DataFormats.Bitmap)))
                pic2.Image = (Bitmap)(e.Data.GetData(DataFormats.Bitmap));
        }
    }
}
