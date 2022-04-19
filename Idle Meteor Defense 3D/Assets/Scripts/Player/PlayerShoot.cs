using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerInfo info;
    [SerializeField] private GameObject bulletPrefab;

    private bool isReadyToShoot = true;

    [SerializeField] private LayerMask enemyLayer;

    private void Start()
    {
        if (info == null)
            Debug.LogError("NO INFO SCRIPT ON PLAYER");
    }

    private void Update()
    {
        if (!isReadyToShoot) { return; }

        Shoot();
    }

    private void Shoot()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, info.range, enemyLayer);
        if (cols.Length <= 0) { return; }

        Transform target = GetClosestEnemy(cols);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        BulletController controller = bullet.GetComponent<BulletController>();
        controller.damage = info.damage * PlayerMultiplayers.Instance.damageMult;
        controller.target = target;

        StartCoroutine(Reload());
        isReadyToShoot = false;
    }

    private Transform GetClosestEnemy(Collider[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Collider potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }

        return bestTarget.root;
    }

    IEnumerator Reload()
    {
        Debug.Log(1 / (info.attackSpeed * PlayerMultiplayers.Instance.attackSpd));
        yield return new WaitForSeconds(1 / (info.attackSpeed * PlayerMultiplayers.Instance.attackSpd));

        isReadyToShoot = true;
    }
}