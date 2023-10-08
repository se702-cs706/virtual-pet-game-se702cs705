using System;

[Serializable]
public class ModelPlayTime : DatabaseEntry
{
    public DogModelType model { private set; get; }
    public float playTime;

    public ModelPlayTime(DateTime timestamp, string userId, DogModelType model) : base(timestamp, userId)
    {
        this.model = model;
    }

    public override string ToString()
    {
        return $"[{timestamp}]: ({model}) - Playtime: {playTime}ms";
    }
}
