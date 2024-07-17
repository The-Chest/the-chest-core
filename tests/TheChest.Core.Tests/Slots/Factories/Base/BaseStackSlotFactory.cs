﻿using TheChest.Core.Slots.Base;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories.Base
{
    public class BaseStackSlotFactory<T, Y> : IStackSlotFactory<Y> where T : BaseStackSlot<Y>
    {
        public IStackSlot<Y> EmptySlot()
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type, Array.Empty<Y>(), 1);
            return (IStackSlot<Y>)slot;
        }

        public IStackSlot<Y> FullSlot(Y item)
        {
            var type = typeof(T);

            var size = new Random().Next(1, 10);
            var items = new Y[size];
            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, size);
            return (IStackSlot<Y>)slot;
        }

        public IStackSlot<Y> WithItem(Y item, int amount = 1, int maxAmount = 10)
        {
            var type = typeof(T);
            var items = new Y[amount];
            Array.Fill(items, item);

            var slot = Activator.CreateInstance(type, items, maxAmount);
            return (IStackSlot<Y>)slot;
        }
    }
}