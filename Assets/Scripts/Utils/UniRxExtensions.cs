using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class UniRxExtensions
{
    public static IDisposable Subscribe<T1, T2>(this IObservable<ValueTuple<T1, T2>> source, Action<T1, T2> onNext)
    {
        return ObservableExtensions.Subscribe(source, t => onNext(t.Item1,t.Item2));
    }
}
