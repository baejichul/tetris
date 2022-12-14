using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gacha
{
	public class Block : MonoBehaviour
	{
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }

	    // Update is called once per frame
	    void Update()
	    {
			MoveBlock();
	    }

		void MoveBlock()
        {
			if (Input.GetKeyDown(KeyCode.LeftArrow))
				transform.position += Vector3.left;

			if (Input.GetKeyDown(KeyCode.RightArrow))
				transform.position += Vector3.right;

			if (Input.GetKeyDown(KeyCode.UpArrow))
				transform.position += Vector3.up;

			if (Input.GetKeyDown(KeyCode.DownArrow))
				transform.position += Vector3.down;

			if (Input.GetKeyDown(KeyCode.Space))
				transform.Rotate(Vector3.back * 90);
		}
	}
}