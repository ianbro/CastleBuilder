using UnityEngine;
using System.Collections;
using AssemblyCSharp.Backend;
using AssemblyCSharp.Frontend;

namespace AssemblyCSharp.Common
{
	public class Game : MonoBehaviour
	{
		/// <summary>
		/// The object that contains all the global variables for this game.
		/// </summary>
		private static Game currentGame;
		/// <summary>
		/// The accessor for the object that contains all the global variables for this game.
		/// </summary>
		public static Game CurrentGame {
			get {
				if (currentGame == null) {
					GameObject currentGameObject = GameObject.Find ("GameInfo");
					currentGame = currentGameObject.GetComponent<Game> ();
				}
				return currentGame;
			}
		}

		/// <summary>
		/// Contains settings for this game
		/// </summary>
		public GameSettings Settings;

		/// <summary>
		/// Contains the logic for this game.
		/// </summary>
		public GameLogic Logic;

		/// <summary>
		/// The remote for the main camera in the game.
		/// </summary>
		public CameraRemote MainCamera;

		// Use this for initialization
		void Start ()
		{
			this.Settings = new GameSettings (10);
			this.Logic = new GameLogic ();
			this.MainCamera = GameObject.Find ("Main Camera").GetComponent<CameraRemote> ();
		}

		#region Temp
		bool isCreatingTile = false;
		#endregion

		// Update is called once per frame
		void Update ()
		{
			Tile t;
			if (Input.GetKeyDown (KeyCode.A)) {
				isCreatingTile = !isCreatingTile;
			}

			if (isCreatingTile && Input.GetKeyDown(KeyCode.Mouse0)) {
				Ray ray = this.MainCamera.CameraScript.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) {
					Vector3 point = hit.point;
					t = new Tile(point.x, point.z, 63f);
					t.Render ();
				}
			}
		}
	}
}