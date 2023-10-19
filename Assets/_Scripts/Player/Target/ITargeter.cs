﻿
using UnityEngine;

public interface ITargeter<T> where T : PlayerEntity
{
    public void ExecuteTargeter<TTargetee>(TTargetee targetee) where TTargetee : PlayerEntity;

    public virtual T GetTarget()
    {
        return this as T;
    }
}