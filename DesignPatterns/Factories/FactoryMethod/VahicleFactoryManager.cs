using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factories.FactoryMethod
{
    class VahicleFactoryManager
    {
        public BaseVahicleFactory GetFactory(VahicleModel model)
        {
            BaseVahicleFactory factory = null;

            if (model.TypeCode==1)
            {
                factory = new JetFactory(model);
            }

            else if (model.TypeCode==2)
            {
                factory = new CarFactory(model);
            }

            return factory;
        }
    }
}
