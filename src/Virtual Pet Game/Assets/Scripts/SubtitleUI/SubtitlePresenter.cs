using UnityEngine;
using System.Collections;

public class SubtitlePresenter : MonoBehaviour, IPresenter
{
    [SerializeField] SubtitleView view;
    [SerializeField] SubtitleController controller;

    public bool isPlaying { private set; get; }

    // Use this for initialization
    void Start()
    {
        view.HideSubtitle();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySubtitle(string id)
    {
        Subtitle subtitle = controller.GetSubtitle(id);
        StartCoroutine(TimeSubtitleVisibility(subtitle));
    }

    IEnumerator TimeSubtitleVisibility(Subtitle subtitle)
    {
        isPlaying = true;
        view.ShowSubtitle(subtitle.text);

        yield return new WaitForSeconds(subtitle.duration);

        isPlaying = false;
        view.HideSubtitle();
    }




    public void onModelStateChanged()
    {
        throw new System.NotImplementedException();
    }
}
