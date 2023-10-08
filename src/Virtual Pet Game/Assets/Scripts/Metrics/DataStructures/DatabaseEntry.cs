using System;

[Serializable]
public abstract class DatabaseEntry
{
    public DateTime timestamp { private set; get; }
    public string id { private set; get; }

    public DatabaseEntry(DateTime timestamp, string id)
    {
        this.timestamp = timestamp;
        this.id = id;
    }
}
