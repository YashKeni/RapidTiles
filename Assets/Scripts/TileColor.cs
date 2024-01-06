using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TileColor : MonoBehaviour
{
    [SerializeField] public float randomToDefault = 4f;
    [SerializeField] float defaultToRandom = 3f;
    public bool isDefault;
    public List<Color> TintColors;

    GameSession gameSession;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        StartCoroutine(SwitchDefaultAndRandom());
    }

    IEnumerator SwitchDefaultAndRandom()
    {
        while (gameSession.GetLives() > 0)
        {
            DefaultColor();
            yield return new WaitForSeconds(defaultToRandom);
            RandomColor();
            yield return new WaitForSeconds(randomToDefault);
        }
    }

    private void RandomColor()
    {
        isDefault = false;
        Color color = TintColors[Random.Range(0, TintColors.Count)];
        GetComponent<Renderer>().material.color = color;

        Color32 objColor = gameObject.GetComponent<Renderer>().material.color;

        if (objColor.r == 255 && objColor.g == 0 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Red";
        }
        if (objColor.r == 255 && objColor.g == 128 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Orange";
        }
        if (objColor.r == 255 && objColor.g == 255 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Yellow";
        }
        if (objColor.r == 0 && objColor.g == 255 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Green";
        }
        if (objColor.r == 0 && objColor.g == 160 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "LightBlue";
        }
        if (objColor.r == 0 && objColor.g == 0 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "DarkBlue";
        }
        if (objColor.r == 103 && objColor.g == 0 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Purple";
        }
        if (objColor.r == 199 && objColor.g == 0 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Magenta";
        }
        if (objColor.r == 245 && objColor.g == 156 && objColor.b == 234 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Pink";
        }
    }

    public void DefaultColor()
    {
        isDefault = true;
        GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.tag = "White";
    }

    void SetTriggerActive()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

}
