using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubtitleView : MonoBehaviour
{
    [SerializeField] SubtitlePresenter presenter;

    [SerializeField] GameObject subtitlePanel;
    [SerializeField] TextUIElement subtitleTextUI;

    public void ShowSubtitle(string text)
    {
        subtitlePanel.SetActive(true);

        if (text != subtitleTextUI.text)
        {
            subtitleTextUI.SetText(text);
            LayoutRebuilder.ForceRebuildLayoutImmediate(subtitlePanel.GetComponent<RectTransform>());
        }
        subtitleTextUI.Show();
    }

    public void HideSubtitle()
    {
        subtitleTextUI.Hide();
        subtitlePanel.SetActive(false);
    }
}
