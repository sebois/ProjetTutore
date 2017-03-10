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
        #region Attributs
        /// <summary>
        /// m_manche = numéro de la manche en cours
        /// </summary>
        private byte m_manche;

        /// <summary>
        /// Nombre de pépites à collecter restantes (~jetons pépites)
        /// </summary>
        private byte m_nbPepite;

        /// <summary>
        /// Pointeur vers le joueur qui joue actuellement
        /// </summary>
        private Joueur m_joueurActif;

        /// <summary>
        /// Flag levé lorsque le Drag & Drop doit être désactivé
        /// </summary>
        private bool m_dragDropDone;

        /// <summary>
        /// Flag levé lorsque le clic gauche est effectué
        /// </summary>
        private bool m_mouseLeft;

        /// <summary>
        /// Objet Plateau contenant les paquets de cartes
        /// </summary>
        private Plateau m_Plateau;

        /// <summary>
        /// Objet Joueur pour le Joueur 1
        /// </summary>
        private Joueur m_Joueur1;

        /// <summary>
        /// Objet Joueur pour le Joueur 2
        /// </summary>
        private Joueur m_Joueur2;

        /// <summary>
        /// Liste de PictureBox destinations du DragAndDrop
        /// </summary>
        private List<PictureBox> m_picDest;

        /// <summary>
        /// Liste de PictureBox sources du DragAndDrop
        /// </summary>
        private List<PictureBox> m_picSource;

        /// <summary>
        /// Nombre aléatoire
        /// </summary>
        private Random m_rnd = new Random();
        #endregion

        #region Constructeur
        public Form1()
        {
            InitializeComponent();
            /*
             * Gestionnaires d'évènements Drag and Drop de tableLayoutPanel1
             * Dimensionnement automatique des images
             */
            foreach (PictureBox pic in tableLayoutPanel1.Controls)
            {
                pic.DragEnter += new DragEventHandler(pictureBox_DragEnter);
                pic.DragDrop += new DragEventHandler(pictureBox_DragDrop);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;
            }
            /*
             * Gestionnaire d'évènements Drag and Drop de pnl_defausse
             */
            foreach (PictureBox pic in pnl_defausse.Controls)
            {
                pic.DragEnter += new DragEventHandler(pictureBox_DragEnter);
                pic.DragDrop += new DragEventHandler(pictureBox_DragDrop);
            }
            /*
             * Gestionnaire d'évènement du clic et du déplacement de la souris
             */
            foreach (PictureBox pic in pnl_main.Controls)
            {
                pic.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
                pic.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
            }
            /*
             * Initialise les flag et les compteurs
             */
            m_dragDropDone = false;
            m_manche = 0;
            m_nbPepite = 8;
            /*
             * Initialise les listes de pointeurs vers les PictureBox
             */
            m_picSource = new List<PictureBox>();
            m_picDest = new List<PictureBox>();
        }
        #endregion

        #region Méthodes
        #region Evènements
        private void Form1_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Autorise le Drag and Drop
            /// </summary>
            foreach (PictureBox pic in tableLayoutPanel1.Controls)
            {
                pic.AllowDrop = true;
            }
            foreach (PictureBox pic in pnl_defausse.Controls)
            {
                pic.AllowDrop = true;
            }
            txt_J1.Text = "Seb";
            txt_J2.Text = "Lili";
        }

        /// <summary>
        /// Evenement de clic déclenché si le DragAndDrop n'a pas encore été effectué
        /// </summary>
        /// <param name="sender">Pointeur de la PictureBox</param>
        /// <param name="e">Evènement de la Souris</param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            /*
             * Flag clic gauche levé si clic gauche et flag du Drag and Drop non levé
             */
            if (e.Button == MouseButtons.Left && !m_dragDropDone)
            { 
                m_mouseLeft = true;
            }
            /*
             * Rotation de la carte si CarteChemin et clic droit
             */
            else if (e.Button == MouseButtons.Right)
            {
                PictureBox v_pic = (PictureBox)sender;
                if (v_pic.Tag.GetType() == typeof(CarteChemin))
                {
                    CarteChemin v_carte = (CarteChemin)v_pic.Tag;
                    v_carte.Rotation();
                    v_pic.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    v_pic.Refresh();
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_mouseLeft)
            {
                /*
                 * Récupère le type de carte grâce au pointeur contenu dans le Tag de la PictureBox
                 */
                PictureBox v_pic1 = (PictureBox)sender;
                Type v_type = v_pic1.Tag.GetType();
                /*
                 * Pointeur de la PictureBox source du DragAndDrop 
                 */
                m_picSource.Add(v_pic1);
                /*
                 * Lance et attend la fin du DragAndDrop
                 */
                if (v_pic1.DoDragDrop(v_pic1.Image, DragDropEffects.Copy) == DragDropEffects.Copy && m_picDest.Count > 0)
                {
                    /*
                     * Supprime l'image dans la PictureBox source et affecte le tag de la PictureBox destination avec la carte
                     */
                    v_pic1.Image = null;
                    m_picDest.Last().Tag = v_pic1.Tag;
                }
                else
                {
                    /*
                     * Retire la dernière carte dans la liste PictureBox sources
                     */
                    m_picSource.Remove(m_picSource.Last());
                }
                m_mouseLeft = false;
            }
        }

        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data.GetDataPresent(DataFormats.Bitmap)))
            {
                PictureBox v_pic2 = (PictureBox)sender;
                
                /*
                 * Vérifie que la PictureBox de destination ne possède pas déjà une image
                 */
                if (v_pic2.Image == null)
                {
                    TableLayoutPanel v_panel = (TableLayoutPanel)v_pic2.Parent;
                    TableLayoutPanelCellPosition v_cellPosition = v_panel.GetPositionFromControl(v_pic2);

                    /*
                     * Affecte l'image de la PictureBox de destination, pointeur vers la PictureBox de destination et flag
                     */
                    if (((m_picSource.Last().Tag.GetType().IsSubclassOf(typeof(CartePlacable)))
                        && v_panel.Equals(tableLayoutPanel1)
                        && isPlacableAtCell(v_cellPosition)
                        && m_picDest.Count == 0)
                        || v_panel.Equals(pnl_defausse))
                    {
                        Bitmap v_bitmap = (Bitmap)(e.Data.GetData(DataFormats.Bitmap));
                        v_pic2.Image = v_bitmap;
                        m_picDest.Add(v_pic2);
                    }
                    if ( (v_panel.Equals(tableLayoutPanel1) && m_picDest.Count == 1) || (m_picDest.Count == 2))
                    {
                        m_dragDropDone = true;
                    }
                }
            }
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            if(m_manche == 0)
            {
                /*
                 * Vérifie l'affectation des noms
                 */
                if ((txt_J1.Text != "") && (txt_J2.Text != ""))
                {
                    /*
                     * Créé le Plateau, les joueurs, lance la manche 1, affiche les controles et place les cases départ
                     */ 
                    m_Plateau = new Plateau();
                    initJoueurs();
                    m_manche++;
                    afficherElements();
                    placerDeparts();
                    placerObjectifsRetournes();
                }
            }
            /*
             * Vérifie si un DragAndDrop a été réalisé
             */
            else if(m_picDest.Count > 0)
            {
                /*
                 * Récupère la carte et la retire de la main du joueur
                 * Réinitialise le pointeur de carte de la PictureBox source
                 * Le joueur pioche 1 carte
                 * flag baissé
                 */
                int v_countPic = m_picSource.Count;
                for(int i=0; i<v_countPic; i++)
                {
                    Carte v_carte = (Carte)m_picSource.Last().Tag;
                    m_joueurActif.RetirerCarteDeLaMain(m_Plateau, v_carte);
                    m_picSource.Last().Tag = null;
                    m_joueurActif.Piocher(m_Plateau, 1);
                    m_picSource.Remove(m_picSource.Last());
                    if(m_picDest.Last().Parent != tableLayoutPanel1)
                    {
                        m_picDest.Last().Image = null;
                        m_picDest.Last().Tag = null;
                    }
                    m_picDest.Remove(m_picDest.Last());
                }
                m_dragDropDone = false;

                /*
                 * Changement de joueur
                 */
                if (m_joueurActif == m_Joueur1)
                {
                    m_joueurActif = m_Joueur2;
                }
                else
                { 
                    m_joueurActif = m_Joueur1;
                }
            }
            /*
             * Mise à jour de l'affichage des compteurs et de la main du joueur
             */
            majCompteurs();
            majCartes();
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            /*
             * Réinitialise la PictureBox de destination, baisse le flag et met à jour la main du joueur
             */
            if (m_picDest.Count > 0)
            {
                int v_CountList = m_picDest.Count;
                for (int i = 0; i < v_CountList; i++)
                {
                    PictureBox pic = m_picDest.ElementAt(0);
                    pic.Image = null;
                    pic.Tag = null;
                    m_picDest.Remove(pic);
                    pic = m_picSource.ElementAt(0);
                    m_picSource.Remove(pic);
                }
                m_dragDropDone = false;
                majCartes();
            }
        }
        #endregion
        #region Initialisation des joueurs
        /// <summary>
        /// Initialise les joueurs aléatoirement
        /// </summary>
        private void initJoueurs()
        {
            int v_aleatoire = m_rnd.Next()%2;
            switch (v_aleatoire)
            {
                case 0:
                    m_Joueur1 = new Joueur(txt_J1.Text, Couleur.Vert, m_Plateau);
                    m_Joueur2 = new Joueur(txt_J2.Text, Couleur.Bleu, m_Plateau);
                    m_joueurActif = m_Joueur1;
                    break;
                case 1:
                    m_Joueur1 = new Joueur(txt_J1.Text, Couleur.Bleu, m_Plateau);
                    m_Joueur2 = new Joueur(txt_J2.Text, Couleur.Vert, m_Plateau);
                    m_joueurActif = m_Joueur2;
                    break;
            }
        }
        #endregion
        #region MAJ interface utilisateur
        /// <summary>
        /// Met à jour l'affichage des compteurs
        /// </summary>
        private void majCompteurs()
        {
            lbl_manche.Text = "Manche " + m_manche + "/3";
            lbl_pepite.Text = "Pépites restantes : " + m_nbPepite;
            if (m_joueurActif == m_Joueur1)
            {
                lbl_tourDe.Text = "Tour Joueur 1 : Nain " + m_Joueur1.CouleurJoueur;
            }
            else
            {
                lbl_tourDe.Text = "Tour Joueur 2 : Nain " + m_Joueur2.CouleurJoueur;
            }
        }

        /// <summary>
        /// Met à jour la main du joueur
        /// </summary>
        private void majCartes()
        {
            for (int i = 0; i < m_joueurActif.MainJoueur.Count; i++)
            {
                PictureBox pic = (PictureBox)pnl_main.Controls[i];
                pic.Image = m_joueurActif.getCarteAtPosition(i).ImgRecto;
                pic.Tag = m_joueurActif.getCarteAtPosition(i);
            }
        }
        #endregion
        #region Initialisation interface utilisateur
        /// <summary>
        /// Affiche les contrôles
        /// </summary>
        private void afficherElements()
        {
            pnl_joueur.Visible = true;
            pnl_zoneDefausse.Visible = true;
            tableLayoutPanel1.Visible = true;
            lbl_manche.Visible = true;
            lbl_pepite.Visible = true;
            lbl_tourDe.Visible = true;
            txt_J1.Enabled = false;
            txt_J1.BorderStyle = BorderStyle.FixedSingle;
            txt_J2.Enabled = false;
            txt_J2.BorderStyle = BorderStyle.FixedSingle;
            btn_undo.Visible = true;
        }

        /// <summary>
        /// Place les cartes départ
        /// </summary>
        private void placerDeparts()
        {
            PictureBox pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(2, 4);
            m_Plateau.Departs.ElementAt(0).Id = m_Plateau.Id++;
            pic.Image = m_Plateau.Departs.ElementAt(0).ImgRecto;
            pic.Tag = m_Plateau.Departs.ElementAt(0);
            pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(2, 6);
            m_Plateau.Departs.ElementAt(1).Id = m_Plateau.Id++;
            pic.Image = m_Plateau.Departs.ElementAt(1).ImgRecto;
            pic.Tag = m_Plateau.Departs.ElementAt(1);
        }

        /// <summary>
        /// Place les cartes Objectifs retournées
        /// </summary>
        private void placerObjectifsRetournes()
        {
            Bitmap picObjectifRetourne = new Bitmap("Cartes/CarteRetourneObjectif.jpg");
            List<PictureBox> listePic = new List<PictureBox>();
            listePic.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(7, 3));
            listePic.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(7, 5));
            listePic.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(7, 7));
            listePic.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(9, 4));
            listePic.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(9, 6));
            listePic.Add((PictureBox)tableLayoutPanel1.GetControlFromPosition(11, 5));
            foreach (PictureBox v_pic in listePic)
            {
                v_pic.Image = picObjectifRetourne;
                v_pic.Tag = typeof(CarteObjectif);
            }
        }  
        #endregion

        /// <summary>
        /// Teste si le placement est possible avec chaque cellule voisine
        /// Ordre des tests: Haut, Droite, Bas, Gauche
        /// Dans le cas où toutes les cellules voisines sont vides le test est faux
        /// </summary>
        /// <param name="p_cellPosition">Position de la Cellule cible du DragAndDrop</param>
        /// <returns></returns>
        private bool isPlacableAtCell(TableLayoutPanelCellPosition p_cellPosition)
        {
            int v_compteurException = 0, v_incrementX = 0, v_incrementY = -1;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY, ref v_compteurException))
                return false;
            v_incrementX = 1 ; v_incrementY = 0;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY, ref v_compteurException))
                return false;
            v_incrementX = 0; v_incrementY = 1;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY, ref v_compteurException))
                return false;
            v_incrementX = -1; v_incrementY = 0;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY, ref v_compteurException))
                return false;
            if (v_compteurException != 4)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Teste si le placement est possible avec la cellule sélectionnée
        /// Récupère chaque carte et teste si les entrées et sorties de chacune sont compatibles
        /// Dans le cas où la cellule est vide le test est vrai mais le compteur de cellules vides est incrémenté
        /// </summary>
        /// <param name="p_cellPosition">Position de la Cellule cible du DragAndDrop</param>
        /// <param name="p_incrementX">Incrémentation de la colonne pour trouver la cellule voisine</param>
        /// <param name="p_incrementY">Incrémentation de la ligne pour trouver la cellule voisine</param>
        /// <param name="p_compteurException">Compteur du nombre de cellules voisines vides</param>
        /// <returns></returns>
        private bool testPlacementVoisin(TableLayoutPanelCellPosition p_cellPosition, int p_incrementX, 
            int p_incrementY, ref int p_compteurException)
        {
            CartePlacable v_carte = (CartePlacable)m_picSource.Last().Tag;
            PictureBox v_picVoisin;
            CartePlacable v_carteVoisin;
            try
            {
                v_picVoisin = (PictureBox)tableLayoutPanel1.GetControlFromPosition(
                    p_cellPosition.Column + p_incrementX, p_cellPosition.Row + p_incrementY);
                if (v_picVoisin.Tag.Equals(typeof(CarteObjectif)))
                {
                    //TODO with MatriceAdjacence
                    List<Carte> v_listeCartes = new List<Carte>(m_Plateau.Objectifs);
                    v_picVoisin.Tag = m_Plateau.PrendreCarte(v_listeCartes);
                    CarteObjectif v_carteObjectif = (CarteObjectif)v_picVoisin.Tag;
                    v_picVoisin.Image = v_carteObjectif.ImgRecto;
                    
                }
                else
                {
                    v_carteVoisin = (CartePlacable)v_picVoisin.Tag;
                    if (p_incrementY == -1)
                    {
                        if ((!v_carteVoisin.M_bas && v_carte.M_haut) || (v_carteVoisin.M_bas && !v_carte.M_haut))
                        {
                            return false;
                        }
                    }
                    else if (p_incrementX == 1)
                    {
                        if ((!v_carteVoisin.M_gauche && v_carte.M_droite) || (v_carteVoisin.M_gauche && !v_carte.M_droite))
                        {
                            return false;
                        }
                    }
                    else if (p_incrementY == 1)
                    {
                        if ((!v_carteVoisin.M_haut && v_carte.M_bas) || (v_carteVoisin.M_haut && !v_carte.M_bas))
                        {
                            return false;
                        }
                    }
                    else if (p_incrementX == -1)
                    {
                        if ((!v_carteVoisin.M_droite && v_carte.M_gauche) || (v_carteVoisin.M_droite && !v_carte.M_gauche))
                        {
                            return false;
                        }
                    }
                }
            }
            catch (ArgumentException ex) { p_compteurException++; }
            catch (NullReferenceException ex) { p_compteurException++; }
            return true;
        }

        #endregion
    }
}
