using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_destory : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
