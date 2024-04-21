using System.Collections;
using List.Core.Enumerable;
using List.Core.EventArgs;

namespace List.Core;


/// <summary>
/// This class represents a singly LinkedList
/// </summary>
/// <typeparam name="T">Type of the values</typeparam>
public class SingleLinkedList<T> : IEnumerable<T>
{
    /// <summary>
    /// Event for value added
    /// </summary>
    public event Action<object, ItemAddedEventArgs<T>>? OnItemAdded;

    /// <summary>
    /// Creates an empty instance of <see cref="SingleLinkedList{T}"/>
    /// </summary>
    public SingleLinkedList()
    {
    }

    /// <summary>
    /// Creates an instance of <see cref="SingleLinkedList{T}"/> with the specified values
    /// </summary>
    /// <param name="values">The values to add</param>
    public SingleLinkedList(IEnumerable<T> values)
    {
        foreach (var value in values)
        {
            Add(value);
        }
    }

    /// <summary>
    /// Allows accessing the element of the list by <paramref name="index"/>
    /// </summary>
    /// <param name="index">Index of the elemnt</param>
    /// <returns></returns>
    public T this[int index]
    {
        get => GetValueAt(index);
    }

    /// <summary>
    /// Getter and setter for the head.
    /// </summary>
    internal Node<T>? Head { get; set; }

    /// <summary>
    /// The length of the list
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// Adds a value to the list
    /// </summary>
    /// <param name="value">The value to add</param>
    public void Add(T value)
    {
        Length++;

        if (Head is null)
        {
            Head = new Node<T>(value);
            return;
        }

        var node = new Node<T>(value) { Value = value, Next = Head };
        Head = node;
        FireOnItemAdded(value);
    }

    /// <summary>
    /// Determines the value at the given index
    /// </summary>
    /// <param name="index">Index of the element</param>
    /// <returns>The value at the index</returns>
    /// <exception cref="IndexOutOfRangeException">Is thrown if the index is out of range (upper and lower)</exception>
    private T GetValueAt(int index)
    {
        if (index < 0 || index >= Length)
            throw new IndexOutOfRangeException();

        if (Head is null)
            throw new InvalidOperationException("Can not access empty List");

        var node = Head;
        while (index > 0)
        {
            node = node.Next;
            index--;
        }

        return node.Value;
    }

    /// <summary>
    /// Fire the event <remarks>OnItemAdded</remarks>
    /// </summary>
    /// <param name="value">The value added to the list</param>
    protected virtual void FireOnItemAdded(T value)
    {
        OnItemAdded?.Invoke(this, new ItemAddedEventArgs<T>() { Value = value });
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return new SingleLinkedListEnumerator<T>(this);
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new SingleLinkedListEnumerator<T>(this);
    }
}