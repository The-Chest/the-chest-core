using TheChest.ConsoleApp.Containers;

var slots = Enumerable.Repeat(new Slot(), 10).ToArray();
var container = new Container(slots);

Console.Write($"Hey, this container has the size of {container.Size}");