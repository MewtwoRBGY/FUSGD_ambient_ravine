using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Fired : MonoBehaviour
{
    [SerializeField]
    public Bullets CurrentBulletType { get; set; }

    bool Strike;

    private void Awake()
    {
        Strike = false;
    }

    private void OnTriggerEnter2D(Collider2D collider2D) 
    {
        if (Strike == false) {
            Strike = true;
            CurrentBulletType.OnHit(collider2D, gameObject);
        }
    }

    private void Start()
    {
        CurrentBulletType.Fired(gameObject);
    }
}
