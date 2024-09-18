using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _timeWaitShooting;

    private Transform _objectToShoot;
        
    void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var _vector3direction = (_objectToShoot.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + _vector3direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}