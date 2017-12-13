using UnityEngine;
using System.Collections;
using AssemblyCSharp.Backend;

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

		// Use this for initialization
		void Start ()
		{
			this.Settings = new GameSettings (10);
			this.Logic = new GameLogic ();
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
				Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) {
					Vector3 point = hit.point;
					t = new Tile(point.x, point.z, 63f);
					Debug.Log (t);
					t.Render ();
				}
			}
		}
	}
}