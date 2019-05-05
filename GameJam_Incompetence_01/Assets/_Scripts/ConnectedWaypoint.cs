using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Assets.Code
{
    public class ConnectedWaypoint : MonoBehaviour
    {
        [SerializeField]
        protected float _connectivityRadius = 50f;

        List<ConnectedWaypoint> _connections;
        public float debugDrawRadius;


        // Start is called before the first frame update
        void Start()
        {
            //Grab all waypoints in the scene
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoints");

            //create a list of waypoints i can refer to later.
            _connections = new List<ConnectedWaypoint>();

            //Check if they're a connected waypoint.
            for (int i = 0; i < allWaypoints.Length; i++)
            {
                ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>();

                //i.e we found a waypoint.
                if (nextWaypoint != null)
                {
                    if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this)
                    {
                        _connections.Add(nextWaypoint);
                    }
                }
            }
        }
        
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
        }

        public ConnectedWaypoint NextWaypoint(ConnectedWaypoint previousWaypoint)
        {
            if (_connections.Count == 0)
            {
                //No waypoints? Return null and complain
                Debug.Log("Insufficient waypoint count");
                return null;
            }
            else if (_connections.Count == 1 && _connections.Contains(previousWaypoint))
            {
                //Only one waypoint and it's the previous one? Just use that.
                return previousWaypoint;
            }
            else //otherwise, find a random one that isn't the previous one.
            {
                ConnectedWaypoint nextWaypoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, _connections.Count);
                    nextWaypoint = _connections[nextIndex];

                } while (nextWaypoint == previousWaypoint);

                return nextWaypoint;
                

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
