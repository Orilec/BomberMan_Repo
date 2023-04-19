using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _effectTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if(player != null)
        {
            if (!player.itemInEffect)
            {
                OnCollected(player);
                Destroy(gameObject);
            }
        }
    }
    public virtual void OnCollected(Player player)
    {
        player.itemInEffect = true;
        Debug.Log("collected something");
    }



}
