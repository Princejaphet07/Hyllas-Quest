using UnityEngine;
using System;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private EnemyEntity targetEnemy; // Ang Mushroom nga atong atangan
    [SerializeField] private GameObject bossGameObject; // Ang Boss nga mogawas

    private void Start()
    {
        // Paminawon nato kung mamatay na ba ang Mushroom
        if (targetEnemy != null)
        {
            targetEnemy.OnDeath += TargetEnemy_OnDeath;
        }

        // Siguraduhon nga naka-hide ang Boss sa pagsugod
        if (bossGameObject != null)
        {
            bossGameObject.SetActive(false);
        }
    }

    private void TargetEnemy_OnDeath(object sender, EventArgs e)
    {
        // Inig mamatay ang Mushroom, ipagawas dayon ang Boss!
        if (bossGameObject != null)
        {
            bossGameObject.SetActive(true);
            
            // Ibutang ang Boss kung asa dapit namatay ang Mushroom
            bossGameObject.transform.position = targetEnemy.transform.position; 
        }
    }
}
