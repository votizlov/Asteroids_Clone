using UnityEngine;

namespace Objects
{
    public class SmallMeteorite : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
