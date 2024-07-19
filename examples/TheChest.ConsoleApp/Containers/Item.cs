namespace TheChest.ConsoleApp.Containers
{
    public class Item
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }

        public Item(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public Item()
        {
            this.Id = "";
            this.Name = "";
            this.Description = "";
        }
    }
}