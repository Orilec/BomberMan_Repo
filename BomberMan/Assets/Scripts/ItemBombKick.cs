using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBombKick : Item
{
    public override void OnCollected(Player player)
    {
        base.OnCollected(player);
        player.playerKickBombEnabled = true;
    }

    public override void OnEndOfEffect(Player player)
    {
        base.OnEndOfEffect(player);
        player.playerKickBombEnabled = false;
    }
}
