using UnityEngine;
using UnityEditor;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        private float speed = 0f;
        private float _startOffset = 1f;
        float distanceTravelled;

        void Awake()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;

                GameEvents.Instance.OnSceneLoaded += SelectPathCreator;
                GameEvents.Instance.OnPlayerStarted += SetPlayerSpeed;
            }
        }

        private void OnDestroy()
        {
            GameEvents.Instance.OnPlayerStarted -= SetPlayerSpeed;
            GameEvents.Instance.OnSceneLoaded -= SelectPathCreator;
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + _startOffset, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        private void SelectPathCreator()
        {
            Selection.activeGameObject = pathCreator.gameObject;
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void SetPlayerSpeed()
        {
            speed = 5f;
        }

        private void ResetPlayerSpeed()
        {
            speed = 0f;
        }
    }
}