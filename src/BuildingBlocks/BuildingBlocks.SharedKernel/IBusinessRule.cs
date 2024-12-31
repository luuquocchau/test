namespace BuildingBlocks.SharedKernel;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}