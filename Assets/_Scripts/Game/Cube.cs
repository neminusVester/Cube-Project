using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool _isStack = false;
    private Vector3 _cubePosition;
    private const float SphereRadius = 0.55f;
    private const int GroundLayer = 9;
    private int _layerMask = ~(1 << GroundLayer);

    private void FixedUpdate()
    {
        CheckCubeSphere(GetCubePosition(), SphereRadius);
    }

    private void CheckCubeSphere(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, _layerMask);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.layer == 10)
            {
                GameEvents.Instance.PlayerTouchWall(this.gameObject);
            }
            if (this.gameObject.layer != 7)
            {
                if (!_isStack && hitCollider.gameObject.layer == 7)
                {
                    _isStack = true;
                    GameEvents.Instance.PlayerTouchCube(this.gameObject);
                    this.gameObject.layer = 7;
                }
            }
        }
    }

    private Vector3 GetCubePosition()
    {
        var cubeTransform = transform.position;
        return _cubePosition = new Vector3(cubeTransform.x, cubeTransform.y , cubeTransform.z);
    }
}
