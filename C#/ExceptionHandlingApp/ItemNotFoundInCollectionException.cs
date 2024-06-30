namespace ExceptionHandlingApp;

class ItemNotFoundInCollectionException<T> : Exception
{
    //public int[] Collection { get; }
    //public int SearchValue { get; }

    //public readonly int[] Collection;
    //public readonly int SearchValue;

    public T[] Collection { get; protected set; }
    public T SearchValue { get; protected set; }

    public ItemNotFoundInCollectionException(T[] collection, T searchValue)
    {
        this.Collection = collection;
        this.SearchValue = searchValue;
    }

    public override string Message => $"Value '{this.SearchValue}' not found in array '[{string.Join(',', this.Collection)}]'";
}