using UnityEngine;


public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Enemy"))
        {            
            hitTransform.GetComponent<EnemyStats>().TakeDamage(20);
        }
        Destroy(gameObject);
    }
}