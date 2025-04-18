using UnityEngine;

namespace Scrips
{
    public class SkyboxRotator : MonoBehaviour
    {
        public float rotationSpeed = 1f;

        void Update()
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        }
    }
}