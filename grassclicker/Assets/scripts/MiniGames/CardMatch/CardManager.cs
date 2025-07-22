using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Button button;
    public Sprite[] cardFaces;
    public Sprite cardBack;
    public Transform cardParent;
    public GameObject noMoreLivesScreen;

    private List<Sprite> deck = new List<Sprite>();
    private List<Card> activeCards = new List<Card>();

    private List<Card> flippedCards = new List<Card>();

    private int lives;
    private bool gameIsActive;

    public DailyQuestManager questManager;
    public DailyQuest quest;
    public AchievementManager achievementManager;

    void Update()
    {
        button.interactable = !quest.isCompleted && !gameIsActive;

        if (!quest.isCompleted)
        {
            noMoreLivesScreen.SetActive(false);
        }
        else
        {
            noMoreLivesScreen.SetActive(true);
        }
    }

    public void StartGame()
    {
        deck.Clear();
        lives = 3;
        gameIsActive = true;

        foreach (var face in cardFaces)
        {
            deck.Add(face);
            deck.Add(face);
        }

        for (int i = 0; i < deck.Count; i++)
        {
            Sprite temp = deck[i];
            int rand = Random.Range(i, deck.Count);
            deck[i] = deck[rand];
            deck[rand] = temp;
        }

        foreach (var face in deck)
        {
            GameObject cardObj = Instantiate(cardPrefab, cardParent);
            Card card = cardObj.GetComponent<Card>();
            card.frontSprite = face;
            card.backSprite = cardBack;

            activeCards.Add(card);
        }
    }

    public void OnCardClicked(Card card)
    {
        if (flippedCards.Contains(card) || flippedCards.Count >= 2)
        {
            return;
        }

        flippedCards.Add(card);

        if (flippedCards.Count == 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (!flippedCards[0].IsMatch(flippedCards[1]))
        {
            flippedCards[0].ShowBack();
            flippedCards[1].ShowBack();
            lives -= 1;
        }
        else
        {
            questManager.UpdateQuestProgress("Card", 1);
            achievementManager.UpdateQuestProgress("Card", 1);
        }

        flippedCards.Clear();
        GameStatus();
    }

    private void GameStatus()
    {
        bool allFlipped = true;
        foreach (var card in activeCards)
        {
            if (!card.isFlipped)
            {
                allFlipped = false;
                break;
            }
        }
        if (allFlipped || lives <= 0)
        {
            gameIsActive = false;
            questManager.UpdateQuestProgress("CardGame", 1);
        }
    }
}
