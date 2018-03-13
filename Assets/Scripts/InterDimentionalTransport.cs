using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterDimentionalTransport : MonoBehaviour {

	public Material[] materials;

	// Use this for initialization
	void Start () {
		foreach (var mat in materials)
			{
				mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
			}
	}


	void OnTriggerStay(Collider other)
	{
		if (other.name != "Main Camera") 
		{
			return;		
		}

		// Outside of other world.
		if(transform.position.z > other.transform.position.z)
		{
			Debug.Log("Outside of other world");
			foreach (var mat in materials)
			{
				mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
			}
		// Inside other dimension.
		}
		else 
		{	
			Debug.Log("Inside of other world");			
			foreach (var mat in materials)
			{
				mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
			}
		}
	}

	void OnDestroy()
	{
			foreach (var mat in materials)
			{
				mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
			}
	}



	// Update is called once per frame
	void Update () {
		
	}
}
