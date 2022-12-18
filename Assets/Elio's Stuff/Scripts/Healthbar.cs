using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHealthBar : MonoBehaviour
{
    public GameObject healthBar; // Reference to the 3D object that will represent the health bar
    public Material healthyMaterial; // Material to use when the player has full health
    public Material damagedMaterial; // Material to use when the player has taken damage
    public int maxHealth = 100; // Maximum health value
    public int currentHealth; // Current health value

    void Start()
    {
        currentHealth = maxHealth; // Set the current health to the maximum health value at the start of the game
        UpdateHealthBar(); // Update the health bar to reflect the current health value
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce the current health by the amount of damage taken
        UpdateHealthBar(); // Update the health bar to reflect the new current health value

        if (currentHealth <= 0) // If the current health is zero or less, the player has died
        {
            // Do something when the player dies (e.g. game over screen, respawn the player, etc.)
        }
    }

    public void Heal(int healing)
    {
        currentHealth += healing; // Increase the current health by the amount of healing received
        UpdateHealthBar(); // Update the health bar to reflect the new current health value
    }

    void UpdateHealthBar()
    {
        if (currentHealth == maxHealth) // If the player has full health, use the healthy material
        {
            healthBar.GetComponent<Renderer>().material = healthyMaterial;
        }
        else // If the player has taken damage, use the damaged material
        {
            healthBar.GetComponent<Renderer>().material = damagedMaterial;
        }
    }
}
