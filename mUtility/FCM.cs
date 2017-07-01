using FirebaseNet.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace mUtility
{
    /// <summary>
    /// This class is for push notifications Firebase Cloud Messaging (GCM)
    /// </summary>
    public class FCM
    {
        FCMClient client;
        Collection<string> theIds = new Collection<string>();
        //string serverKey = @"here goes the server key";

        /// <summary>
        /// Create a new FCM Object with the server key
        /// </summary>
        /// <param name="_serverKey">Server key provided by Firebase Messaging</param>
        public FCM(string _serverKey)
        {
            client = new FCMClient(_serverKey);
        }

        /// <summary>
        /// Pass in the message object and call this method in a 'var' variable. It would work asynchronously.
        /// </summary>
        /// <param name="message">FCM message object</param>
        /// <returns></returns>
        async public Task sendNotification(Message message)
        {
            try
            {
                var result = await client.SendMessageAsync(message);
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine("Notification failure.");
            }

        }


    }
}
