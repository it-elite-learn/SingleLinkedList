namespace List.Core;

/// <summary>
/// Encapsulates a value of <see cref="SingleLinkList"/>
/// </summary>
/// <typeparam name="T"></typeparam>
internal class Node<T>
    where T : notnull
{
    /// <summary>
    /// Creates a new instance of <see cref="Node{T}"/>
    /// </summary>
    /// <param name="value">Value of the node</param>
    public Node(T value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Node{T}"/>
    /// </summary>
    /// <param name="value">Value of the node</param>
    /// <param name="next">The next node</param>
    public Node(T value, Node<T> next)
    {
        Value = value;
        Next = next;
    }

    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    internal Node<T> Next { get; set; }

    /// <summary>
    /// Gets or initializes the Value of the node
    /// </summary>
    public T Value { get; init; }
}
