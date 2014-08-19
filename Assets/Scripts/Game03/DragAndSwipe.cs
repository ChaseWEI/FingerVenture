using UnityEngine;
using System.Collections;

public class DragAndSwipe : MonoBehaviour {

	public Collider DragPlaneCollider;      // collider used when dragPlaneType is set to DragPlaneType.UseCollider
	public float DragPlaneOffset = 0.0f;    // distance between dragged object and drag constraint plane
	public Camera RaycastCamera;
	
	public bool DragFromObjectCenter = false;
	
	// are we being dragged?
	bool dragging = false;
	FingerGestures.Finger draggingFinger = null;
	GestureRecognizer gestureRecognizer;
	
	bool oldUseGravity = false;
	bool oldIsKinematic = false;
	
	Vector3 physxDragMove = Vector3.zero;   // used for rigidbody drag only. This stores the drag amount to apply during the physics update in FixedUpdate()

	//

	private float startTime;
	private float endTime;
	private bool over = true;

	public GameObject first;
	public GameObject prefabs;
	private GameObject group;
	private float rate;
	//

	void Awake () {
	}

	public bool Dragging
	{
		get { return dragging; }
		private set
		{
			if( dragging != value )
			{
				dragging = value;
				
				if( rigidbody )
				{
					if( dragging )
					{
						oldUseGravity = rigidbody.useGravity;
						oldIsKinematic = rigidbody.isKinematic;
						rigidbody.useGravity = false;
						rigidbody.isKinematic = true;
					}
					else
					{
						rigidbody.isKinematic = oldIsKinematic;
						rigidbody.useGravity = oldUseGravity;
						rigidbody.velocity = Vector3.zero;
					}
				}
			}
		}
	}
	
	public enum DragPlaneType
	{
		Camera, // drag along a plane parallal to the camera/screen screen (XY)
		UseCollider, // project on the collider specified by dragPlaneCollider
	}
	
	void Start()
	{
		if( !RaycastCamera )
			RaycastCamera = Camera.main;
		//Variable.level = 1;
		switch (Variable.level) {
			case 1 :
				rate = 1f;
				break;
			case 2 :
				rate = 0.9f;
				break;
			case 3 :
				rate = 0.8f;
				break;
		}

	}
	
	// converts a screen-space position to a world-space position constrained to the current drag plane type
	// returns false if it was unable to get a valid world-space position
	public bool ProjectScreenPointOnDragPlane( Vector3 refPos, Vector2 screenPos, out Vector3 worldPos )
	{
		worldPos = refPos;
		
		if( DragPlaneCollider )
		{
			Ray ray = RaycastCamera.ScreenPointToRay( screenPos );
			RaycastHit hit;
			
			if( !DragPlaneCollider.Raycast( ray, out hit, float.MaxValue ) )
				return false;
			
			worldPos = hit.point + DragPlaneOffset * hit.normal;
		}
		else // DragPlaneType.Camera
		{
			Transform camTransform = RaycastCamera.transform;
			
			// create a plane passing through refPos and facing toward the camera
			Plane plane = new Plane( -camTransform.forward, refPos );
			
			Ray ray = RaycastCamera.ScreenPointToRay( screenPos );
			
			float t = 0;
			if( !plane.Raycast( ray, out t ) )
				return false;
			
			worldPos = ray.GetPoint( t );
		}
		
		return true;
	}
	
	void HandleDrag( DragGesture gesture )
	{
		if( !enabled )
			return;
		
		if( gesture.Phase == ContinuousGesturePhase.Started )
		{
			Dragging = true;
			draggingFinger = gesture.Fingers[0];
			startTime = Time.time;
		}
		else if( Dragging )
		{
			// make sure this is the finger we started dragging with
			if( gesture.Fingers[0] != draggingFinger )
				return;
			
			if( gesture.Phase == ContinuousGesturePhase.Updated )
			{
				Transform tf = transform;
				Vector3 move = Vector3.zero;
				
				if( DragFromObjectCenter )
				{
					Vector3 fingerPos3d;
					if( ProjectScreenPointOnDragPlane( tf.position, draggingFinger.Position, out fingerPos3d ) )
					{
						move = fingerPos3d - tf.position;
					}
				}
				else
				{
					// figure out our previous screen space finger position
					Vector3 fingerPos3d, prevFingerPos3d;
					
					// convert these to world-space coordinates, and compute the amount of motion we need to apply to the object
					if( ProjectScreenPointOnDragPlane( tf.position, draggingFinger.PreviousPosition, out prevFingerPos3d ) &&
					   ProjectScreenPointOnDragPlane( tf.position, draggingFinger.Position, out fingerPos3d ) )
					{
						move = fingerPos3d - prevFingerPos3d;
					}
				}
				
				if( rigidbody )
					physxDragMove += move; // this will be used in FixedUpdate() to properly move the rigidbody
				else {
					if(move.x >= 0)
						tf.position += new Vector3(move.x, 0, 0);

				}
			}
			else
			{
				Dragging = false;
				endTime = Time.time;
				WhenEndDrag(gesture);
			}
		}
	}

	void Update () {
		if (over && transform.position.x >= 0 && Rolling.count < 15) {
			over = false;
			group = Instantiate(prefabs, new Vector3(-15.6f, 0, 0f), Quaternion.identity) as GameObject;
			group.name = "next";
			group.rigidbody2D.velocity = rigidbody2D.velocity;
			Rolling.count += rate;
		}

		if (!over && transform.position.x < 20.8f)
			group.transform.position = transform.position - new Vector3(15.6f, 0, 0);

		if (group && transform)
			group.transform.position = transform.position - new Vector3(15.6f, 0, 0);

		if (transform.position.x >= 20.8f){
			Destroy (gameObject);
			over = true;
			if (first)
				Destroy(first);
		}

		if (Rolling.count >= 15) {
			rigidbody2D.velocity = new Vector2 (50f, 0);
			Variable.isPass = true;
		}
	}

	void FixedUpdate()
	{
//		if( Dragging && rigidbody )
//		{
//			// use MovePosition() for physics objects
//			rigidbody.MovePosition( rigidbody.position + physxDragMove );
//			
//			// reset the accumulated drag amount value 
//			physxDragMove = Vector3.zero;
//		}
		if (rigidbody2D.velocity.x >= 1)
			rigidbody2D.velocity -= new Vector2 (1, 0);

	}
	
	void OnDrag( DragGesture gesture )
	{	
		if (Time.timeScale != 0)
			HandleDrag( gesture );
	}
	
	void OnDisable()
	{
		// if this gets disabled while dragging, make sure we cancel the drag operation
		if( Dragging )
			Dragging = false;
	}

	void WhenEndDrag(DragGesture gesture){
		if(gesture.TotalMove.x >=0)
			rigidbody2D.velocity = new Vector2(gesture.TotalMove.x / (endTime - startTime) / 50f, 0f);
		if (group) 
			group.rigidbody2D.velocity = rigidbody2D.velocity;
	}
}
