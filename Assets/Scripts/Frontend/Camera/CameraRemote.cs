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
		/// <summary>
		/// Determines whether or not the mouse is at the edge of the screen within a certain amount of pixels.
		/// </summary>
		/// <returns><c>true</c>, if mouse at edge of screen was ised, <c>false</c> otherwise.</returns>
		private bool isMouseAtEdgeOfScreen() {
			float topBottomDist = 30;
			float leftRightDist = 70;
			/*Debug.Log ("================");
			Debug.Log(Input.mousePosition);
			Debug.Log (this.CameraScript.pixelWidth - leftRightDist);
			Debug.Log (this.CameraScript.pixelHeight - topBottomDist);*/
			if (Input.mousePosition.x < leftRightDist ||
				Input.mousePosition.x > this.CameraScript.pixelWidth - leftRightDist ||
				Input.mousePosition.y < topBottomDist ||
				Input.mousePosition.y > this.CameraScript.pixelHeight - topBottomDist) {
				return true;
			} else {
				return false;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Pans the camera based on the mouse position on the edge of the screen. There is some manipulations
		/// that need to be done first such as flipping the x and y coordinates of the mouse position and
		/// keeping the y position of the mouse constant.
		/// </summary>
		public void panViaMouse() {
			if (this.isMouseAtEdgeOfScreen ()) {
				Vector3 mousePosition = Input.mousePosition;

				// Make mouse position on screen relative to center of screen instead of bottom left corner.
				mousePosition.x = mousePosition.x - (Screen.width / 2);
				mousePosition.y = mousePosition.y - (Screen.height / 2);

				// Because camera is top down, mouse coordinates are read with the x and y switched.
				// The Y will later be set to a constant position.
				mousePosition.z = mousePosition.y;

				Vector3 cameraDestination = this.transform.position + mousePosition;
				cameraDestination.y = this.transform.position.y;
				this.transform.position = Vector3.Lerp (this.transform.position, cameraDestination, this.PanSpeed / this.panSpeedDivisor);
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