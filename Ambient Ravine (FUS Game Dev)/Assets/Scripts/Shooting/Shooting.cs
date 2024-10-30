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
    [SerializeField]
    public GameObject Managers;
    [SerializeField]
    public Transform Firepoint;
    [SerializeField]
    public int Pointer = 0;
    [SerializeField]
    public List<Bullets> InventorySlot;

    private UIManager uiManager;

    private float lastUsedTime = 0;

    // Obtains all scripts of type Bullet inside of the Empty Object "Types of Bullets"
    void Start()
    {
        InventorySlot.AddRange(TOB.GetComponents<Bullets>());
        uiManager = Managers.GetComponent<UIManager>();
        uiManager.UpdateAmmo(InventorySlot[Pointer].AmmoCount);
        uiManager.UpdateGun(InventorySlot[Pointer].WeaponName);
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
        
        //Checking if gun is automatic
        if (InventorySlot[Pointer].GunAuto == true)
        {
            if (Input.GetMouseButton(0) && canfire())
            {
                Shoot();
            }
        } 
        else
        {   
            //Shoots the bullet                 Rate of fire                Has enough ammo
            if (Input.GetButtonDown("Fire1") && canfire())
            {
                Shoot();
            }
        }
       
       
    }

    private bool canfire()
    {
        return Time.time > lastUsedTime && InventorySlot[Pointer].AmmoCount > 0;
    }

    private void Shoot()
    {
        lastUsedTime = Time.time + InventorySlot[Pointer].CoolDown;

        InventorySlot[Pointer].AmmoCount--;
        InventorySlot[Pointer].Shoot(Firepoint);
        uiManager.UpdateAmmo(InventorySlot[Pointer].AmmoCount);
    }

    private void SwitchingGun()
    {
        lastUsedTime = Time.time + 1f;
        uiManager.UpdateGun(InventorySlot[Pointer].WeaponName);
        uiManager.UpdateAmmo(InventorySlot[Pointer].AmmoCount);
    }
}
