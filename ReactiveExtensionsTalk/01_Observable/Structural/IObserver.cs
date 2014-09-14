using System;

namespace _01_Observable.Structural
{
    //Provides a mechanism for receiving push-based notifications.
    public interface IObserver<in T>
    {
        //Provides the observer with new data.
        void OnNext(T value);

        //Notifies the observer that the provider has experienced an error condition.
        void OnError(Exception error);

        //Notifies the observer that the provider has finished sending push-based notifications.
        void OnCompleted();
    }
}