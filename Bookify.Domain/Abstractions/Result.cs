
using Bookify.Domain.Abstractions;
using System.Diagnostics.CodeAnalysis;

public class Result
{
    protected internal Result(bool isSuceess, Error error)
    {
        if (isSuceess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuceess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuceess = isSuceess;
        Error = error;

    }

    public bool IsSuceess { get; }
    public Error Error { get; }
    public bool IsFailue => !IsSuceess;


    public static Result Sucess() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

public class Result<Tvalue> : Result
{
    private readonly Tvalue _value;
    public Result(Tvalue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public Tvalue value => IsSuceess
        ? _value! : throw new InvalidOperationException("the value of a failur result can not be accessed");

    //   public static implicit operator Result<Tvalue>(Tvalue? tvalue) => Create(tvalue);
}
