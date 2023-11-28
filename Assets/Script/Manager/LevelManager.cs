using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public GameObject grid;
    private Tilemap level;
    private Deck deck;
    public GameObject CardPrefab;
    private int currentLevel = 1;
    private void Awake()
    {
       
            currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        
        LoadLevel();
        LoadDeckData();
        if(deck != null)
        {
            SpawnCardInDeck();
        }
  
    }
    private void LoadDeckData()
    {
        deck = Resources.Load<Deck>("DeckData/Level_" + currentLevel);
    }
    private void LoadLevel()
    {
        level = Resources.Load<Tilemap>("Level/Level_" + currentLevel);
        if(level!=null)
        {
            Tilemap a = Instantiate(level);
            a.transform.SetParent(grid.transform);
        }    
    }
    private void SpawnCardInDeck()
    {
            for (int i = 0; i < deck.cards.Count; i++)
            {
                GameObject cardObject = Instantiate(CardPrefab);
                CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>();
                if (deck.cards[i].id == 0)
                {
                    cardDisplay.stepText.text = deck.cards[i].step.ToString();
                }
                else
                {
                    cardDisplay.stepText.enabled = false;
                    cardDisplay.cardImage.sprite = deck.cards[i].cardImgae;
                }
            }
    }
   public void UpdateCurrentLevel()
    {
        currentLevel++;
    
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }
    public void ResetLevel()
    {
        int maxLevel = 3;  

         currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        if (currentLevel == maxLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        levelLoader.LoadNextLevel();
    }
}
