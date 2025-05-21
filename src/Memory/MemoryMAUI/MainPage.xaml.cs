using System.Security.Cryptography.X509Certificates;
using MemoryLib.Models;

namespace MemoryMAUI
{
    public partial class MainPage : ContentPage
    {

        public Player player1 { get; private set; } = new Player ""player1"";
        public MainPage()
        {
           

            InitializeComponent();
        }

        void Start_game_button(System.Object Sender, EventArgs e)
        {

        }
    }

}
