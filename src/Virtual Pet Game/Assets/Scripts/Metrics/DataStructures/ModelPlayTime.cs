using System;

[Serializable]
public class ModelPlayTime
{
    public string timestamp;
    public string id;
    public DogModelType model;
    public float playTime;

    public ModelPlayTime(string timestamp, string userId, DogModelType model)
    {
        this.timestamp = timestamp;
        this.id = userId;
        this.model = model;
    }

    public override string ToString()
    {
        return $"[{timestamp}]: ({model}) - Playtime: {playTime}ms";
    }
}
