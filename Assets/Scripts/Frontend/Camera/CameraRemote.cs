using UnityEngine;
using System.Collections;

namespace AssemblyCSharp.Frontend
{
	public class CameraRemote : MonoBehaviour
	{
		#region Zooming

		#region Properties
		/// <summary>
		/// The speed of zooming. This is the amount that the scroll amount is multiplied
		/// by when calculating zoom via the mouse.
		/// </summary>
		public float ZoomSpeed;

		/// <summary>
		/// The maximum amount that the camera can zoom out to. If a scroll would
		/// result in the camera zoom going above this zoom, the zoom will be
		/// reset to this value.
		/// </summary>
		public float MaxZoomIn;

		/// <summary>
		/// The minimum amount that the camera can zoom in to. If a scroll would
		/// result in the camera zoom going below this zoom, the zoom will be
		/// reset to this value.
		/// </summary>
		public float MaxZoomOut;

		/// <summary>
		/// Gets the camera script from the camera game object attached to this script.
		/// </summary>
		/// <value>The camera script.</value>
		public Camera CameraScript {
			get {
				return (Camera)this.gameObject.GetComponent<Camera>();
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Gets field of view, restricting it to a certain range. If the zoom is too
		/// below the minimum, it will be set to the minimum and vice versa for maximum.
		/// </summary>
		/// <returns>The adjusted field of view.</returns>
		/// <param name="zoom">Zoom.</param>
		private float getAdjustedFieldOfView(float zoom) {
			float newFOV = zoom;
			if (newFOV < this.MaxZoomIn) {
				newFOV = this.MaxZoomIn;
			} else if (newFOV > this.MaxZoomOut) {
				newFOV = this.MaxZoomOut;
			}
			return newFOV;
		}

		/// <summary>
		/// Gets the amount of zoom according to the mouse and increases or
		/// decreases the zoom by that amount.
		/// </summary>
		private void zoomViaMouse() {
			float scroll = Input.GetAxis("Mouse ScrollWheel");
			if (scroll != 0.0f) {
				float newFOV = this.CameraScript.fieldOfView + (scroll * this.ZoomSpeed);
				newFOV = this.getAdjustedFieldOfView(newFOV);
				this.setZoom(newFOV);
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Sets the zoom of the camera to the given value.
		/// </summary>
		/// <param name="zoom">Zoom.</param>
		public void setZoom(float zoom) {
			this.CameraScript.fieldOfView = this.getAdjustedFieldOfView(zoom);
		}
		#endregion

		#endregion

		#region Panning

		#region Properties
		/// <summary>
		/// The speed at which the camera pans accross the map.
		/// </summary>
		public float PanSpeed;

		/// <summary>
		/// The factor that PanSpeed will be divided by when getting the fraction for
		/// the Lerp function for the camera panning.
		/// </summary>
		private float panSpeedDivisor = 1000;
		#endregion

		#region Private Methods
		private bool isMouseAtEdgeOfScreen() {
			float edgeDist = 10;
			if (Input.mousePosition.x < edgeDist ||
			    Input.mousePosition.x > Screen.width - edgeDist ||
			    Input.mousePosition.y < edgeDist ||
			    Input.mousePosition.y > Screen.height - edgeDist) {
				return true;
			} else {
				return false;
			}
		}
		#endregion

		#region Public Methods
		public void panViaMouse() {
			if (this.isMouseAtEdgeOfScreen ()) {
				Debug.Log ("======================");
				Debug.Log (this.gameObject.transform.position);
				Debug.Log (Input.mousePosition);

				Vector3 mouseCoordinateAltered = new Vector3 (Input.mousePosition.x, Input.mousePosition.z, Input.mousePosition.y);

				Ray ray = this.CameraScript.ScreenPointToRay (mouseCoordinateAltered);

				Debug.Log (mouseCoordinateAltered);
				Debug.Log (ray);

				Vector3 cameraDestinationDirection = ray.GetPoint (Screen.width/2);
				cameraDestinationDirection.y = this.gameObject.transform.position.y;

				Debug.Log (cameraDestinationDirection);

				Vector3 newCameraPosition = Vector3.Lerp (this.gameObject.transform.position, cameraDestinationDirection, this.PanSpeed/this.panSpeedDivisor);
				Debug.Log (newCameraPosition);

				//Debug.Log (cameraDestination);
				this.gameObject.transform.position = newCameraPosition;
			}
		}
		#endregion

		#endregion

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
			this.zoomViaMouse ();
			this.panViaMouse ();
		}
	}
}