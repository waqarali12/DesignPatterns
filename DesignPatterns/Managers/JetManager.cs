using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Managers
{
    class JetManager : IVahicleManager
    {
        public string GetEngine()
        {
            return "Jet Engine";
        }

        public int GetHorsePower()
        {
            return 250;
        }

        public void GetWings()
        {
            Console.WriteLine("Wings");
        }
    }
}
