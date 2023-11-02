using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private bool _playerHaveKey;
    public override void init()
    {
        base.init();
    }

    public void PlayerGotKey()
    {
        _playerHaveKey = true;

    }
    public void GemsPlayerGot(int Gems)
    {
        UiManager.Program.GemCount(Gems);
    }
    public void PlayerHealth(int Health)
    {
        UiManager.Program.HealthDamageGraphic(Health);
    }
    
}
