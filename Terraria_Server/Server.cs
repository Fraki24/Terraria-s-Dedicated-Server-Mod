﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using Terraria_Server.Plugin;

namespace Terraria_Server
{
    public class Server : Main
    {
        private PluginManager pluginManager = null;
        
        private World world = null;

        public Server() { }

        public Server(int PlayerCap, World World)
        {
            Main.maxNetPlayers = PlayerCap;
            world = World;
            world.setServer(this);
            pluginManager = new PluginManager(Statics.getPluginPath, this);
        }

        public Player GetPlayerByName(string name)
        {
            Player player = null;
            int num = 0;
            Player[] player2 = Main.player;
            Player result;
            for (int i = 0; i < player2.Length; i++)
            {
                Player player3 = player2[i];
                if (player3.name.ToLower() == name.ToLower())
                {
                    result = player3;
                    return result;
                }
                if (player3.name.CompareTo(name) > num && player3.name.IndexOf(name) > -1)
                {
                    num = player3.name.CompareTo(name);
                    player = player3;
                }
            }
            result = player;
            return result;
        }

        public PluginManager getPluginManager()
        {
            return pluginManager;
        }
        public World getWorld()
        {
            return world;
        }

        public void setOpPassword(String Password) {
            NetPlay.password = Password;
        }

        public void StopServer()
        {
            NetPlay.StopServer();
        }

        public void StartServer()
        {
            NetPlay.StartServer();
        }

    }
}