using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Color _baseColor, _detonationColor;
    [SerializeField]
    private float _timeBeforeDetonation;
    [SerializeField]
    private int _explosionRadius;
    [SerializeField]
    private Explosion _explosionPrefab;


    public GlobalManager globalManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDetonation());
    }


    private IEnumerator StartDetonation()
    {
        while (true)
        {
            StartCoroutine(Detonate());
            _spriteRenderer.color = _detonationColor;
            yield return new WaitForSeconds(0.5f);
            _spriteRenderer.color = _baseColor;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(_timeBeforeDetonation);
        ComputeExplosion();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void ComputeExplosion()
    {
        for (int x = (int)transform.position.x + 1; x < (int)transform.position.x +_explosionRadius + 1; x++)
        {
            var instance = Instantiate(_explosionPrefab, new Vector3(x, (int)transform.position.y, -1), Quaternion.identity);
        }
        for (int x = (int)transform.position.x - 1; x > (int)transform.position.x - _explosionRadius - 1; x--)
        {
            var instance = Instantiate(_explosionPrefab, new Vector3(x, (int)transform.position.y, -1), Quaternion.identity);
        }
        for (int y = (int)transform.position.y + 1; y < (int)transform.position.y + _explosionRadius + 1; y++)
        {
            var instance = Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, y, -1), Quaternion.identity);
        }
        for (int y = (int)transform.position.y - 1; y > (int)transform.position.y - _explosionRadius - 1 ; y--)
        {
            var instance = Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, y, -1), Quaternion.identity);
        }

    }
}
