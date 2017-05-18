using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using YoLol.Classes;
using System.Xml.Linq;

namespace YoLol
{
    

    public partial class Form1 : Form
    {
        private static string[] nameList = new[] { "Doublelift", "Bjergsen", "Svenskeren", "sOAZ", "Amazing", "Caps", "Rekkles", 
            "Jesse", "Expect", "Trick", "PerkZ", "Zven", "mithy",
            "Flaxxish", "Memento", "NighT", "HeaQ", "Hustlin",
             "Odoamne", "Jankos", "Febiven", "Nuclear", "Chei",
            "Alphari", "KaKao", "PowerOfEvil", "Hans", "IgNar",
        "Satorius","Wisdom", "NaeHyun", "Tabzz", "xPeke",
        "Phaxi", "Maxlore", "Betsy", "Hjärnan","Wadid", "Wunder", "Trashy", "Sencux", "Kobbe", "Mikyx",
        "Vizicsacsi", "Xerxe", "Exileh", "Samux", "Hylissang", "Cabochard", "Djoko", "Nukeduck", "Steeelback", "Hachani" };

        private static string[] greetings = new[] { "Yo", "Sup", "Wazzup", "Hi", "yo faggot", "Eyyy lmao", "Cheers", "Hello" };
        private static string[] diss = new[] { "Gank top noob!", "ff20", "ggeasy", "Is this bronze?", "elobooster", "you suck" };
        Players players = new Players();
        
        
        



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            string fileName = Path.Combine(Application.StartupPath, "Players.xml");

            doc.Load(fileName);
            
            XmlSerializer s = new XmlSerializer(typeof(Players));

            players = (Players)s.Deserialize(new StringReader(doc.InnerXml.ToString()));
    }



        private void button1_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            int i = rnd.Next(players.Player.Length);
            PlayersPlayer chosenPlayer = players.Player[i];
            

            string text = "";
            if (dissing.Checked)
            {
                text = String.Format("{0}! {1} - {2}", greetings[rnd.Next(greetings.Length)], chosenPlayer.Name, diss[rnd.Next(diss.Length)]);
            }
            else
            {
                text = String.Format("{0}! {1}", greetings[rnd.Next(greetings.Length)], chosenPlayer.Name);
            }

            pictureBox1.ImageLocation = chosenPlayer.Name == "Bjergsen" ? Path.Combine(Application.StartupPath, "bananabjerg.jpg") : "";

            Region.Text = chosenPlayer.Region;
            Position.Text = chosenPlayer.Role;
            Team.Text = chosenPlayer.Team;


            Clipboard.SetText(text);
            textBox1.Text = String.Format(text);
        }
    }
}
