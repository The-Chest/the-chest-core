﻿using TheChest.Core.Containers.Base;

namespace TheChest.ConsoleApp.Containers
{
    public class Container : BaseContainer<Item>
    {
        public Container(Slot[] slots) : base(slots) { }
    }
}