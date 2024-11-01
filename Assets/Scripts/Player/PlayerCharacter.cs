using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] PlayerHUD _playerHUD;
    [SerializeField] int _score;
    [SerializeField] int _scoreMultiplier;

    void Start()
    {
        SetupCharacter();
    }

    void Update()
    {
        UpdateTimeLeftText();
    }

    void UpdateTimeLeftText()
    {
        if (BodyPartCollectionGameMode.I.GetIsGameRunning())
        {
            _playerHUD.SetTimeLeftText(BodyPartCollectionGameMode.I.GetTimeLeftInGame());
        }
    }

    protected override void SetupCharacter()
    {
        _playerHUD.SetScoreText(_score);
        _playerHUD.SetScoreMultiplierText(_scoreMultiplier);
    }

    public void AddScore(int amount, bool useMultiplier = true)
    {
        int multiplier = useMultiplier ?  Mathf.Max(_scoreMultiplier, 1) : 1;
        
        _score += amount * multiplier;
        _playerHUD.SetScoreText(_score);
    }

    public void AddScoreMultiplier(int amount)
    {
        _scoreMultiplier += amount;
        _playerHUD.SetScoreMultiplierText(_scoreMultiplier);
    }

    public void ResetScoreMultiplier()
    {
        _scoreMultiplier = 1;
        _playerHUD.SetScoreMultiplierText(_scoreMultiplier);
    }
}
