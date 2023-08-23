using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour, IControllable
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
        //Assigns the same amount as what the player currently has
        health = playerHealth.health;
        numOfHearts = playerHealth.maxHealth;

        //Prevents health from going above maximum amount
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i=0; i < hearts.Length; i++)
        {
            //Displays each heart according to whether or not the number is within the current health total
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Displays heart icon (empty/full) based on the maxhealth of the player.
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
