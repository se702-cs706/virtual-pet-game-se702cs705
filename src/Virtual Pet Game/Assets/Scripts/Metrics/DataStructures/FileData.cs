using System.Collections.Generic;

[System.Serializable]
public class FileData
{
    public User currentUser;
    public List<InteractionEvent> interactionEvents;
    public List<ModelPlayTime> playTimes;
    public List<ModelFixationTime> fixationTimes;

    public FileData(User currentUser, List<InteractionEvent> interactionEvents, List<ModelPlayTime> playTimes, List<ModelFixationTime> fixationTimes)
    {
        this.currentUser = currentUser;
        this.interactionEvents = interactionEvents;
        this.playTimes = playTimes;
        this.fixationTimes = fixationTimes;
    }
}