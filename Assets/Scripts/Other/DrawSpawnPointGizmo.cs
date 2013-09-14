using UnityEngine;

namespace Assets.Scripts.Other
{
    [ExecuteInEditMode]
    public class DrawSpawnPointGizmo : MonoBehaviour
    {
        public string GizmoName;

        public void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position,GizmoName,true);
        }
    }
}
