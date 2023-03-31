using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }

    public Text HealthText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (HealthText != null)
        {
            HealthText.text = "Health: " + CurrentHealth.ToString();
        }
    }
}

