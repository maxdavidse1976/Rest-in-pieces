using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : Singleton<GameMode>
{
    [SerializeField] protected GameObject playerPrefab;
    [SerializeField] protected List<PlayerCharacter> spawnedPlayers;
    [SerializeField] protected Transform playerSpawnPoint;
    protected bool isGameRunning;
    protected bool isGamePaused;

    public abstract bool GetIsGamePaused();
    public abstract void SetIsGamePaused(bool newIsGamePaused);
    public abstract bool GetIsGameRunning();
    public abstract void SetIsGameRunning(bool newHasGameStarted);
    public abstract void StartGame();
    public abstract void EndGame();

    public abstract void PauseGame();
    public abstract void ResumeGame();
    protected abstract void SpawnPlayer();

}
