using System;
using UnityEngine;

public class BodyPartCollectionGameMode : GameModeBase<BodyPartCollectionGameMode>
{
    [SerializeReference] private float timeLeftInTheGame;

    private void Start()
    {
        StartGame();
    }

    public float GetTimeLeftInGame()
    {
        return timeLeftInTheGame;
    }

    private void Update()
    {
        CountDownTimeLeftInTheGame();
    }

    private void CountDownTimeLeftInTheGame()
    {
        timeLeftInTheGame -= Time.deltaTime;
        if (timeLeftInTheGame <= 0)
        {
            EndGame();
        }
    }
}
