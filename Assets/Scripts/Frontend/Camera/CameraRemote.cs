using UnityEngine;
using System.Collections;

namespace AssemblyCSharp.Frontend
{
	public class CameraRemote : MonoBehaviour
	{
		public float ZoomSpeed;
		public float MaxZoomIn;
		public float MaxZoomOut;

		public Camera CameraScript {
			get {
				return (Camera)this.gameObject.GetComponent<Camera>();
			}
		}

		private float getAdjustedFieldOfView(float zoom) {
			float newFOV = zoom;
				if (newFOV < this.MaxZoomIn) {
				newFOV = this.MaxZoomIn;
			} else if (newFOV > this.MaxZoomOut) {
				newFOV = this.MaxZoomOut;
			}
			return newFOV;
		}

		private void zoomViaMouse() {
			float scroll = Input.GetAxis("Mouse ScrollWheel");
			if (scroll != 0.0f) {
				float newFOV = this.CameraScript.fieldOfView + (scroll * this.ZoomSpeed);
				newFOV = this.getAdjustedFieldOfView(newFOV);
				this.CameraScript.fieldOfView = newFOV;
			}
		}

		public void setZoom(float zoom) {
			this.CameraScript.fieldOfView = this.getAdjustedFieldOfView(zoom);
		}

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
			this.zoomViaMouse ();
		}
	}
}