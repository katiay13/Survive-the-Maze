using UnityEngine;
using UnityEngine.UI;

// Animates a custom toggle slider UI element - moves thumb and changes color based on state
public class ToggleSlider : MonoBehaviour
{
    public RectTransform thumb;
    public Image background;
    public Color onColor;
    public Color offColor;

    private Toggle toggle;

    void Start()
    {
        // Subscribe to Unity's Toggle component value change event
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleChanged);
        OnToggleChanged(toggle.isOn); // set initial visual state
    }

    // Moves the thumb and changes background color based on toggle state
    void OnToggleChanged(bool isOn)
    {
        thumb.anchoredPosition = isOn ? new Vector2(38, 0) : new Vector2(5, 0);
        background.color = isOn ? onColor : offColor;
    }
}