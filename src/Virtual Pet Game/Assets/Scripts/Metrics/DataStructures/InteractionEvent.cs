using System;

[Serializable]
public class InteractionEvent
{
    public string timestamp;
    public string id;
    public string interactionName;

    public InteractionEvent(string timestamp, string userId, string interactionName)
    {
        this.timestamp = timestamp;
        this.id = userId;
        this.interactionName = interactionName;
    }

    public override string ToString()
    {
        return $"[{timestamp}]: {interactionName}";
    }
}
