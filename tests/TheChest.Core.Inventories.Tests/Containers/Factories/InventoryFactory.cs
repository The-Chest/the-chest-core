using TheChest.Core.Inventories.Containers;
using TheChest.Core.Inventories.Containers.Interfaces;
using TheChest.Core.Inventories.Slots.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Containers.Factories;

namespace TheChest.Core.Inventories.Tests.Containers.Factories
{
    public class InventoryFactory<T, Y> : ContainerFactory<T, Y>, IInventoryFactory<Y>
        where T : Inventory<Y>
    {
        public InventoryFactory(ISlotFactory<Y> slotFactory) : base(slotFactory) { }

        private static Type GetInventoryType()
        {
            var inventoryType = typeof(T);
            if (!typeof(IInventory<Y>).IsAssignableFrom(inventoryType))
            {
                throw new ArgumentException($"Type '{inventoryType.FullName}' does not implement IInventory<{typeof(Y).Name}>.");
            }

            return inventoryType;
        }

        private static Type GetSlotTypeFromConstructor()
        {
            var inventoryType = GetInventoryType();

            var constructor = inventoryType.GetConstructors()
                    .FirstOrDefault(ctor =>
                    {
                        var parameters = ctor.GetParameters();
                        return
                            parameters.Length == 1 &&
                            parameters[0].ParameterType.IsArray &&
                            typeof(IInventorySlot<Y>).IsAssignableFrom(parameters[0].ParameterType.GetElementType());
                    })
                    ?? throw new ArgumentException($"Inventory type '{inventoryType.FullName}' does not have a suitable constructor.");

            var slotParameter = constructor.GetParameters().FirstOrDefault(x => x.Name == "slots")
                ?? throw new ArgumentException($"Inventory type '{inventoryType.FullName}' does not have a constructor with IInventorySlot<{typeof(Y).Name}>[].");

            var slotType = slotParameter.ParameterType.GetElementType();
            if (!typeof(IInventorySlot<Y>).IsAssignableFrom(slotType))
            {
                throw new ArgumentException($"Type '{slotType!.FullName}' does not implement IInventorySlot<{typeof(Y).Name}>.");
            }

            return slotType;
        }

        public override IInventory<Y> EmptyContainer(int size = 20)
        {
            var containerType = GetInventoryType();
            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.EmptySlot(), i);
            }

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (IInventory<Y>)container!;
        }

        public override IInventory<Y> FullContainer(int size, Y item)
        {
            var containerType = GetInventoryType();
            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.FullSlot(item), i);
            }

            var container = Activator.CreateInstance(containerType, slots);

            return (IInventory<Y>)container!;
        }

        public override IInventory<Y> ShuffledItemContainer(int size, Y item)
        {
            if (item is null)
            {
                throw new ArgumentException("Item cannot be null");
            }

            var containerType = GetInventoryType();

            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            var randomIndex = new Random().Next(0, size - 1);
            for (int i = 0; i < size; i++)
            {
                ISlot<Y> slot;
                if (i == randomIndex)
                {
                    slot = slotFactory.FullSlot(item);
                }
                else
                {
                    slot = slotFactory.EmptySlot();
                }

                slots.SetValue(slot, i);
            }

            var container = Activator.CreateInstance(containerType, slots);

            return (IInventory<Y>)container!;
        }

        public override IInventory<Y> ShuffledItemsContainer(int size, params Y[] items)
        {
            if (items.Length > size)
            {
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");
            }

            var containerType = GetInventoryType();

            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                ISlot<Y> slot;
                if (i < items.Length)
                {
                    slot = slotFactory.FullSlot(items[i]);
                }
                else
                {
                    slot = slotFactory.EmptySlot();
                }

                slots.SetValue(slot, i);
            }
            ShuffleItems(slots);

            var container = Activator.CreateInstance(containerType, slots);

            return (IInventory<Y>)container!;
        }
    }
}
