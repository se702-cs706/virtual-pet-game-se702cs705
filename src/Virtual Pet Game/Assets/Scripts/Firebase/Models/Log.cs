using System;
using Firebase.Models.Enum;
using Google.Cloud.Firestore;

namespace Firebase.Models
{
    [FirestoreData]
    public class Log
    {
        /**
         * The name or id of the document in firestore.
         */
        [FirestoreDocumentId] 
        public string Id { get; set; }
        
        /**
         * The id of the session for this log.
         */
        [FirestoreProperty]
        public string SessionId { get; set; }

        /**
         * The type of session. Refer to Session Type enum declaration for details.
         */
        [FirestoreProperty]
        public SessionType SessionType { get; set; }

        /**
         * Time created for the log. Logs should not be updated or modified
         */
        [FirestoreDocumentCreateTimestamp] 
        public DateTimeOffset Time { get; set; }
        
        //TODO expand the document model
    }
}