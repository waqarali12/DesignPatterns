using DesignPatterns.Managers;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.COR
{
    abstract class VahicleHandlerBase
    {

        protected VahicleHandlerBase m_Successor;

        public void SetSuccessor(VahicleHandlerBase successor)
        {
            m_Successor = successor;
        }

        public void Handle(VahicleModel model)
        {
            if (CanHandle(model)) //can this impl. handle?
            {
                HandleCore(model);
                return; //we are done.
            }
            if (m_Successor != null)
                m_Successor.Handle(model); //attempt with next in line...
            else
                throw new NotSupportedException("unknown vahicle"); //we can not handle!
        }

        protected abstract bool CanHandle(VahicleModel model);
        protected abstract void HandleCore(VahicleModel model);

    }

    //------------------------------------------------
    class UFOHandler : VahicleHandlerBase
    {
        protected override bool CanHandle(VahicleModel model)
        {
            return model.TypeCode == 0;
        }

        protected override void HandleCore(VahicleModel model)
        {
            model.Engine = "UFO Engine";
            model.HorsePower = 3000;
        }
    }

    //------------------------------------------------
    class JetHandler : VahicleHandlerBase
    {
        protected override bool CanHandle(VahicleModel model)
        {
            return model.TypeCode == 1;
        }

        protected override void HandleCore(VahicleModel model)
        {
            IVahicleManager manager = new JetManager();// (manager) for the sake of example otherwire this pattern requires core funtionality implementation here as UFOHandler 
            model.Engine = manager.GetEngine();
            model.HorsePower = manager.GetHorsePower();
            
        }
    }

    //------------------------------------------------
    class CarHandler : VahicleHandlerBase
    {
        protected override bool CanHandle(VahicleModel model)
        {
            return model.TypeCode == 2;
        }

        protected override void HandleCore(VahicleModel model)
        {
            IVahicleManager manager = new CarManager();// (manager)for the sake of example otherwire this pattern requires core funtionality implementation here as UFOHandler
            model.Engine = manager.GetEngine();
            model.HorsePower = manager.GetHorsePower();
        }
    }

}
