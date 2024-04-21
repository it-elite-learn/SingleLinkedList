namespace List.Core.EventArgs;

using EventArgs = System.EventArgs;

/// <summary>
/// This class represent the <see cref="EventArgs"/> for the event OnItemAdded
/// </summary>
/// <typeparam name="T">Type of the value</typeparam>
public class ItemAddedEventArgs<T> : EventArgs
{
    /// <summary>
    /// The value added to the list
    /// </summary>
    public T Value { get; init; }
}