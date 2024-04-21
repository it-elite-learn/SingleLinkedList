namespace List.Core.Enumerable;

/// <summary>
/// Supports simple iteration over the class <see cref="List.Core.SingleLinkedList"/>
/// </summary>
/// <typeparam name="T">Type of the values in the list</typeparam>
internal class SingleLinkedListEnumerator<T> : IEnumerator<T>
{
    /// <summary>
    /// List to iterate
    /// </summary>
    private readonly SingleLinkedList<T> _list;

    /// <summary>
    /// Current node
    /// </summary>
    private Node<T>? _current;

    /// <summary>
    /// Whether we reached the end of the list
    /// </summary>
    private bool _completed;

    /// <summary>
    /// Creates a new instance of <see cref="SingleLinkedListEnumerator{T}"/>
    /// </summary>
    /// <param name="singleLinkedList">The list to iterator</param>
    /// <exception cref="ArgumentNullException">Gets thrown if the <param name="singleLinkedList"></param> is null</exception>
    public SingleLinkedListEnumerator(SingleLinkedList<T> singleLinkedList)
    {
        _list = singleLinkedList ?? throw new ArgumentNullException(nameof(singleLinkedList));
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        if (_current is null && !_completed)
        {
            _current = _list.Head;
            return true;
        }

        _current = _current?.Next;
        _completed = _current is null;

        return !_completed;
    }

    /// <inheritdoc />
    public void Reset()
    {
        _current = null;
        _completed = false;
    }

    /// <inheritdoc/>
    T IEnumerator<T>.Current => _current.Value;

    /// <inheritdoc />
    public object Current => _current.Value;

    /// <inheritdoc />
    void IDisposable.Dispose()
    {
    }
}