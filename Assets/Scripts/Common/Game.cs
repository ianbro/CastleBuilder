using UnityEngine;
using System.Collections;

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
		
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}