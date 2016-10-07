using UnityEngine;
using System.Collections;

public class FractalS : MonoBehaviour {

	public Mesh mesh;
	public Material material;

	public int maxDepth;
	public float childScale;

	public int depth;

	private Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.back,
		Vector3.forward
	};

	private Quaternion[] childQuaternions = {
		Quaternion.identity,
		Quaternion.Euler (0, 0, -90f),
		Quaternion.Euler (0, 0, 90f),
		Quaternion.Euler (90f, 0, -180f),
		Quaternion.Euler (90, 0, 0f)
	};

	void Start () {
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		gameObject.AddComponent<MeshRenderer> ().material = material;
		gameObject.AddComponent<BoxCollider> ();
		GetComponent<MeshRenderer> ().material.color = Color.Lerp (Color.white, Color.yellow, (float)depth / maxDepth);
		if (depth < maxDepth) {
			StartCoroutine (CreateChildren ());
		}

	}

	public IEnumerator CreateChildren(){
		for (int i = 0; i < childDirections.Length; i++) {
			yield return new WaitForSeconds (0.5f);
			new GameObject ("Fractal Child").AddComponent<FractalS> ().Initialize (this, i);
		}
	}

	private void Initialize(FractalS parent, int index){
		mesh = parent.mesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = (0.5f + 0.5f * childScale) * childDirections[index];


		transform.localRotation = childQuaternions[index];
	}
	// Update is called once per frame
	void Update () {
	
	}
}
