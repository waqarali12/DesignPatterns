using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Managers
{
    class CarManager : IVahicleManager
    {
        public string GetEngine()
        {
            return "Car Engine";
        }

        public int GetHorsePower()
        {
            return 150;
        }

        public void GetTyeres()
        {
            Console.WriteLine("Tyeres");
        }
    }
}
