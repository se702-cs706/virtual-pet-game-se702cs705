using UnityEngine;
using System.Collections;

public class SubtitleView : MonoBehaviour
{
    [SerializeField] SubtitlePresenter presenter;

    [SerializeField] GameObject subtitlePanel;
    [SerializeField] TextUIElement subtitleTextUI;

    public void ShowSubtitle(string text)
    {
        subtitleTextUI.Show();
        subtitlePanel.SetActive(true);

        if (text != subtitleTextUI.text)
        {
            subtitleTextUI.SetText(text);
        }
    }

    public void HideSubtitle()
    {
        subtitleTextUI.Hide();
        subtitlePanel.SetActive(false);
    }
}
