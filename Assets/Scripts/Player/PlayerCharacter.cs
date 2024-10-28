using System;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private PlayerHUD playerHUD;
    [SerializeField] private int score;
    [SerializeField] private float timeLeft;
    [SerializeField] private int scoreMultiplier;

    private void Start()
    {
        SetupCharacter();
    }

    protected override void SetupCharacter()
    {
        playerHUD.SetScoreText(score);
        playerHUD.SetTimeLeftText(timeLeft);
        playerHUD.SetScoreMultiplierText(scoreMultiplier);
    }

    public void AddScore(int amount, bool useMultiplier = true)
    {
        int multiplier = useMultiplier ? scoreMultiplier : 1;
        score += amount * multiplier;
        playerHUD.SetScoreText(score);
    }

    public void AddScoreMultiplier(int amount)
    {
        scoreMultiplier += amount;
        playerHUD.SetScoreMultiplierText(scoreMultiplier);
    }

    public void ResetScoreMultiplier()
    {
        scoreMultiplier = 0;
        playerHUD.SetScoreMultiplierText(scoreMultiplier);
    }
}
