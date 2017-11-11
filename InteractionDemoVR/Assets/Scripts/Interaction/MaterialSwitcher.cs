using UnityEngine;

namespace InteractionDemo.Interaction
{
    /// <summary>
    /// Special class to switch materials for object
    /// </summary>
   
    class MaterialSwitcher : MonoBehaviour
    {
        public MeshRenderer SceneRenderer;

        public Material OnMaterial;

        public Material OffMaterial;

        public bool Switch
        {
            set
            {
                SceneRenderer.sharedMaterial = value ? OnMaterial : OffMaterial;
            }
        }
    }
}
