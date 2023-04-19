using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _effectTime;
    [SerializeField] private SpriteRenderer _itemSpriteRenderer;
    [SerializeField] private Collider2D _itemCollider;
    [SerializeField] private GlobalManager _globalManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if(player != null)
        {
            if (!player.itemInEffect)
            {
                _itemSpriteRenderer.enabled = false;
                _itemCollider.enabled = false;
                _globalManager.currentGrid.SetGridElement(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), null);
                OnCollected(player);
            }
        }
    }
    public virtual void OnCollected(Player player)
    {
        StartCoroutine(TimerEffect(player));
        player.itemInEffect = true;
    }

    public virtual void OnEndOfEffect(Player player)
    {
        player.itemInEffect = false;
        Debug.Log("end of effect");
    }

    private IEnumerator TimerEffect(Player player)
    {
        yield return new WaitForSeconds(_effectTime);
        OnEndOfEffect(player);
        Destroy(gameObject);
    }



}
