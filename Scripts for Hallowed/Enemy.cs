using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f;
    private float _currentHealth;
    public Image healthBar;
    public Transform healthBarUI;

    private void Start()
    {
        _currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            // Handle enemy death
            Destroy(gameObject); // Destroy the enemy GameObject
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float normalizedHealth = Mathf.Clamp01(_currentHealth / maxHealth);
            healthBar.fillAmount = normalizedHealth;
        }
    }

    private void Update()
    {
        // Make the health bar face the camera
        if (healthBarUI != null && Camera.main != null)
        {
            healthBarUI.LookAt(Camera.main.transform);
        }
    }
}
