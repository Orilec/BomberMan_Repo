using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdditionalBombRadius : Item
{
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        player.playerBombSpawner.currentExplosionRadius++;
    }
}
