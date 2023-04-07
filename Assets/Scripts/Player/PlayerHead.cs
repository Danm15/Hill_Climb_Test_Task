using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public static event Action OnHeadDamaged;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Road"))
        {
            Debug.Log("Coll");
            OnHeadDamaged?.Invoke();
        }
    }
}
