using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    public GameObject TOB;
    //[SerializeField]
    //public GameObject UImanagerObject;
    [SerializeField]
    public Transform Firepoint;
    [SerializeField]
    public int Pointer = 0;
    [SerializeField]
    public List<Bullets> InventorySlot;

    //private UIManager uiManager;

    private float lastUsedTime = 0;

    // Obtains all scripts of type Bullet inside of the Empty Object "Types of Bullets"
    void Start()
    {
        InventorySlot.AddRange(TOB.GetComponents<Bullets>());
        //uiManager = UImanagerObject.GetComponent<UIManager>();
        //uiManager.UpdateWeaponName(InventorySlot[Pointer].WeaponName);
        //uiManager.UpdateAmmoAmmount(InventorySlot[Pointer].AmmoCount);
    }


    // Update is called once per frame
    void Update()

    {
        //Going down one on the weapons list as long as there is a weapon in the next place
        if (Input.GetKeyDown(KeyCode.Q) && Pointer > 0)
        {
            Pointer--;
            SwitchingGun();
        }

        //Going up one on the weapons list as long as there is a weapon in the next place
        if (Input.GetKeyDown(KeyCode.E) && Pointer < (InventorySlot.Count - 1))
        {
            Pointer++;
            SwitchingGun();
        }

        //Shoots the bullet                 Rate of fire                Has enough ammo
        if (Input.GetButtonDown("Fire1") && Time.time > lastUsedTime && InventorySlot[Pointer].AmmoCount > 0)
        {
            lastUsedTime = Time.time + InventorySlot[Pointer].CoolDown;

            InventorySlot[Pointer].AmmoCount--;
            InventorySlot[Pointer].Shoot(Firepoint);
            //uiManager.UpdateAmmoAmmount(InventorySlot[Pointer].AmmoCount);
        }

    }

    private void SwitchingGun()
    {
        lastUsedTime = Time.time + 1f;
        //uiManager.UpdateWeaponName(InventorySlot[Pointer].WeaponName);
        //uiManager.UpdateAmmoAmmount(InventorySlot[Pointer].AmmoCount);
    }
}
