using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField]
    TextMeshProUGUI Ammo;
    [SerializeField]
    TextMeshProUGUI Gun;
    [SerializeField]
    Image Health;

    public void UpdateAmmo(int ammo)
    {
        if (ammo > 0)
        {
            Ammo.text = "Ammo: " + ammo.ToString();
        } else
        {
            Ammo.text = "Out of Ammo";
        }
        
    }

    public void UpdateGun(string gun)
    {
        Gun.text = gun;
    }

    public void UpdateHealthBar(float health)
    {
        Health.fillAmount = health / 20f;
        Health.color = Color.Lerp(Color.red, Color.green, health / 20f);
    }
}
