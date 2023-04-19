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
    private Explosion _explosionPrefab;


    public CameraShake _cameraShake;
    public float timeBeforeDetonation;
    public int explosionRadius;
    public GlobalManager globalManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDetonation());
        _cameraShake = FindObjectOfType<CameraShake>();
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
        yield return new WaitForSeconds(timeBeforeDetonation);
        _cameraShake.TriggerShake();
        ComputeExplosion();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    private void ComputeExplosion()
    {
        var transformX = Mathf.RoundToInt(transform.position.x);
        var transformY = Mathf.RoundToInt(transform.position.y);
        Instantiate(_explosionPrefab, new Vector3(transformX, transformY, -1), Quaternion.identity);
        for (int x = transformX + 1; x < transformX +explosionRadius + 1; x++)
        {
            if (globalManager.currentGrid.gameElementsArray[x, transformY] != null)
            {
                if (!globalManager.currentGrid.gameElementsArray[x, transformY].CompareTag("BlocksExplosion"))
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3(x, transformY, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[x, transformY].CompareTag("StopsExplosionExpension"))
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
            }
            else
            {
                var instance = Instantiate(_explosionPrefab, new Vector3(x, transformY, -1), Quaternion.identity);
            }
        }

        for (int x = transformX - 1; x > transformX - explosionRadius - 1; x--)
        {
            if (globalManager.currentGrid.gameElementsArray[x, transformY] != null)
            {
                if (globalManager.currentGrid.gameElementsArray[x, transformY].tag != "BlocksExplosion")
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3(x, transformY, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[x, transformY].tag == "StopsExplosionExpension")
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
            }
            else
            {
                var instance = Instantiate(_explosionPrefab, new Vector3(x, transformY, -1), Quaternion.identity);
            }
        }

        for (int y = transformY + 1; y < transformY + explosionRadius + 1; y++)
        {
            if (globalManager.currentGrid.gameElementsArray[transformX, y] != null)
            {
                if (globalManager.currentGrid.gameElementsArray[transformX, y].tag != "BlocksExplosion")
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3(transformX, y, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[transformX, y].tag == "StopsExplosionExpension")
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
            }
            else
            {
                var instance = Instantiate(_explosionPrefab, new Vector3(transformX, y, -1), Quaternion.identity);
            }
        }

        for (int y = transformY - 1; y > transformY - explosionRadius - 1 ; y--)
        {
            if (globalManager.currentGrid.gameElementsArray[transformX, y] != null)
            {
                if (globalManager.currentGrid.gameElementsArray[transformX, y].tag != "BlocksExplosion")
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3(transformX, y, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[transformX, y].tag == "StopsExplosionExpension")
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }
            }
            else
            {
                var instance = Instantiate(_explosionPrefab, new Vector3(transformX, y, -1), Quaternion.identity);
            }
        }

    }
}
