using UnityEngine;
using System.Collections.Generic;

namespace PathCreation.Examples
{
    // Example of creating a path at runtime from a set of points.

    [RequireComponent(typeof(PathCreator))]
    public class GeneratePathExample : MonoBehaviour
    {

        [SerializeField] private CollectibleObject gem;
        public bool closedLoop = true;
        public List<Transform> waypoints;

        void Start()
        {
            SetPoints();
            if (waypoints.Count > 0)
            {
                // Create a new bezier path from the waypoints.
                BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
                var path = GetComponent<PathCreator>();
                path.bezierPath = bezierPath;
                for (int i = 0; i < path.bezierPath.NumPoints; i++)
                {
                    PoolManager.Instance.ReuseObject<CollectibleObject>(gem, path.bezierPath.GetPoint(i), Quaternion.identity);
                }
            }
        }

        private void SetPoints()
        {
            waypoints.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                waypoints.Add(transform.GetChild(i));
            }
        }
    }
}