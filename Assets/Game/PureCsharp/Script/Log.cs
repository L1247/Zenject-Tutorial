#region

using UnityEngine;

#endregion

namespace PureCsharp.Core
{
    public class Log : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Transform target;

    #endregion

    #region Private Methods

        [ContextMenu("Show")]
        private void Show()
        {
            var sprite        = spriteRenderer.sprite; // Get sprite
            var bounds        = sprite.bounds;
            var pivotX        = -bounds.center.x / bounds.extents.x / 2 + 0.5f;
            var pivotY        = -bounds.center.y / bounds.extents.y / 2 + 0.5f;
            var pixelsToUnits = sprite.textureRect.width / bounds.size.x;
            Debug.Log($"{spriteRenderer.bounds}");
            Debug.Log($"{pivotX} , {pivotY}");
            var x = bounds.size.x * (0.5f - pivotX);
            var y = bounds.size.y * (0.5f - pivotY);
            Debug.Log($"{bounds.size}");
            // var center = spriteRenderer.sprite.bounds.center;
            var center = new Vector3(x , y , 0);
            Debug.Log($"transform position: {center}");
            target.position = spriteRenderer.transform.position + center;
        }

    #endregion
    }
}