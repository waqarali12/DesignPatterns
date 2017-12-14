using DesignPatterns.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factories
{
    class VahicleManagerFactory
    {
        public IVahicleManager Create(int typeCode)
        {
            IVahicleManager returnVal= null;
            if (typeCode == 1)
            {
                returnVal = new JetManager();
            }

            else if (typeCode == 2)
            {
                returnVal = new CarManager();
            }

            return returnVal;
        }
    }
}
