using UnityEngine;
using System.Collections.Generic;

public class SubtitleController : MonoBehaviour
{
    [SerializeField] List<Subtitle> subtitles = new();

    public Subtitle GetSubtitle(string id)
    {
        Subtitle subtitle = subtitles.Find(subtitle => subtitle.id == id);

        if (subtitle == null)
        {
            throw new System.NullReferenceException("Could not find subtitle with id: " + id);
        }
        return subtitle;
    }
}
