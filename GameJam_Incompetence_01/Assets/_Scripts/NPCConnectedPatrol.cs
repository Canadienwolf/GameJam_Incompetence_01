using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Text;
using System.Linq;
using Assets.Code;

namespace Asset.Code
{
    public class NPCConnectedPatrol : MonoBehaviour
    {

        //Dictates wheter the agent waits on each node.
        [SerializeField]
        bool _patrolWaiting;

        //The total timw we wait at each node.
        [SerializeField]
        float _totaleWaitTime = 3f;

        //The probability of switching direction.
        [SerializeField]
        float _switchProbability = 0.2f;

        //Private variables for base behaviour.
        NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;

        bool _travelling;
        bool _waiting;
        float _waitTimer;
        int _waypointsVisited;

        // Start is called before the first frame update
        public void Start()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>();

            if (_navMeshAgent == null)
            {
                Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
            }
            else
            {
                if (_currentWaypoint == null)
                {
                    //Set it at random.
                    //Grab all waypoints objects in scene.
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoints");

                    if (allWaypoints.Length > 0)
                    {
                        while (_currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                            ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                            //i.e we found waypoint
                            if (startingWaypoint != null)
                            {
                                _currentWaypoint = startingWaypoint;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Failed to find any waypoints for use in the scene.");
                    }
                }

                SetDestination();
            }
        }

        // Update is called once per frame
        void Update()
        {
            //check if we're close to the destination.
            if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
            {
                _travelling = false;
                _waypointsVisited++;

                //If we're going to wait, then wait.
                if (_patrolWaiting)
                {
                    _waiting = true;
                    _waitTimer = 0f;
                }
                else
                {
                    SetDestination();
                }
            }

            //Instead if we're waiting.
            if (_waiting)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totaleWaitTime)
                {
                    _waiting = false;

                    SetDestination();
                }
            }
        }

        private void SetDestination()
        {
            if (_waypointsVisited > 0)
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.NextWaypoint(_previousWaypoint);
                _previousWaypoint = _currentWaypoint;
                _currentWaypoint = nextWaypoint;
            }

            Vector3 targetVector = _currentWaypoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }

    }
}
