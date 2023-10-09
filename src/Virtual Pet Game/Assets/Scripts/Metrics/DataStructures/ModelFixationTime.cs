using System;

[Serializable]
public class ModelFixationTime
{
    public string timestamp;
    public string id;
    public DogModelType model;
    public float fixationTime;

    public ModelFixationTime(string timestamp, string userId, DogModelType model)
    {
        this.id = userId;
        this.timestamp = timestamp;
        this.model = model;
    }

    public override string ToString()
    {
        return $"[{timestamp}]: ({model}) - Fixation time: {fixationTime}ms";
    }
}
