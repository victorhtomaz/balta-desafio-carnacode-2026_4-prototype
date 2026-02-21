namespace Challenge.Abstractions;

internal interface IPrototype<T>
{
    T Clone();
    T DeepClone();
}
