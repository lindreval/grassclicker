using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;

    private Image image;
    public bool isFlipped = false;
    private CardManager cardManager;

    public void StartGame()
    {
        image = GetComponent<Image>();

        ShowBack();
    }

    public void ClickCard()
    {
        if (isFlipped) return;
        Flip();
        cardManager.OnCardClicked(this);
    }

    public void Flip()
    {
        isFlipped = true;
        image.sprite = frontSprite;
    }

    public void ShowBack()
    {
        isFlipped = false;
        image.sprite = backSprite;
    }

    public bool IsMatch(Card other)
    {
        return frontSprite == other.frontSprite;
    }
}
