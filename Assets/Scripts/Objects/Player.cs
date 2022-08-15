using System;
using SimplePhysics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Objects
{
    public class Player : MonoBehaviour
    {
        public event UnityAction OnDeath; 
        [SerializeField] private PhysicalObject physicalObject;
        [SerializeField] private GameObject firePrefab;
        [SerializeField] private GameObject fireSecondaryPrefab;
        [SerializeField] private Transform attackEffectSpawn;
        [SerializeField] private Text currentCoordText;
        [SerializeField] private Text currentAngleText;
        [SerializeField] private Text currentSpeedText;
        [SerializeField] private Text secondaryChargeCountText;
        [SerializeField] private Text secondaryReloadTimeText;
        [SerializeField] private float bulletSpeed;
        private Vector2 inputBuffer;

        public void Move(InputAction.CallbackContext callbackContext)
        {
            inputBuffer = callbackContext.action.ReadValue<Vector2>();
//            Debug.Log("detected input " + inputBuffer);
            
        }
        
        public void Fire(InputAction.CallbackContext callbackContext)
        {
            var t = Instantiate(firePrefab, attackEffectSpawn.position, attackEffectSpawn.rotation);
            t.GetComponent<PhysicalObject>().Speed = transform.up.normalized * bulletSpeed;
        }
        
        public void FireSecondary(InputAction.CallbackContext callbackContext)
        {
            
        }
        
        void Update()
        {
            transform.Rotate(new Vector3(0,0,1),-inputBuffer.x*90*0.01f);
            physicalObject.Acceleration = transform.up * inputBuffer.y;   
            
            //get the screen position
            Vector3 scrPos = Camera.main.WorldToScreenPoint(transform.position);
            if (scrPos.x < 0) Teleport(scrPos,Screen.width - 5,scrPos.y);//Screen.width - 10
            if (scrPos.x > Screen.width) Teleport(scrPos,5,scrPos.y);//10
            if (scrPos.y > Screen.height) Teleport(scrPos,scrPos.x,5);
            if (scrPos.y < 0) Teleport(scrPos,scrPos.x,Screen.height-5);
        }

        void Teleport(Vector3 scrPos,float targetX,float targetY)
        {
            Vector3 goalScrPos = new Vector3(targetX, targetY, scrPos.z);
            Vector3 targetWorldPos = Camera.main.ScreenToWorldPoint(goalScrPos);
            transform.position = targetWorldPos;
        }

        private void OnDestroy()
        {
            OnDeath?.Invoke();
        }
    }
}