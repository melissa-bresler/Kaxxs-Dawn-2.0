using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public PlayerHealth playerHealth;

    public void update()
    {
        UpdateHearts();
    }

    void UpdateHearts()
    {
        health = playerHealth.health;
        numOfHearts = playerHealth.maxHealth;

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i=0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
