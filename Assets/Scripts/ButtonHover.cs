using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Adds hover highlight effect to UI buttons
public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image img;

    void Start() => img = GetComponent<Image>();

    // Highlights the button background when the cursor hovers over it
    public void OnPointerEnter(PointerEventData e)
        => img.color = new Color(0f, 0.94f, 1f, 0.09f);  // cyan tint on hover

    // Restores the default background color when the cursor leaves
    public void OnPointerExit(PointerEventData e)
        => img.color = new Color(0.03f, 0.06f, 0.1f, 1f); // dark navy default
}