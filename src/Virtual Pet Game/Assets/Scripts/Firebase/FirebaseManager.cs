using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using UnityEngine;

namespace Firebase
{
    public class FirebaseManager : MonoBehaviour
    {

        private FirestoreDb _firestoreDb;

        // initialize Firebase
        private void Awake()
        {
            string firebaseCredentialString = File.ReadAllText("./Assets/Scripts/Firebase/virtualpetgame-5727e-firebase-adminsdk-3v83p-135d194dbf.json");
            _firestoreDb = new FirestoreDbBuilder
            {
                ProjectId = "c770-a18ac",
                JsonCredentials = firebaseCredentialString // <-- service account json file
            }.Build();
            if (_firestoreDb != null)
            {
                Debug.LogAssertion("Firestore Instance Created!");
            }
            else
            {
                Debug.LogError("No Firebase Instance");
            }
        }
    
        public async Task AddOrUpdate<T>(T entity, CancellationToken ct) // where T : IFirebaseEntity
        {
            // var document = _firestoreDb.Collection(typeof(T).Name).Document(entity.Id);
            // await document.SetAsync(entity, cancellationToken: ct);
        }

        public async Task<T> Get<T>(string id, CancellationToken ct)// where T : IFirebaseEntity
        {
            var document = _firestoreDb.Collection(typeof(T).Name).Document(id);
            var snapshot = await document.GetSnapshotAsync(ct);
            return snapshot.ConvertTo<T>();
        }

        public async Task<IReadOnlyCollection<T>> GetAll<T>(CancellationToken ct)// where T : IFirebaseEntity
        {
            var collection = _firestoreDb.Collection(typeof(T).Name);
            var snapshot = await collection.GetSnapshotAsync(ct);
            return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
        }

        public async Task<IReadOnlyCollection<T>> WhereEqualTo<T>(string fieldPath, object value, CancellationToken ct)// where T : IFirebaseEntity
        {
            return await GetList<T>(_firestoreDb.Collection(typeof(T).Name).WhereEqualTo(fieldPath, value), ct);
        }

        // just add here any method you need here WhereGreaterThan, WhereIn etc ...

        private static async Task<IReadOnlyCollection<T>> GetList<T>(Query query, CancellationToken ct)// where T : IFirebaseEntity
        {
            var snapshot = await query.GetSnapshotAsync(ct);
            return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
        }

    }
}
