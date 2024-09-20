using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private Transform _objectToShoot;

    private WaitForSeconds _shootInterval;

    private void Start()
    {
        _shootInterval = new WaitForSeconds(_timeBetweenShoots);

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Rigidbody bulletRigidbody;
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;

            Bullet newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            if (newBullet.TryGetComponent(out bulletRigidbody))
            {
                bulletRigidbody.transform.up = direction;
                bulletRigidbody.velocity = direction * _speed;
            }

            yield return _shootInterval;
        }
    }
}