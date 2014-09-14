using System;

namespace _01_Observable.Structural
{
    //Defines a provider for push-based notification.
    public interface IObservable<out T>
    {
        //Notifies the provider that an observer is to receive notifications.
        IDisposable Subscribe(IObserver<T> observer);
    }
}