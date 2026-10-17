
public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> items = new();

    public void Add(T item)
    {
        if (items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException(
                $"An item with ID {item.Id} already exists.");
        }

        items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        items.TryGetValue(id, out T? item);
        return item;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return items.Values.ToList().AsReadOnly();
    }

    public bool Remove(int id)
    {
        return items.Remove(id);
    }
}
