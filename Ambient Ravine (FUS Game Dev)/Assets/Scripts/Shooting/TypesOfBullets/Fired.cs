using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Fired : MonoBehaviour
{
    Bullets CurrentBulletType;

    private void Awake()
    {
        CurrentBulletType = GetComponent<Bullets>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D) 
    {
        CurrentBulletType.OnHit(collider2D);
    }

    private void Start()
    {
        CurrentBulletType.Fired();
    }
}
