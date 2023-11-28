using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Test", menuName = "Test")]
public class CardData : ScriptableObject
{
    public string nameCard;
    public Sprite cardImage;
    public int step;
    public int cardType;
}
