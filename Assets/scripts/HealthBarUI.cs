using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float health , maxHealth , width , height ;

    [SerializeReference]
    private RectTransform healthBar;

    public void setMaxHealth(float max)
    {
        maxHealth = max;
    }

    public void setHealth(float health)
    {
        this.health = health;

        float newWidth = (this.health / maxHealth) * width ;
        healthBar.sizeDelta = new Vector2 (newWidth, height);
    }
}
