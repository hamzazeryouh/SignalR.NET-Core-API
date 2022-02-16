namespace API.NotificationListener
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IObserver" />.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="subject">The subject<see cref="ISubject"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Update(ISubject subject);
    }

    /// <summary>
    /// Defines the <see cref="ISubject" />.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// The Attach.
        /// </summary>
        /// <param name="observer">The observer<see cref="IObserver"/>.</param>
        void Attach(IObserver observer);

        /// <summary>
        /// The Detach.
        /// </summary>
        /// <param name="observer">The observer<see cref="IObserver"/>.</param>
        void Detach(IObserver observer);

        /// <summary>
        /// The Notify.
        /// </summary>
        void Notify();

        /// <summary>
        /// The SendEvent.
        /// </summary>
        /// <param name="status">The status<see cref="EventStatus"/>.</param>
        /// <param name="data">The data<see cref="dynamic"/>.</param>
        void SendEvent(EventStatus status, dynamic data, dynamic userauth, dynamic sequenceEntity);
    }
}
