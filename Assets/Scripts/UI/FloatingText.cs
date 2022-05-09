using UnityEngine;
using UnityEngine.UI;
public class FloatingText
{
    public GameObject textObject;
    public bool active;
    public Text showingText;
    public Vector3 motion;
    public float duration;
    private float lastShown;

    public void ShowText()
    {
        active = true;
        lastShown = Time.time;
        textObject.SetActive(active);
    }

    public void HideText()
    {
        active = false;
        textObject.SetActive(active);
    }

    public void UseFloatingText()
    {
        if (!active)
        {
            return;
        }
        if (Time.time - lastShown > duration)
        {
            HideText();
        }

        textObject.transform.position += motion * Time.deltaTime;
    }
}
