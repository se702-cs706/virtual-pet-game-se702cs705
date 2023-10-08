using System;

[Serializable]
public class ModelPlayTime : DatabaseEntry
{
    DogModelType model;
    float playTime;

    public ModelPlayTime(DateTime timestamp, string userId, DogModelType model, float playTime) : base(timestamp, userId)
    {
        this.model = model;
        this.playTime = playTime;
    }
}
