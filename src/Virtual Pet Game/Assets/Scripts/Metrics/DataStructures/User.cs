using System;

[Serializable]
public class User : DatabaseEntry
{
    public User() : base(DateTime.Now, Guid.NewGuid().ToString())
    {
    }

    public override string ToString()
    {
        return $"[{timestamp}]: id {id}";
    }
}
