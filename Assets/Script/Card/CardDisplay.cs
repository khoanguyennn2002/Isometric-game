
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardSpawner;

    public Text stepText;
    public Image cardImage;
    private void Start()
    {
        this.name = stepText.text;
        cardSpawner = GameObject.Find("CardSpawner");
        this.transform.SetParent(cardSpawner.transform);
        this.transform.localScale = Vector3.one;
    }
}
