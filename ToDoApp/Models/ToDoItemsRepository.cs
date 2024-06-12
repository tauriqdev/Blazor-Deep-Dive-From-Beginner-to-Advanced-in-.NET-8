namespace ToDoApp.Models
{
    public static class ToDoItemsRepository
    {
        private static List<ToDoItem> items = new List<ToDoItem>()
        {
            new() { Id = 1, Name = "Item 1"},
            new() { Id = 2, Name = "Item 2"},
            new() { Id = 3, Name = "Item 3"},
            new() { Id = 4, Name = "Item 4"}
        };

        public static void AddItem(ToDoItem item)
        {
            if (items.Count > 0)
            {
                var maxId = items.Max(x => x.Id);
                item.Id = maxId + 1;
                items.Add(item);
            }
            else
            {
                item.Id = 1;
                items.Add(item);
            }
        }

        public static List<ToDoItem> GetItems()
        {
            var sortedItems = items
                .OrderBy(i => i.IsCompleted)
                .ThenByDescending(i => i.Id)
                .ToList();

            return sortedItems;
        }

        public static ToDoItem? GetItemById(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                return new ToDoItem
                {
                    Id = item.Id,
                    Name = item.Name
                };
            }

            return null;
        }

        public static void UpdateItem(int itemId, ToDoItem item)
        {
            if (itemId != item.Id)
                return;

            var itemToUpdate = items.FirstOrDefault(i => i.Id == itemId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
            }
        }

        public static void DeleteItem(int itemId)
        {
            var item = items.FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                items.Remove(item);
            }
        }

        public static List<ToDoItem> SearchItems(string itemFilter)
        {
            return items.Where(s => s.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
