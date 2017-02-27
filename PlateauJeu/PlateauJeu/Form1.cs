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
        private byte m_manche;
        private byte m_nbPepite;
        private byte m_tourDe;
        Plateau m_Plateau;
        Joueur m_Joueur1;
        Joueur m_Joueur2;

        public Form1()
        {
            InitializeComponent();
            /// <summary>
            /// Gestionnaires d'évènements Drag and Drop
            /// Dimensionnement automatique des images
            /// </summary>
            foreach (PictureBox pic in tableLayoutPanel1.Controls)
            {
                pic.DragEnter += new DragEventHandler(pictureBox_DragEnter);
                pic.DragDrop += new DragEventHandler(pictureBox_DragDrop);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;
            }
            /// <summary>
            /// Gestionnaire d'évènement du clic
            /// </summary>
            foreach (PictureBox pic in pnl_main.Controls)
            {
                pic.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            }
            m_manche = 0;
            m_nbPepite = 8;
            //m_Plateau = new Plateau();
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
            txt_J1.Text = "Tomori";
            txt_J2.Text = "Isla";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(m_manche == 0)
            {
                if ((txt_J1.Text != "") && (txt_J2.Text != ""))
                {
                    m_Plateau = new Plateau();
                    initJoueurs();
                    m_manche++;
                    afficherElements();
                }
            }
            else
            {
                switch (m_tourDe)
                {
                    case 1:
                        m_tourDe = 2;
                        break;
                    case 2:
                        m_tourDe = 1;
                        break;
                }
            }
            majCompteurs();
            majCartes();
        }

        private void initJoueurs()
        {
            Random rand = new Random();
            m_tourDe = (byte)rand.Next(1, 2);
            switch (m_tourDe)
            {
                case 1:
                    m_Joueur1 = new Joueur(txt_J1.Text, Couleur.Vert, m_Plateau);
                    m_Joueur2 = new Joueur(txt_J2.Text, Couleur.Bleu, m_Plateau);
                    break;
                case 2:
                    m_Joueur1 = new Joueur(txt_J1.Text, Couleur.Bleu, m_Plateau);
                    m_Joueur2 = new Joueur(txt_J2.Text, Couleur.Vert, m_Plateau);
                    break;
            }

        }

        private void majCompteurs()
        {
            lbl_manche.Text = "Manche " + m_manche + "/3";
            lbl_pepite.Text = "Pépites restantes : " + m_nbPepite;
            lbl_tourDe.Text = "Tour Joueur " + m_tourDe;
        }

        private void afficherElements()
        {
            pnl_joueur.Visible = true;
            tableLayoutPanel1.Visible = true;
            lbl_manche.Visible = true;
            lbl_pepite.Visible = true;
            lbl_tourDe.Visible = true;
            txt_J1.Enabled = false;
            txt_J2.Enabled = false;
        }

        private void majCartes()
        {
            switch(m_tourDe)
            {
                case 1:
                    for(int i=0; i<pnl_main.Controls.Count; i++)
                    {
                        PictureBox pic = (PictureBox)pnl_main.Controls[i];
                        pic.Image = m_Joueur1.getImageByPosition(i);
                    }
                    break;
            }
            
        }
    }
}
