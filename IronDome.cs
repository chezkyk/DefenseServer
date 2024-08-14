using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenseServer
{
    internal class IronDome
    {

        public async Task<bool> handleMissile(Missile missile)
        {

            await Task.Delay(2000);

            Random random = new Random();
            bool intercepted = random.Next(2) == 1;
            return intercepted;

        }
    }
}