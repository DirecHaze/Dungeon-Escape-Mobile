using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoSingleton<GameManager>
{
 

    private Player _player;
    [SerializeField]
    private GameObject _endScreen, _deathScreen;
    public override void init()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start()
    {
        init();
    }
    public void GemsPlayerGot(int Gems)
    {
        UiManager.Program.GemCount(Gems);
    }
    public void PlayerHealth(int Health)
    {
        UiManager.Program.HealthDamageGraphic(Health);
    }
    public void AdsReward(int Reward)
    {
        _player._diamondHave += Reward;
    }

    public void PlayerGotKey()
    {
        End.Program.PlayerGotKey();

    }
    public void PlayerIsDead()
    {
        _deathScreen.SetActive(true);
        UiManager.Program.HealthRemove();
    }

    public void GameOverHint()
    {
        UiManager.Program.GameOverHint();
    }
    public void GameOver()
    {
        _endScreen.SetActive(true);
        UiManager.Program.GameOver();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }

}
