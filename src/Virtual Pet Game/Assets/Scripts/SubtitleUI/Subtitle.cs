using System;
public class Subtitle
{
    public string id { private set; get; }
    public string text { private set; get; }
    public float duration { private set; get; }

    public Subtitle(string id, string text, float duration)
    {
        this.id = id;
        this.text = text;
        this.duration = duration;
    }
}
