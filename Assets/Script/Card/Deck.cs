using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PairCard 
{
    public int id;
    public int step;
    public Sprite cardImgae;
}

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]
public class Deck : ScriptableObject
{
    public List<PairCard> cards;
}
