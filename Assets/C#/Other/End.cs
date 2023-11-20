using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoSingleton<End>
{
    [SerializeField]
    private bool _playerHaveKey;
 public void PlayerGotKey()
    {
        _playerHaveKey = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_playerHaveKey == true)
        {
            if (other.tag == "Player")
            {
                GameManager.Program.GameOver();
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                GameManager.Program.GameOverHint();
            }

        }
    }
}
