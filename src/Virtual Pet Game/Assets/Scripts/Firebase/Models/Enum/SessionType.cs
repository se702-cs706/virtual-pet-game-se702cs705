namespace Firebase.Models.Enum
{
    /**
     * Free play means unlimited time session
     * Practice would not record important data
     * Data collection sessions are the important sessions
     */
    public enum SessionType
    {
        FreePlay = 0,
        Practice = 1,
        DataCollection = 2,
    }
}