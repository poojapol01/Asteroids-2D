using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    private int _lives = 3;
    private float respawnTime = 3.0f;

    public void PlayerDied()
    {
        this._lives--;

        if(_lives <= 0) {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }
    private void GameOver()
    {
        //TODO
        Debug.Log("Game Over");
    }
}
