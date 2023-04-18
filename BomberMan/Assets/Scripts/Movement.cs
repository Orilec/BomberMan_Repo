using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    public void SimpleMove(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
        var z = -90f * direction.x;
        if(direction.y == -1)
        {
            z = 180f;
        }
        _player.playerEyes.transform.localEulerAngles = new Vector3(0f, 0f, z);
    }

    public int[] PositionOnGrid() {
        var x = Mathf.RoundToInt(transform.position.x);
        var y = Mathf.RoundToInt(transform.position.y);
        int[] array = { x, y };
        return array;
    }
}
