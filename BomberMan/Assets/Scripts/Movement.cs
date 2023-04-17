using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    public void SimpleMove(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    public int[] PositionOnGrid() {
        var x = Mathf.RoundToInt(transform.position.x);
        var y = Mathf.RoundToInt(transform.position.y);
        int[] array = { x, y };
        return array;
    }
}
