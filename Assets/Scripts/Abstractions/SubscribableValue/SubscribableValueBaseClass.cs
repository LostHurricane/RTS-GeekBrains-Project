using System;
using UnityEngine;

public abstract class SubscribableValueBaseClass <T> : ScriptableObject,  IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
    {
        private readonly SubscribableValueBaseClass<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;

        public NewValueNotifier(SubscribableValueBaseClass<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += OnNewValue;
        }

        private void OnNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= OnNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
        public bool IsCompleted => _isCompleted;
        public TAwaited GetResult() => _result;
    }


    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }

}
