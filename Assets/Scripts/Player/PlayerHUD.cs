using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private TextMeshProUGUI scoreMultiplierText;

    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetTimeLeftText(float timeLeft)
    {
        timeLeftText.text = timeLeft.ToString("0.00");
    }

    public void SetScoreMultiplierText(int scoreMultiplier)
    {
        scoreMultiplierText.text = scoreMultiplier.ToString();
    }
}
