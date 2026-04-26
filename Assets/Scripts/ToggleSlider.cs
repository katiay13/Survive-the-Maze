using UnityEngine;
using UnityEngine.UI;

public class ToggleSlider : MonoBehaviour
{
    public RectTransform thumb;
    public Image background;
    public Color onColor;
    public Color offColor;

    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleChanged);
        OnToggleChanged(toggle.isOn);
    }

    // Moves the thumb and changes background color based on toggle state
    void OnToggleChanged(bool isOn)
    {
        thumb.anchoredPosition = isOn ? new Vector2(38, 0) : new Vector2(5, 0);
        background.color = isOn ? onColor : offColor;
    }
}