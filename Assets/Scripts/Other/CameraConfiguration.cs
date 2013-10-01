using UnityEngine;

namespace Assets.Scripts.Other
{
    [ExecuteInEditMode]
    public class CameraConfiguration : MonoBehaviour
    {
        [SerializeField] private bool isUnitToPixel = true;
        [SerializeField] private bool isAutoUnitToPixel = false;

        private void Awake()
        {
            camera.orthographic = true;

            SetScreenOrientation();

            if (isUnitToPixel)
            {
                SetUniform();
            }
        }

        private void SetScreenOrientation()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        private void LateUpdate()
        {
            if (isAutoUnitToPixel && isUnitToPixel)
            {
                SetUniform();
            }
        }

        private void SetUniform()
        {
            float orthographicSize = camera.pixelHeight/2;
            if (orthographicSize != camera.orthographicSize)
            {
                camera.orthographicSize = orthographicSize;
            }
        }

       
    }
}
