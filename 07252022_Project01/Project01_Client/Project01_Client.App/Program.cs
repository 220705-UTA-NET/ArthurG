using Project01_Client.Logic;
using System.Threading;


namespace Project01_Client.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MENU_LOGIC gameSession = new MENU_LOGIC();
            await gameSession.MENU_LOGIC_MAIN();
        }
    }
}