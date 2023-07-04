using UnityEngine;

namespace Script
{
    public class Dead : MonoBehaviour
    {
        [SerializeField] HitPoints HP;
        [SerializeField] GameObject projectilePrefab;
        void Update()
        {
            if(HP.HP <= 0){
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
