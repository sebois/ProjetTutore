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
        private Joueur m_joueurActif;
        private bool m_dragDropDone;
        private bool m_mouseLeft;
        private Plateau m_Plateau;
        private Joueur m_Joueur1;
        private Joueur m_Joueur2;

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
                pic.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
            }
            m_dragDropDone = false;
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
            if (e.Button == MouseButtons.Left && !m_dragDropDone)
            { 
                m_mouseLeft = true;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_mouseLeft)
            {
                PictureBox v_pic1 = (PictureBox)sender;
                Type v_type = v_pic1.Tag.GetType();
                if (v_type.IsSubclassOf(typeof(CartePlacable)) && v_pic1.DoDragDrop(v_pic1.Image, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    CartePlacable v_carte = (CartePlacable)v_pic1.Tag;
                    m_joueurActif.RetirerCarteDeLaMain(m_Plateau, v_carte);
                    v_pic1.Image = null;
                    v_pic1.MouseDown -= pictureBox_MouseDown;
                    v_pic1.MouseMove -= pictureBox_MouseMove;
                    m_mouseLeft = false;
                }
            }
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
            {
                if (pic2.Parent == tableLayoutPanel1)
                {
                    pic2.Image = (Bitmap)(e.Data.GetData(DataFormats.Bitmap));
                    m_dragDropDone = true;
                }
            }
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
                    placerDeparts();
                }
            }
            else
            {
                if(m_joueurActif == m_Joueur1)
                {
                    m_joueurActif = m_Joueur2;
                }
                else
                { 
                    m_joueurActif = m_Joueur1;
                }
            }
            majCompteurs();
            majCartes();
            m_dragDropDone = false;
        }

        private void initJoueurs()
        {
            Random rand = new Random();
            byte v_aleatoire = (byte)rand.Next(1, 2);
            switch (v_aleatoire)
            {
                case 1:
                    m_Joueur1 = new Joueur(txt_J1.Text, Couleur.Vert, m_Plateau);
                    m_Joueur2 = new Joueur(txt_J2.Text, Couleur.Bleu, m_Plateau);
                    m_joueurActif = m_Joueur1;
                    break;
                case 2:
                    m_Joueur1 = new Joueur(txt_J1.Text, Couleur.Bleu, m_Plateau);
                    m_Joueur2 = new Joueur(txt_J2.Text, Couleur.Vert, m_Plateau);
                    m_joueurActif = m_Joueur2;
                    break;
            }

        }

        private void majCompteurs()
        {
            lbl_manche.Text = "Manche " + m_manche + "/3";
            lbl_pepite.Text = "Pépites restantes : " + m_nbPepite;
            if (m_joueurActif == m_Joueur1)
            {
                lbl_tourDe.Text = "Tour Joueur 1";
            }
            else
            {
                lbl_tourDe.Text = "Tour Joueur 2";
            }
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
            for(int i=0; i<m_joueurActif.MainJoueur.Count; i++)
            {
                PictureBox pic = (PictureBox)pnl_main.Controls[i];
                pic.Image = m_joueurActif.getCarteAtPosition(i).ImgRecto;
                pic.Tag = m_joueurActif.getCarteAtPosition(i);
            }
        }

        private void placerDeparts()
        {
            PictureBox pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(2, 4);
            m_Plateau.Departs.ElementAt(0).Id = m_Plateau.Id++;
            pic.Image = m_Plateau.Departs.ElementAt(0).ImgRecto;
            pic.Tag = m_Plateau.Id;
            m_Plateau.TableauId[2, 4] = m_Plateau.Id++;
            pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(2, 6);
            m_Plateau.Departs.ElementAt(1).Id = m_Plateau.Id++;
            pic.Image = m_Plateau.Departs.ElementAt(1).ImgRecto;
            pic.Tag = m_Plateau.Id;
            m_Plateau.TableauId[2, 6] = m_Plateau.Id++;
        }
    }
}
