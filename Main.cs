using Rocket.API;
using Rocket.API.Collections;
using Rocket.API.Serialisation;
using Rocket.Core;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Framework.UI.Devkit;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Tutorial
{
    public class Tutorial : RocketPlugin<TutorialConfig>
    {
        public static Tutorial Instance;

        protected override void Load()
        {
            Instance = this;

            EffectManager.onEffectButtonClicked += new EffectManager.EffectButtonClickedHandler(this.onEffectButtonClicked);

            U.Events.OnPlayerConnected += OnPlayerConnected;

        }

        // Now we need to generate hash

        protected override void Unload()
        {
            EffectManager.onEffectButtonClicked -= new EffectManager.EffectButtonClickedHandler(this.onEffectButtonClicked);
            U.Events.OnPlayerConnected -= OnPlayerConnected;
        }




        // Lets gonna do something for show the UI
        private void OnPlayerConnected(UnturnedPlayer player)
        {

            // So here we go, when the player connects to the server is going to show the UI, but wait a moment we need to do some changes

            // sorry haha 
            EffectManager.sendUIEffect(19999, 20000, true);


            // This is for enable mouse
            player.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, true);
        }





        private  void onEffectButtonClicked(Player player, string buttonName)
        {

            // We are using UnturnedPlayer, so lets gonna extrapolate this

            UnturnedPlayer extrapo = UnturnedPlayer.FromPlayer(player);

            // So here we go, just add data and generate a hash

            //               Here we put the buttonname
            if(buttonName == "ButtonName1")
            {
                // Do every function here, i recomended to use PlayerComponent for do the function per player
                extrapo.Player.GetComponent<PlayerComponent>().DoButton();
                // And this for disable mouse when player click the button
                extrapo.Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, false);
            }
        }
    }
}
