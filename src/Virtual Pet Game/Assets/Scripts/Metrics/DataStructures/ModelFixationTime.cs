using System;

[Serializable]
public class ModelFixationTime : DatabaseEntry
{
    DogModelType model;
    public float fixationTime;

    public ModelFixationTime(DateTime timestamp, string userId, DogModelType model): base(timestamp, userId)
    {
        this.model = model;
    }

    public override string ToString()
    {
        return $"[{timestamp}]: ({model}) - Fixation time: {fixationTime}ms";
    }
}
