﻿namespace BuildingBlocks.SharedKernel;

public abstract record TypedIdValueBase
{
    public Guid Value { get; }

    protected TypedIdValueBase(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidOperationException("Id value cannot be empty!");
        }

        Value = value;
    }
}