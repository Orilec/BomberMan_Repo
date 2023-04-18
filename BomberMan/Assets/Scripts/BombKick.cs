using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKick : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GlobalManager _globalManager;
    [SerializeField] private float _speed;


    public void KickBomb()
    {
        var bombToKick = _globalManager.currentGrid.gameElementsArray[_player.playerMovement.PositionOnGrid()[0], _player.playerMovement.PositionOnGrid()[1]].GetComponent<Bomb>();
        if(bombToKick != null)
        {
            StartCoroutine(BombMovement(bombToKick));
        }        
    }

    private IEnumerator BombMovement(Bomb bomb)
    {
        
        while (Vector2.Distance(bomb.transform.position, bomb.transform.position + _player.playerEyes.transform.up) > 0.001f)
        {
            Debug.Log(Vector2.Distance(bomb.transform.position, bomb.transform.position + _player.playerEyes.transform.up));
            bomb.transform.position = Vector2.MoveTowards(bomb.transform.position, bomb.transform.position + _player.playerEyes.transform.up, _speed);
            yield return new WaitForEndOfFrame();
        }
    }
}
