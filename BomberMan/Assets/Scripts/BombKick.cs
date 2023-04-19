using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKick : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GlobalManager _globalManager;
    [SerializeField] private float _speed;
    [SerializeField] private int _kickPower;


    public void KickBomb()
    {
        if (_player.playerKickBombEnabled)
        {
            var bombToKick = _globalManager.currentGrid.gameElementsArray[_player.playerMovement.PositionOnGrid()[0], _player.playerMovement.PositionOnGrid()[1]].GetComponent<Bomb>();
            if (bombToKick != null)
            {
                StartCoroutine(BombMovement(bombToKick));
            }
        }
    }

    private IEnumerator BombMovement(Bomb bomb)
    {
        var actualKickLength = 0;
        for (int i = 1; i < _kickPower; i++)
        {
            var positionToCheck = _globalManager.currentGrid.gameElementsArray[Mathf.RoundToInt(bomb.transform.position.x + _player.playerEyes.transform.up.x * i), Mathf.RoundToInt(bomb.transform.position.y + _player.playerEyes.transform.up.y * i)];
            if(positionToCheck != null)
            {
                if (positionToCheck.CompareTag("BlocksExplosion") || positionToCheck.CompareTag("StopsExplosionExpension"))
                {
                    break;
                }
                else
                {
                    actualKickLength ++;
                }
            }
            else
            {
                actualKickLength ++;
            }
        }
        var target = bomb.transform.position + _player.playerEyes.transform.up * actualKickLength;
        _globalManager.currentGrid.SetGridElement(Mathf.RoundToInt(bomb.transform.position.x), Mathf.RoundToInt(bomb.transform.position.y), null);
        while (Vector2.Distance(bomb.transform.position, target) > 0.001f)
        {
            bomb.transform.position = Vector2.MoveTowards(bomb.transform.position, target, _speed);
            yield return new WaitForEndOfFrame();
        }
        _globalManager.currentGrid.SetGridElement(Mathf.RoundToInt(bomb.transform.position.x), Mathf.RoundToInt(bomb.transform.position.y), bomb.gameObject);
        yield break;
    }
}
