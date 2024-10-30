using UnityEngine;

public class GameModeBase<T> : GameMode<T> where T : MonoBehaviour
{
    public override bool GetIsGamePaused()
    {
        return isGamePaused;
    }

    public override void SetIsGamePaused(bool newIsGamePaused)
    {
        isGamePaused = newIsGamePaused;
    }

    public override bool GetIsGameRunning()
    {
        return isGameRunning;
    }

    public override void SetIsGameRunning(bool newHasGameStarted)
    {
        isGameRunning = newHasGameStarted;
    }
    public override void StartGame()
    {
        SpawnPlayer();
        SetIsGameRunning(true);
    }

    public override void EndGame()
    {
        SetIsGameRunning(false);
    }

    public override void PauseGame()
    {
        Time.timeScale = 0;
        SetIsGamePaused(true);
    }

    public override void ResumeGame()
    {
        Time.timeScale = 1;
        SetIsGamePaused(false);
    }

    protected override void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab,playerSpawnPoint.position,playerSpawnPoint.rotation);
        spawnedPlayers.Add(player.GetComponent<PlayerCharacter>());
    }
}
