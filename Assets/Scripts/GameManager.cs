using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;

    private int _lives = 3;
    private float respawnTime = 3.0f;
    private float respawnInvunerabilityTime = 3.0f;
    public int score = 0;
    public Canvas gameOverCanvas;

    private void Awake()
    {
        //gameOverCanvas.enabled = true;
        gameOverCanvas.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if(asteroid.size < 0.75f)
        {
            score += 100;
        }else if(asteroid.size < 1.2f)
        {
            score += 50;
        }else if(asteroid.size < 1.5f)
        {
            score += 25;
        }
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
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
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), respawnInvunerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver()
    {
        //TODO
        Debug.Log("Game Over");
        gameOverCanvas.gameObject.GetComponent<Canvas>().enabled = true;
        gameOverCanvas.gameObject.transform.GetChild(2).GetComponent<Text>().text = score.ToString();
        //gameOverCanvas.enabled = true;
    }
}
