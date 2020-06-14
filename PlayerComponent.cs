using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class PlayerComponent : UnturnedPlayerComponent
    {
        // We do this per player who click that button :-)
        public void DoButton()
        {
            Player.Kick("Test Tutorial");
        }

    }
}
