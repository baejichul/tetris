using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gacha
{
	public class Block : MonoBehaviour
	{

		float _fall = 0;
		int _overlapped = 0;
		static int _gObjNum = 0;
		static GameObject[] _nextBlock = new GameObject[50];
		public static Transform[,] _tetrisGrid = new Transform[20, 10];


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

			if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - _fall >= 1)
            {
				transform.position += Vector3.down;
				_overlapped = OverlapChkXY(transform);
				if (_overlapped > 0)
                {
					transform.position += Vector3.up;
					InsertBlockToBack(transform);
					enabled = false;
					SpawnBlock();
				}
				_fall = Time.time;
			}
				

			if (Input.GetKeyDown(KeyCode.Space))
				transform.Rotate(Vector3.back * 90);
		}

		int BoundX(float x)
		{
			float tmpVal;
			if (x >= 0)
				tmpVal = 0.2f;
			else
				tmpVal = -0.2f;

			return (int)(x + tmpVal);
		}

		int BoundY(float y)
		{
			float tmpVal;
			if (y >= 0)
				tmpVal = 0.2f;
			else
				tmpVal = -0.2f;

			return (int)(y + tmpVal);
		}

		int OverlapChkXY(Transform transform)
        {
			int count = 0;
			foreach( Transform trfChild in transform)
            {
				if (trfChild.position.x < -4 || trfChild.position.x > 5 || trfChild.position.y < -9)
					count++;
            }
			return count;
        }

		void SpawnBlock()
        {
			int ranNum = 0;
			ranNum = Random.Range(0, 2);
			_nextBlock[_gObjNum] = (GameObject)Instantiate(Resources.Load(ResourceString(ranNum), typeof(GameObject)), new Vector2(1.0f, 8.0f), Quaternion.identity);
			_gObjNum++;
			if (_gObjNum == 50)
				_gObjNum = 0;
		}

		string ResourceString(int num)
        {
			string res = null;
			if (num == 0)
				res = "Prefabs/Block_L";
			else if (num == 1)
				res = "Prefabs/Block_O";
			return res;
		}

		void InsertBlockToBack(Transform transform)
        {
			foreach(Transform trfChild in transform)
            {
				_tetrisGrid[(int)trfChild.position.y + 9, (int)trfChild.position.x + 4] = trfChild;
			}
        }
	}
	
}