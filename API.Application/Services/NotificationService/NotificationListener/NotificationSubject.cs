namespace API.NotificationListener
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the EventStatus.
    /// </summary>
    public enum EventStatus
    {
        /// <summary>
        /// Defines the GROUP_CREATED.
        /// </summary>
        GROUP_CREATED = 1,
        /// <summary>
        /// Defines the GROUP_UPDATED.
        /// </summary>
        GROUP_UPDATED = 2,
        /// <summary>
        /// Defines the GROUP_JOIN.
        /// </summary>
        GROUP_JOIN = 3,
        /// <summary>
        /// Defines the SEQUENCE_CREATED.
        /// </summary>
        SEQUENCE_CREATED = 4,
        /// <summary>
        /// Defines the SEQUENCE_EXPIRED.
        /// </summary>
        SEQUENCE_EXPIRED = 5,
        /// <summary>
        /// Defines the SEQUENCE_VALIDATION_TASK.
        /// </summary>
        SEQUENCE_VALIDATION_TASK = 6,
        GROUP_IMPORT_STUDENT=7,
        ADDED_STUDENT=8,
        ADD_CONSIGNE = 9,
        GROUP_CREATED_INTERCLASS = 10,
        GROUP_CREATED_WORK = 11,
        ADD_SEQUENCE_INTERCLASS = 12,
        UPDATE_SEQUENCE = 13,
        UPDATE_CONSIGNE=14
            
    }

    /// <summary>
    /// Defines the <see cref="NotificationSubject" />.
    /// </summary>
    public class NotificationSubject : ISubject
    {
        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        public EventStatus State { get; set; } = EventStatus.GROUP_CREATED;

        /// <summary>
        /// Defines the Data.
        /// </summary>
        public dynamic Data = null;

        public dynamic UserAuth = null;
        public dynamic SequenceEntity = null;

        /// <summary>
        /// Defines the _observers.
        /// </summary>
        private List<IObserver> _observers = new List<IObserver>();

        /// <summary>
        /// The Attach.
        /// </summary>
        /// <param name="observer">The observer<see cref="IObserver"/>.</param>
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            _observers.Add(observer);
        }

        /// <summary>
        /// The Detach.
        /// </summary>
        /// <param name="observer">The observer<see cref="IObserver"/>.</param>
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        // Trigger an update in each subscriber.
        /// <summary>
        /// The Notify.
        /// </summary>
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        /// <summary>
        /// The SendEvent.
        /// </summary>
        /// <param name="status">The status<see cref="EventStatus"/>.</param>
        /// <param name="data">The data<see cref="dynamic"/>.</param>
        public void SendEvent(EventStatus status, dynamic data, dynamic userauth, dynamic SequenceEntity=null)
        {
            State = status;
            Data = data;
            UserAuth = userauth;

            Console.WriteLine("Subject: State is: " + State);
            Notify();
        }
    }
}
