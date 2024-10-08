﻿using TheChest.ConsoleApp.Items;
using TheChest.Core.Slots;

namespace TheChest.ConsoleApp.Containers.Stack.Lazy
{
    public class LazyStackSlot : LazyStackSlot<Item>
    {
        public LazyStackSlot(Item currentItem, int amount = 1, int maxStackAmount = 1) : base(currentItem, amount, maxStackAmount)
        {
        }
    }
}
