using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public Image background;
    public RectTransform thumb;
    private bool isOn = true;

    private Color onColor = new Color(0f, 0.94f, 1f, 1f);
    private Color offColor = new Color(0f, 0.94f, 1f, 0.25f);

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        UpdateVisual();
    }

    void OnClick()
    {
        isOn = !isOn;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        background.color = isOn ? onColor : offColor;
        thumb.anchoredPosition = isOn ? new Vector2(-19, 0) : new Vector2(-49, 0);
    }
}