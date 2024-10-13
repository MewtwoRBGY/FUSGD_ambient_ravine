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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentBulletType.OnHit();
    }

    private void Start()
    {
        CurrentBulletType.Fired();
    }
}
