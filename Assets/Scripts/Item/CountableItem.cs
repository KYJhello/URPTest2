using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountableItem : Item
{
    public CountableItemData CountableData {  get; protected set; }
    public int Amount { get; protected set; }
    public int MaxAmount => CountableData.MaxAmount;
    public bool IsMax => Amount >= CountableData.MaxAmount;
    public bool IsEmpty => Amount <= 0;

    protected CountableItem(CountableItemData data, int amount = 1) : base(data)
    {
        CountableData = data;
        SetAmount(amount);
    }
    public void SetAmount(int amount)
    {
        Amount = Mathf.Clamp(amount, 0, MaxAmount);
    }
    public int AddAmount(int amount)
    {
        int nextAmount = Amount + amount;
        SetAmount(nextAmount);

        return (nextAmount > MaxAmount) ? (nextAmount - MaxAmount) : 0;
    }
    protected abstract CountableItem Clone(int amount);
}
