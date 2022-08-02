using Project01_Client.Logic;
using System.Threading;


namespace Project01_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MENU_LOGIC gameSession = new MENU_LOGIC();
            gameSession.MENU_LOGIC_MAIN();

            /*Console.WriteLine("Resize Window");
            Console.ReadLine();*/

            //GAME_LOGIC gameSession = new();
            //gameSession.GAME_LOGIC_MAIN();
        }
    }
}