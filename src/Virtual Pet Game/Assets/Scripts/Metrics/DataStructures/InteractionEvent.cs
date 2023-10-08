using System;

[Serializable]
public class InteractionEvent : DatabaseEntry
{
    string interactionName;

    public InteractionEvent(DateTime timestamp, string userId, string interactionName) : base(timestamp, userId)
    {
        this.interactionName = interactionName;
    }

    public override string ToString()
    {
        return $"[{timestamp}]: {interactionName}";
    }
}
