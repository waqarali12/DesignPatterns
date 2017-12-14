using DesignPatterns.Managers;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factories.FactoryMethod
{
    abstract class BaseVahicleFactory
    {
        protected VahicleModel _model;
        public IVahicleManager manager { get { return this.Create(); } } //this will hit(return) child factories implimentation
        public BaseVahicleFactory(VahicleModel model)
        {
            _model = model;
        }
        
        //factory method
        public abstract IVahicleManager Create();

        //Abstraction(commanalities)
        public void DoCommonStuff()
        {
            //var manager = this.Create();//this will hit child factories implimentation
            _model.Engine = manager.GetEngine();
            _model.HorsePower = manager.GetHorsePower();

            Console.WriteLine("-----Via Factory Method-----");
        }
    }

    //Concrete child classes

    class JetFactory : BaseVahicleFactory
    {
        JetManager jetManager;

        public JetFactory(VahicleModel model) : base(model)
        {
            jetManager = new JetManager();
        }

        public override IVahicleManager Create()
        {
            return jetManager;
        }

        // not implemented yet or unable to comsume from client
        public void JetExtraStuff()
        {
            jetManager.GetWings();
        }
    }
    
    class CarFactory : BaseVahicleFactory
    {
        CarManager carManager;

        public CarFactory(VahicleModel model) : base(model)
        {
            carManager = new CarManager();
        }

        public override IVahicleManager Create()
        {
            return new CarManager();
        }

        // not implemented yet or unable to comsume from client
        public void CarExtraStuff()
        {
            carManager.GetTyeres();
        }

    }

}
