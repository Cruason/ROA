using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    public static FloatingTextManager Instance { get => GetInstance(); }

    private static FloatingTextManager _instance;

    private static FloatingTextManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<FloatingTextManager>();
        }
        return _instance;
    }
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText txt = GetFloatingText();
        txt.showingText.text = message;
        txt.showingText.fontSize = fontSize;
        txt.showingText.color = color;
        txt.textObject.transform.position = Camera.main.WorldToScreenPoint(position);
        txt.motion = motion;
        txt.duration = duration;

        txt.ShowText();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.textObject = Instantiate(textPrefab);
            txt.textObject.transform.SetParent(textContainer.transform);

            txt.showingText = txt.textObject.GetComponent<Text>();
            floatingTexts.Add(txt);
        }
        return txt;
    }
    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
        {
            txt.UseFloatingText();
        }
    }
}
