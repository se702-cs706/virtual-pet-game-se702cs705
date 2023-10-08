using System;

[Serializable]
public class User
{
    public string timestamp;
    public string id;
    public User()
    {
        this.timestamp = DateTime.Now.ToString();
        this.id = Guid.NewGuid().ToString();
    }

    public override string ToString()
    {
        return $"[{timestamp}]: id {id}";
    }
}
