using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ZombieCollision : MonoBehaviour
{

    public GameObject healthBarGameObject;
    public Image healthBarImage;
    public TextMeshProUGUI scoreText;
  

    private RectTransform healthBar;


    void Start()
    {

        healthBar = GameObject.Find("Bar").GetComponent<RectTransform>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        healthBar = GameObject.Find("Bar").GetComponent<RectTransform>();
        healthBarImage = GameObject.Find("Bar").GetComponent<Image>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();


        DeathScreenManager.Instance.HideDeathScreen();


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.RemoveScore(1);
            UpdateHealthBar(-20);
        }

    }


    public void UpdateHealthBar(int delta)
    {
        if (healthBar != null && healthBarImage != null)
        {
            float maxHealth = 240; 
            float newWidth = Mathf.Clamp(healthBar.sizeDelta.x + delta, 0, maxHealth);
            healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);

            float healthPercentage = newWidth / maxHealth;
            UpdateHealthBarColor(healthPercentage);

            if (newWidth <= 0)
            {
                TriggerDeath();
            }
        }
    }

    void UpdateHealthBarColor(float healthPercentage)
    {
        if (healthPercentage > 0.8f)
        {
            healthBarImage.color = Color.green;  
        }
        else if (healthPercentage > 0.6f)
        {
            healthBarImage.color = Color.yellow;  
        }
        else if (healthPercentage > 0.4f)
        {
            healthBarImage.color = new Color(1f, 0.65f, 0f);  
        }
        else
        {
            healthBarImage.color = Color.red;  
        }
    }

    void TriggerDeath()
    {

        GameObject zombieSpawnerGameObject = GameObject.Find("ZombieSpawner");
        if (zombieSpawnerGameObject != null)
        {
            ZombieSpawning zombieSpawner = zombieSpawnerGameObject.GetComponent<ZombieSpawning>();
            if (zombieSpawner != null)
            {
                zombieSpawner.StopSpawning();
                zombieSpawner.enabled = false;
            }
        }

        GameObject healthKitSpawnerGameObject = GameObject.Find("HealthKitSpawner");
        if (healthKitSpawnerGameObject != null)
        {
            ZombieSpawning healthKitSpawner = healthKitSpawnerGameObject.GetComponent<ZombieSpawning>();
            if (healthKitSpawner != null)
            {
                healthKitSpawner.StopSpawning();
                healthKitSpawner.enabled = false;
            }
        }

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (var zombie in zombies)
        {
            Destroy(zombie);
        }

        GameObject[] healthKits = GameObject.FindGameObjectsWithTag("HealthKit");
        foreach (var healthKit in healthKits)
        {
            Destroy(healthKit);
        }

        if (scoreText != null)
        {
            scoreText.text = "";
        }

        DeathScreenManager.Instance.ShowDeathScreen(ScoreManager.Instance.score);

    }
}