﻿using System.Collections.Generic;
using System.Linq;

namespace OpenMaple.Server.Login
{
    class WorldManager
    {
        private List<World> worlds;

        public WorldManager()
        {
            this.worlds = new List<World>();
        }

        public IWorld GetWorldById(int worldId)
        {
            return this.worlds.First(w => w.Id == worldId);
        }
    }
}