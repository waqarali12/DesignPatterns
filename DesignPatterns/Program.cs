using DesignPatterns.COR;
using DesignPatterns.Factories;
using DesignPatterns.Factories.FactoryMethod;
using DesignPatterns.Managers;
using DesignPatterns.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        //Clients 
        static void Main(string[] args)
        {
            SimpleFactory();
            FactoryMethod();
            COR();
            Console.ReadKey();
        }

        public static void SimpleFactory()
        {
            VahicleModel jet = new VahicleModel(1);
            VahicleModel car = new VahicleModel(2);

            //getting hold of factory
            var factory = new VahicleManagerFactory();

            //creating and consuming product/service for jet
            IVahicleManager jetManager = factory.Create(jet.TypeCode);
            jet.Engine = jetManager.GetEngine();
            jet.HorsePower = jetManager.GetHorsePower();

            //creating and consuming product/service for car
            IVahicleManager carManager = factory.Create(car.TypeCode);
            car.Engine = carManager.GetEngine();
            car.HorsePower = carManager.GetHorsePower();

            Console.WriteLine("-----Via Simple Factory-----");
            Console.WriteLine($"This is {jet.Engine}, having {jet.HorsePower} Horse Power\nThis is {car.Engine}, having {car.HorsePower} Horse Power");
        }

        public static void FactoryMethod()
        {
            VahicleModel jet = new VahicleModel(1);
            VahicleModel car = new VahicleModel(2);

            VahicleFactoryManager factoryManager = new VahicleFactoryManager();

            BaseVahicleFactory jetFactopry = factoryManager.GetFactory(jet);
            jetFactopry.DoCommonStuff();

            BaseVahicleFactory carFactory = factoryManager.GetFactory(car);
            carFactory.DoCommonStuff();

            Console.WriteLine($"This is {jet.Engine}, having {jet.HorsePower} Horse Power\nThis is {car.Engine}, having {car.HorsePower} Horse Power");

        }

        public static void COR()
        {
            List<VahicleModel> vahicles = new List<VahicleModel>();
            vahicles.Add(new VahicleModel(0));
            vahicles.Add(new VahicleModel(1));
            vahicles.Add(new VahicleModel(2));
            
            //VahicleModel ufo = new VahicleModel(0);
            //VahicleModel jet = new VahicleModel(1);
            //VahicleModel car = new VahicleModel(2);

            VahicleHandlerBase chain = ChainFactory.CreateChain();
            vahicles.ForEach(v => chain.Handle(v));
            //chain.Handle(ufo);
            //chain.Handle(jet);
            //chain.Handle(car);
            Console.WriteLine("-----Via COR-----");
            vahicles.ForEach(v => Console.WriteLine($"This is {v.Engine}, having {v.HorsePower} Horse Power"));
                        
        }
    }
}
