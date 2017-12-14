using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.COR
{
    class ChainFactory
    {
        /// <summary>
        /// Creates the chain.
        /// </summary>
        /// <returns></returns>
        public static VahicleHandlerBase CreateChain()
        {
            UFOHandler h0 = new UFOHandler(); //first handler
            JetHandler h1 = new JetHandler(); //second handler
            CarHandler h2 = new CarHandler(); //third handler
            //and so on..

            h0.SetSuccessor(h1);
            h1.SetSuccessor(h2); //link togethr
            //and so on..

            return h0; //return first "link" in chain
        }
    }
}
