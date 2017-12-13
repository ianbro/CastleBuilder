using System;
using AssemblyCSharp.Backend;
using UnityEngine;

namespace AssemblyCSharp.Common
{
	public class GameLogic
	{
		/// <summary>
		/// Returns the object for the current game that contains the logic for that game.
		/// </summary>
		/// <value>The current games logic.</value>
		public static GameLogic CurrentLogic {
			get {
				return Game.CurrentGame.Logic;
			}
		}

		public GameLogic ()
		{
			
		}

		public void PlaceTile(int x, int y, Quaternion rotation) {

		}

	}
}

