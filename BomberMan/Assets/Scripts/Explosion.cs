using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timeBeforeDestruction;
    public int damages;
    private void Start()
    {
        StartCoroutine(DestroySelf());
    }
    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var destructible = other.GetComponent<Destructible>();
        if(destructible != null)
        {
            destructible.ExplodeSelf();
        }
        var player = other.GetComponent<Player>();
        if(player != null)
        {
            player.OnHurt(-damages);
        }
    }
}
