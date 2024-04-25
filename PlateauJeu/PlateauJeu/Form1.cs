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
        /// Nombre de jetons nains restants (~jetons pépites)
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
        /// Outil à réparer
        /// </summary>
        private OutilsBrises m_outilDest;

        /// <summary>
        /// Liste des voisins de la carte à placer
        /// </summary>
        private List<PictureBox> m_picVoisins;

        /// <summary>
        /// Liste de PictureBox contenant des objectifs à initialiser
        /// </summary>
        private List<PictureBox> m_listeObjectifsAPlacer;

        /// <summary>
        /// Nombre aléatoire
        /// </summary>
        private Random m_rnd = new Random();

        /// <summary>
        /// Matrice d'adjacence
        /// </summary>
        private MatriceAdjacences m_matriceAjacences;
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
                pic.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
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
                pic.DoubleClick += new EventHandler(pictureBox_DoubleClick);
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
            m_matriceAjacences = new MatriceAdjacences();
            m_listeObjectifsAPlacer = new List<PictureBox>();
        }
        #endregion

        #region Méthodes
        #region Evènements
        /// <summary>
        /// Autorise le Drag and Drop au chargement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox pic in tableLayoutPanel1.Controls)
            {
                pic.AllowDrop = true;
            }
            foreach (PictureBox pic in pnl_defausse.Controls)
            {
                pic.AllowDrop = true;
            }
        }

        /// <summary>
        /// Gestion des clics de la souris pour lancer le Drag & Drop ou retourner la carte Chemin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (v_pic.Tag != null)
                {
                    if (v_pic.Tag.GetType() == typeof(CarteChemin))
                    {
                        CarteChemin v_carte = (CarteChemin)v_pic.Tag;
                        v_carte.Rotation();
                        v_pic.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        v_pic.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Gestion du déplacement de la souris après un clic gauche (Drag & Drop)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_mouseLeft)
            {
                /*
                 * Récupère le type de carte grâce au pointeur contenu dans le Tag de la PictureBox
                 */
                PictureBox v_pic1 = (PictureBox)sender;
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

        /// <summary>
        /// Gestion du double clic sur une carte de la main du joueur, permet d'utiliser une carte action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox v_pic = (PictureBox)sender;
            Carte v_carte = (Carte)v_pic.Tag;
            if (v_carte.GetType().IsSubclassOf(typeof(Class_Cartes.Action)) && !m_dragDropDone)
            {
                DialogResult dialogResult = MessageBox.Show("Voulez-vous utiliser cette carte ?", "Validation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    /*
                     * Utilisation d'une carte OutilsBrises
                     */
                    if (v_carte.GetType().Equals(typeof(OutilsBrises)))
                    {
                        Joueur v_joueurCible;
                        OutilsBrises v_carteAction = (OutilsBrises)v_carte;
                        Outils v_outilABriser = v_carteAction.Outils;
                        bool v_flag = true;
                        /*
                         * Définition du joueur cible
                         */
                        if (m_joueurActif.NumeroJoueur == 1)
                        {
                            v_joueurCible = m_Joueur2;
                        }
                        else
                            v_joueurCible = m_Joueur1;

                        /*
                         * Vérifie si l'outil du joueur adverse est déjà brisé
                         */
                        switch (v_outilABriser)
                        {
                            case Outils.Chariot:
                                if (!v_joueurCible.Chariot)
                                {
                                    v_flag = false;
                                }
                                break;
                            case Outils.Lampe:
                                if (!v_joueurCible.Lampe)
                                {
                                    v_flag = false;
                                }
                                break;
                            case Outils.Pioche:
                                if (!v_joueurCible.Pioche)
                                {
                                    v_flag = false;
                                }
                                break;
                        }
                        /*
                         * Utilisation de la carte
                         */
                        if (v_flag)
                        {
                            v_carteAction.Utiliser(v_joueurCible);
                            v_pic.Image = null;
                            m_picSource.Add(v_pic);
                            m_dragDropDone = true;
                        }
                        else
                            MessageBox.Show("L'outil du joueur adverse est déjà brisé");
                    }
                    /*
                     * Utilisation d'une carte Reparer
                     */
                    if (v_carte.GetType().Equals(typeof(Reparer)))
                    {
                        if (m_joueurActif.CartesEntraveJoueur.Count > 0)
                        {
                            Reparer v_carteAction = (Reparer)v_carte;
                            List<Outils> v_outilsAReparer = v_carteAction.Outils;
                            Outils v_outilAReparer = 0;
                            bool v_flag = true, v_refusReparation = false;
                            if (!m_joueurActif.Chariot)
                            {
                                int i = 0;
                                while (v_flag && i < v_outilsAReparer.Count)
                                {
                                    if (v_outilsAReparer.ElementAt(i) == Outils.Chariot)
                                    {
                                        DialogResult dialogResultReparer = MessageBox.Show("Voulez-vous réparer votre chariot ?", "Validation", MessageBoxButtons.YesNo);
                                        if (dialogResultReparer == DialogResult.Yes)
                                        {
                                            v_flag = false;
                                            v_outilAReparer = Outils.Chariot;
                                        }
                                        else v_refusReparation = true;
                                    }
                                    i++;
                                }
                            }
                            if (v_flag && !m_joueurActif.Lampe)
                            {
                                int i = 0;
                                while (v_flag && i < v_outilsAReparer.Count)
                                {
                                    if (v_outilsAReparer.ElementAt(i) == Outils.Lampe)
                                    {
                                        DialogResult dialogResultReparer = MessageBox.Show("Voulez-vous réparer votre Lampe ?", "Validation", MessageBoxButtons.YesNo);
                                        if (dialogResultReparer == DialogResult.Yes)
                                        {
                                            v_flag = false;
                                            v_outilAReparer = Outils.Lampe;
                                        }
                                        else v_refusReparation = true;
                                    }
                                    i++;
                                }
                            }
                            if (v_flag && !m_joueurActif.Pioche)
                            {
                                int i = 0;
                                while (v_flag && i < v_outilsAReparer.Count)
                                {
                                    if (v_outilsAReparer.ElementAt(i) == Outils.Pioche)
                                    {
                                        DialogResult dialogResultReparer = MessageBox.Show("Voulez-vous réparer votre Pioche ?", "Validation", MessageBoxButtons.YesNo);
                                        if (dialogResultReparer == DialogResult.Yes)
                                        {
                                            v_flag = false;
                                            v_outilAReparer = Outils.Pioche;
                                        }
                                        else v_refusReparation = true;
                                    }
                                    i++;
                                }
                            }

                            if (!v_flag)
                            {
                                m_outilDest = v_carteAction.Utiliser(m_joueurActif, v_outilAReparer);
                                v_pic.Image = null;
                                m_picSource.Add(v_pic);
                                m_dragDropDone = true;
                            }
                            else if (v_refusReparation)
                            {
                                MessageBox.Show("Aucune réparation n'a été choisie");
                            } 
                            else
                                MessageBox.Show("Aucun outil réparable avec cette carte");
                        }
                        else
                            MessageBox.Show("Aucun outil brisé");
                    }
                }
            }
        }

        /// <summary>
        /// Ajoute l'effet de copie à l'entrée du Drag & Drop sur une pictureBox cible 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Gestion du Drag & Drop lorsque le clic est relâché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data.GetDataPresent(DataFormats.Bitmap)))
            {
                PictureBox v_pic2 = (PictureBox)sender;
                bool v_flagErreur = false;
                /*
                 * Vérifie que la PictureBox de destination ne possède pas déjà une image
                 */
                if (v_pic2.Image == null)
                {
                    TableLayoutPanel v_panel = (TableLayoutPanel)v_pic2.Parent;
                    TableLayoutPanelCellPosition v_cellPosition = v_panel.GetPositionFromControl(v_pic2);

                    /*
                     * Affecte l'image de la PictureBox de destination, pointeur vers la PictureBox de destination et flag
                     * Teste si la carte est plaçable, drop sur le plateau, n'obstrue aucun chemin autour et aucune carte déjà placée
                     * OU carte envoyée dans la défausse
                     */
                    if (((m_picSource.Last().Tag.GetType().IsSubclassOf(typeof(CartePlacable)))
                        && v_panel.Equals(tableLayoutPanel1)
                        && m_joueurActif.CartesEntraveJoueur.Count == 0
                        && isPlacableAtCell(v_cellPosition)
                        && m_picDest.Count == 0)
                        || v_panel.Equals(pnl_defausse))
                    {
                        Bitmap v_bitmap = (Bitmap)(e.Data.GetData(DataFormats.Bitmap));
                        v_pic2.Image = v_bitmap;
                        m_picDest.Add(v_pic2);
                    }

                    /*
                     * Si les conditions ne sont pas vérifiées, une erreur est déclenchée
                     */
                    else
                    {
                        v_flagErreur = true;
                        e.Effect = DragDropEffects.None;
                    }

                    /*
                     * Bloque le Drag and Drop si une carte est posée sur le plateau ou 2 cartes sont dans la défausse (aucune erreur ne doit être présente)
                     */
                    if (!v_flagErreur && ((v_panel.Equals(tableLayoutPanel1) && m_picDest.Count == 1) || (m_picDest.Count == 2)))
                    {
                        m_dragDropDone = true;
                    }
                }
            }
        }

        ///
        private void btn_end_Click(object sender, EventArgs e)
        {
            if (m_manche == 0)
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
                    /*
                     * Mise à jour de l'affichage des compteurs et de la main du joueur
                     */
                    majCompteurs();
                    majMainJoueur();
                }
            }
            /*
             * Vérifie si un DragAndDrop a été réalisé
             */
            else if (m_picSource.Count > 0)
            {
                /*
                 * Récupère la carte et la retire de la main du joueur
                 * Réinitialise le pointeur de carte de la PictureBox source
                 * Le joueur pioche 1 carte
                 * flag baissé
                 */
                int v_countPic = m_picSource.Count;
                byte v_nbCartesPiochees = 0;
                if (m_joueurActif.CartesEntraveJoueur.Count > 0 && v_countPic == 2 && m_picDest.Last().Parent == pnl_defausse)
                {
                    bool v_flag = true;
                    while (v_flag)
                    {
                        DialogResult dialogResult = MessageBox.Show("Voulez-vous supprimer une carte entrave ?", "Validation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int i = 0;
                            while (v_flag && i < m_joueurActif.CartesEntraveJoueur.Count)
                            {
                                Outils v_outilAReparer = ((OutilsBrises)m_joueurActif.CartesEntraveJoueur.ElementAt(i)).Outils;
                                switch (v_outilAReparer)
                                {
                                    case Outils.Chariot:
                                        DialogResult dialogResultReparer = MessageBox.Show("Voulez-vous réparer votre chariot ?", "Validation", MessageBoxButtons.YesNo);
                                        if (dialogResultReparer == DialogResult.Yes)
                                        {
                                            v_flag = false;
                                            m_joueurActif.Chariot = true;
                                        }
                                        break;
                                    case Outils.Lampe:
                                        dialogResultReparer = MessageBox.Show("Voulez-vous réparer votre lampe ?", "Validation", MessageBoxButtons.YesNo);
                                        if (dialogResultReparer == DialogResult.Yes)
                                        {
                                            v_flag = false;
                                            m_joueurActif.Lampe = true;
                                        }
                                        break;
                                    case Outils.Pioche:
                                        dialogResultReparer = MessageBox.Show("Voulez-vous réparer votre pioche ?", "Validation", MessageBoxButtons.YesNo);
                                        if (dialogResultReparer == DialogResult.Yes)
                                        {
                                            v_flag = false;
                                            m_joueurActif.Pioche = true;
                                        }
                                        break;
                                }
                                if (v_flag)
                                {
                                    i++;
                                }
                                else
                                {
                                    m_joueurActif.CartesEntraveJoueur.Remove(m_joueurActif.CartesEntraveJoueur.ElementAt(i));
                                    v_nbCartesPiochees++;
                                }
                            }
                        }
                        else v_flag = false;
                    }
                }
                for (int i = 0; i < v_countPic; i++)
                {
                    Carte v_carte = (Carte)m_picSource.Last().Tag;
                    m_joueurActif.RetirerCarteDeLaMain(m_Plateau, v_carte);
                    m_picSource.Last().Tag = null;
                    if (v_nbCartesPiochees < v_countPic)
                    {
                        v_nbCartesPiochees++;
                        m_joueurActif.Piocher(m_Plateau, 1);
                    }
                    m_picSource.Remove(m_picSource.Last());
                    if (m_picDest.Count > 0)
                    {
                        if (m_picDest.Last().Parent == pnl_defausse)
                        {
                            m_picDest.Last().Image = null;
                            m_picDest.Last().Tag = null;
                        }
                        m_picDest.Remove(m_picDest.Last());
                    }
                    /*else
                    {
                        switch (m_joueurActif.CouleurJoueur)
                        {
                            case Couleur.Vert:
                                m_matriceAjacences.ajoutAdjacence(((CartePlacable)v_carteSource).Id,
                            ((CartePlacable)v_carteDest).Id, 0);
                                break;
                            case Couleur.Bleu:
                                m_matriceAjacences.ajoutAdjacence(((CartePlacable)v_carteSource).Id,
                            ((CartePlacable)v_carteDest).Id, 1);
                                break;
                        }
                        
                    }*/
                }
                m_dragDropDone = false;

                if (m_listeObjectifsAPlacer.Count > 0)
                {
                    //TODO with MatriceAdjacence
                    List<Carte> v_listeCartes = new List<Carte>(m_Plateau.Objectifs);
                    int v_tailleListe = m_listeObjectifsAPlacer.Count;
                    for (int i = 0; i < v_tailleListe; i++)
                    {
                        PictureBox pic = m_listeObjectifsAPlacer.ElementAt(0);
                        pic.Tag = m_Plateau.PrendreCarte(v_listeCartes);
                        CarteObjectif v_carteObjectif = (CarteObjectif)pic.Tag;
                        pic.Image = v_carteObjectif.ImgRecto;
                        m_listeObjectifsAPlacer.Remove(pic);
                    }
                }

                /*
                 * Changement de joueur
                 */
                if (m_joueurActif.NumeroJoueur == 1)
                {
                    m_joueurActif = m_Joueur2;
                }
                else
                {
                    m_joueurActif = m_Joueur1;
                }
                /*
                 * Mise à jour de l'affichage des compteurs et de la main du joueur
                 */
                majCompteurs();
                majMainJoueur();
            }
        }

        /// <summary>
        /// Gestion du bouton d'annulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_undo_Click(object sender, EventArgs e)
        {
            /*
             * Réinitialise la PictureBox de destination, baisse le flag, enlève les dernières adjacences ajoutées à la matrice et met à jour la main du joueur
             */
            if (m_picSource.Count > 0)
            {
                int v_CountList = m_picSource.Count;
                PictureBox pic;
                for (int i = 0; i < v_CountList; i++)
                {
                    if (m_picDest.Count > 0)
                    {
                        pic = m_picDest.ElementAt(0);
                        pic.Image = null;
                        pic.Tag = null;
                        m_picDest.Remove(pic);
                    }
                    else if (m_picSource.Last().Tag.GetType().Equals(typeof(OutilsBrises)))
                    {
                        if (m_joueurActif.NumeroJoueur == 1)
                        {
                            m_Joueur2.CartesEntraveJoueur.Remove(m_Joueur2.CartesEntraveJoueur.Last());
                        }
                        else
                        {
                            m_Joueur1.CartesEntraveJoueur.Remove(m_Joueur1.CartesEntraveJoueur.Last());
                        }
                    }
                    else if (m_picSource.Last().Tag.GetType().Equals(typeof(Reparer)))
                    {
                        m_joueurActif.CartesEntraveJoueur.Add(m_outilDest);
                    }
                    pic = m_picSource.ElementAt(0);
                    m_picSource.Remove(pic);
                }
                if (m_listeObjectifsAPlacer.Count > 0)
                {
                    m_listeObjectifsAPlacer.RemoveRange(0, m_listeObjectifsAPlacer.Count);
                }
                m_dragDropDone = false;
                m_matriceAjacences.retirerNouvellesAdjacences(m_joueurActif.NumeroJoueur);
                majMainJoueur();
            }
        }

        #endregion
        #region Initialisation des joueurs
        /// <summary>
        /// Initialise les joueurs aléatoirement
        /// </summary>
        private void initJoueurs()
        {
            int v_aleatoire = m_rnd.Next() % 2;
            switch (v_aleatoire)
            {
                case 0:
                    m_Joueur1 = new Joueur(1, txt_J1.Text, Couleur.Vert, m_Plateau);
                    m_Joueur2 = new Joueur(2, txt_J2.Text, Couleur.Bleu, m_Plateau);
                    m_joueurActif = m_Joueur1;
                    break;
                case 1:
                    m_Joueur1 = new Joueur(1, txt_J1.Text, Couleur.Bleu, m_Plateau);
                    m_Joueur2 = new Joueur(2, txt_J2.Text, Couleur.Vert, m_Plateau);
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
            lbl_jetonsNains.Text = "Jetons nains restants : " + m_nbPepite;
            if (m_joueurActif.NumeroJoueur == 1)
            {
                lbl_tourDe.Text = "Tour Joueur 1 : " + m_joueurActif.NomJoueur + " (Nain " + m_joueurActif.CouleurJoueur + ")";
                lbl_pepites.Text = "Pépites sécurisées : " + m_joueurActif.NbPepites;
            }
            else
            {
                lbl_tourDe.Text = "Tour Joueur 2 : " + m_joueurActif.NomJoueur + " (Nain " + m_joueurActif.CouleurJoueur + ")";
                lbl_pepites.Text = "Pépites sécurisées : " + m_joueurActif.NbPepites;
            }
        }

        /// <summary>
        /// Met à jour la main du joueur
        /// </summary>
        private void majMainJoueur()
        {
            foreach (PictureBox pic in pnl_main.Controls)
            {
                pic.Image = null;
                pic.Tag = null;
            }
            for (int i = 0; i < m_joueurActif.MainJoueur.Count; i++)
            {
                PictureBox pic = (PictureBox)pnl_main.Controls[i];
                pic.Image = m_joueurActif.getCarteAtPosition(m_joueurActif.MainJoueur, i).ImgRecto;
                pic.Tag = m_joueurActif.getCarteAtPosition(m_joueurActif.MainJoueur, i);
            }
            foreach (PictureBox pic in pnl_outilBrises.Controls)
            {
                pic.Image = null;
                pic.Tag = null;
            }
            for (int i = 0; i < m_joueurActif.CartesEntraveJoueur.Count; i++)
            {
                PictureBox pic = (PictureBox)pnl_outilBrises.Controls[i];
                pic.Image = m_joueurActif.getCarteAtPosition(m_joueurActif.CartesEntraveJoueur, i).ImgRecto;
                pic.Tag = m_joueurActif.getCarteAtPosition(m_joueurActif.CartesEntraveJoueur, i);
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
            lbl_jetonsNains.Visible = true;
            lbl_tourDe.Visible = true;
            lbl_pepites.Visible = true;
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
        #region Tests de placement

        /// <summary>
        /// Teste si le placement est possible avec chaque cellule voisine
        /// Ordre des tests: Haut, Droite, Bas, Gauche
        /// Dans le cas où toutes les cellules voisines sont vides le test est faux
        /// </summary>
        /// <param name="p_cellPosition">Position de la Cellule cible du DragAndDrop</param>
        /// <returns></returns>
        private bool isPlacableAtCell(TableLayoutPanelCellPosition p_cellPosition)
        {
            List<KeyValuePair<int,int>> v_listeAdjacences = new List<KeyValuePair<int, int>>();
            int v_compteurException = 0, v_incrementX = 0, v_incrementY = -1;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY,
                ref v_compteurException, m_listeObjectifsAPlacer, v_listeAdjacences))
                return false;
            v_incrementX = 1; v_incrementY = 0;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY,
                ref v_compteurException, m_listeObjectifsAPlacer, v_listeAdjacences))
                return false;
            v_incrementX = 0; v_incrementY = 1;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY,
                ref v_compteurException, m_listeObjectifsAPlacer, v_listeAdjacences))
                return false;
            v_incrementX = -1; v_incrementY = 0;
            if (!testPlacementVoisin(p_cellPosition, v_incrementX, v_incrementY,
                ref v_compteurException, m_listeObjectifsAPlacer, v_listeAdjacences))
                return false;
            if (v_compteurException != 4)
            {
                if (m_listeObjectifsAPlacer.Count + v_compteurException != 4)
                {
                    m_matriceAjacences.ListeNouvellesAdjacences = v_listeAdjacences;
                    foreach (KeyValuePair<int, int> adjacence in v_listeAdjacences) {
                        m_matriceAjacences.setAdjacence(true, m_joueurActif.NumeroJoueur, adjacence.Key, adjacence.Value);
                    }
                    m_matriceAjacences.afficherMatriceAdjacence();
                    return true;
                }
                else
                {
                    m_listeObjectifsAPlacer.RemoveRange(0, m_listeObjectifsAPlacer.Count);
                    return false;
                }
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
            int p_incrementY, ref int p_compteurException, List<PictureBox> p_listeObjectifsAPlacer, List<KeyValuePair<int,int>> p_listeAdjacences)
        {
            bool returnValue = true;
            CartePlacable v_carte = (CartePlacable)m_picSource.Last().Tag, v_carteVoisin;
            PictureBox v_picVoisin;
            try
            {
                v_picVoisin = (PictureBox)tableLayoutPanel1.GetControlFromPosition(
                    p_cellPosition.Column + p_incrementX, p_cellPosition.Row + p_incrementY);
                if (v_picVoisin.Tag.Equals(typeof(CarteObjectif)))
                {
                    p_listeObjectifsAPlacer.Add(v_picVoisin);
                }
                else
                {
                    v_carteVoisin = (CartePlacable)v_picVoisin.Tag;
                    /*
                    if (v_carteVoisin.Type == Types.DoubleVirage || v_carteVoisin.Type == Types.DoubleVirage)
                    {

                    }
                    */
                    if (p_incrementY == -1)
                    {
                        if ((!v_carteVoisin.M_bas && v_carte.M_haut) || (v_carteVoisin.M_bas && !v_carte.M_haut))
                        {
                            returnValue = false;
                        } 
                        else if (v_carteVoisin.M_bas && v_carte.M_haut)
                        {
                            p_listeAdjacences.Add(new KeyValuePair<int, int>(v_carte.Id, v_carteVoisin.Id));
                        }
                    }
                    else if (p_incrementX == 1)
                    {
                        if ((!v_carteVoisin.M_gauche && v_carte.M_droite) || (v_carteVoisin.M_gauche && !v_carte.M_droite))
                        {
                            returnValue = false;
                        }
                        else if (v_carteVoisin.M_gauche && v_carte.M_droite)
                        {
                            p_listeAdjacences.Add(new KeyValuePair<int, int>(v_carte.Id, v_carteVoisin.Id));
                        }
                    }
                    else if (p_incrementY == 1)
                    {
                        if ((!v_carteVoisin.M_haut && v_carte.M_bas) || (v_carteVoisin.M_haut && !v_carte.M_bas))
                        {
                            returnValue = false;
                        }
                        else if (v_carteVoisin.M_haut && v_carte.M_bas)
                        {
                            p_listeAdjacences.Add(new KeyValuePair<int, int>(v_carte.Id, v_carteVoisin.Id));
                        }
                    }
                    else if (p_incrementX == -1)
                    {
                        if ((!v_carteVoisin.M_droite && v_carte.M_gauche) || (v_carteVoisin.M_droite && !v_carte.M_gauche))
                        {
                            returnValue = false;
                        }
                        else if (v_carteVoisin.M_droite && v_carte.M_gauche)
                        {
                            p_listeAdjacences.Add(new KeyValuePair<int, int>(v_carte.Id, v_carteVoisin.Id));
                        }
                    }
                }
            }
            catch (ArgumentException ex) { p_compteurException++; }
            catch (NullReferenceException ex) { p_compteurException++; }
            return returnValue;
        }
        #endregion

        #endregion

    }
}
