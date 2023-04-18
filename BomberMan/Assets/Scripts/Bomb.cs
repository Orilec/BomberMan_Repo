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
        Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, (int)transform.position.y, -1), Quaternion.identity);
        for (int x = (int)transform.position.x + 1; x < (int)transform.position.x +explosionRadius + 1; x++)
        {
            if (globalManager.currentGrid.gameElementsArray[x, (int)transform.position.y] != null)
            {
                if (!globalManager.currentGrid.gameElementsArray[x, (int)transform.position.y].CompareTag("BlocksExplosion"))
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3(x, (int)transform.position.y, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[x, (int)transform.position.y].CompareTag("StopsExplosionExpension"))
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
                var instance = Instantiate(_explosionPrefab, new Vector3(x, (int)transform.position.y, -1), Quaternion.identity);
            }
        }

        for (int x = (int)transform.position.x - 1; x > (int)transform.position.x - explosionRadius - 1; x--)
        {
            if (globalManager.currentGrid.gameElementsArray[x, (int)transform.position.y] != null)
            {
                if (globalManager.currentGrid.gameElementsArray[x, (int)transform.position.y].tag != "BlocksExplosion")
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3(x, (int)transform.position.y, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[x, (int)transform.position.y].tag == "StopsExplosionExpension")
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
                var instance = Instantiate(_explosionPrefab, new Vector3(x, (int)transform.position.y, -1), Quaternion.identity);
            }
        }

        for (int y = (int)transform.position.y + 1; y < (int)transform.position.y + explosionRadius + 1; y++)
        {
            if (globalManager.currentGrid.gameElementsArray[(int)transform.position.x, y] != null)
            {
                if (globalManager.currentGrid.gameElementsArray[(int)transform.position.x, y].tag != "BlocksExplosion")
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, y, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[(int)transform.position.x, y].tag == "StopsExplosionExpension")
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
                var instance = Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, y, -1), Quaternion.identity);
            }
        }

        for (int y = (int)transform.position.y - 1; y > (int)transform.position.y - explosionRadius - 1 ; y--)
        {
            if (globalManager.currentGrid.gameElementsArray[(int)transform.position.x, y] != null)
            {
                if (globalManager.currentGrid.gameElementsArray[(int)transform.position.x, y].tag != "BlocksExplosion")
                {
                    var instance = Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, y, -1), Quaternion.identity);
                    if (globalManager.currentGrid.gameElementsArray[(int)transform.position.x, y].tag == "StopsExplosionExpension")
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
                var instance = Instantiate(_explosionPrefab, new Vector3((int)transform.position.x, y, -1), Quaternion.identity);
            }
        }

    }
}
