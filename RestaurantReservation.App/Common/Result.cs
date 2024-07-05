namespace RestaurantReservation.App.Common;

public record Result
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }

    protected Result(
        bool IsSuccess,
        string ErrorMessage)
    {
        this.IsSuccess = IsSuccess;
        this.ErrorMessage = ErrorMessage;
    }

    public static Result Success() => new(true, string.Empty);
    public static Result Failure(string errorMessage) => new(false, errorMessage);
}

public record Result<T> : Result
{
    public T? Data { get; }

    private Result(
        bool IsSuccess,
        T? Data,
        string ErrorMessage)
        : base(IsSuccess, ErrorMessage)
    {
        this.Data = Data;
    }

    public static Result<T> Success(T data) => new(true, data, string.Empty);
    public new static Result<T> Failure(string errorMessage) => new(false, default, errorMessage);

    /// <summary>
    /// Gets the data if the result is successful, otherwise throws an InvalidOperationException.
    /// </summary>
    /// <returns>The data of the result.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the result is not successful.</exception>
    public T GetDataOrThrow()
    {
        if (!IsSuccess)
        {
            throw new InvalidOperationException("The result was not successful: " + ErrorMessage);
        }

        return Data!;
    }
}