using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MoleGame : MonoBehaviour
{
    public GameObject mole;
    public Transform[] holes;
    public RectTransform moleContainer;
    public Button button;


    private float moleDuration = 5f;
    private float spawnInterval = 2f;


    private int score;
    public static int highScore;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeLimitText;
    public TextMeshProUGUI gameOverText;

    private float timeLimit = 30f;
    private bool gameIsActive;


    public DailyQuestManager questManager;
    public DailyQuest quest;
    public AchievementManager achievementManager;


    void Update()
    {
        button.interactable = !quest.isCompleted;

        scoreText.text = "Score: " + score;

        if (gameIsActive)
        {
            timeLimitText.text = Mathf.Round(timeLimit) + " sec";
            timeLimit -= Time.deltaTime;

            if (timeLimit <= 0f)
            {
                StopAllCoroutines();

                gameOverText.gameObject.SetActive(true);
                gameOverText.text = "You won " + score * 10 + " coins";
                StartCoroutine(Wait());
                gameOverText.gameObject.SetActive(false);

                if (score > highScore)
                {
                    highScore = score;
                }

                GlobalCount.currentTotal += score * 10;

                gameIsActive = false;
                score = highScore;
                timeLimit = 30f;

                questManager.UpdateQuestProgress("Mole", 1);
                achievementManager.UpdateQuestProgress("Mole", 1);
            }
            }
        else
        {
            timeLimitText.text = "0";
        }    
    }


    public void StartGame()
    {
        gameIsActive = true;
        score = 0;
        gameOverText.text = "";
        StartCoroutine(Game());
    }

    IEnumerator Game()
    {
        while (true)
        {
            int index = Random.Range(0, holes.Length);
            GameObject moleShown = Instantiate(mole, moleContainer);
            moleShown.GetComponent<RectTransform>().anchoredPosition = holes[index].GetComponent<RectTransform>().anchoredPosition;

            Destroy(moleShown, moleDuration);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
    }



    public void Hit(GameObject moleInstance)
    {
        score += 1;
        Destroy(moleInstance); 
    }

    public void endGame()
    {
        gameIsActive = false;
    }
}
