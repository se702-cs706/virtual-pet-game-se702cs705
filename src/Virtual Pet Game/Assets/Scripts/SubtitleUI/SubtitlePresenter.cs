using UnityEngine;
using System.Collections;

public class SubtitlePresenter : MonoBehaviour, IPresenter
{
    [SerializeField] SubtitleView view;
    [SerializeField] SubtitleController controller;

    public bool hasText { get; private set; }
    public string currentText { get; private set; }

    // Use this for initialization
    void Start()
    {
        hasText = false;
        currentText = "";
        view.HideSubtitle();
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
        view.ShowSubtitle(subtitle.text);

        yield return new WaitForSeconds(subtitle.duration);

        view.HideSubtitle();
    }




    public void onModelStateChanged()
    {
        throw new System.NotImplementedException();
    }
}
