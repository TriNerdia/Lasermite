using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHealth : MonoBehaviour
{
    public int Health = 100;
    public int MaxHealth = 100;
    public GameObject powerUp;
    public bool IsDead { get { return Health <= 0; } }
    public TMPro.TMP_Text HPText;
    Animation enemyFlicker;
    public AudioSource damageSound;
    public void Start()
    {
        enemyFlicker = GetComponent<Animation>();
        if (tag == "Player")
        {
            HPText.text = Health + "/" + MaxHealth;
        }
    }

    public void TakeDamage(int damagePoints)
    {
        Health -= damagePoints;
        if (this.gameObject.tag == "Enemy")
        {
            enemyFlicker.Play("SphereEnemyFlicker");
            damageSound.Play(0);
        }
        if (Health <= 0)
        {
            Health = 0;
        }
        if (IsDead)
        {
            if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("Gameover Menu", LoadSceneMode.Single);
            }
            else
            {
                
                if (this.gameObject.tag == "Enemy")
                {
                    damageSound.Play(0);
                    Instantiate(powerUp, transform.position, transform.rotation);
                }
                Destroy(this.gameObject);

            }
        }
        if(tag == "Player")
        {
            HPText.text = Health + "/" + MaxHealth;
        }
    }

    public void Heal(int healPoints)
    {
        Health += healPoints;
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        if (tag == "Player")
        {
            HPText.text = Health + "/" + MaxHealth;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "power up")
            // detects collision with an object named power up, duplicate script to add different kinds
            {
                //Remove the pickup from game
                Destroy(collision.gameObject);
                //increase health or add other affect to player
                Heal(10);
            }


        }
            
           
    }
}
