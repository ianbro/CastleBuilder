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

		/// <summary>
		/// Places the tile on the map and returns the Tile object created.
		/// </summary>
		/// <returns>The tile.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="z">The z coordinate.</param>
		/// <param name="rotationY">Rotation y.</param>
		public Tile PlaceTile(int x, int z, float rotationY) {
			Tile t = new Tile(x, z, rotationY);
			t.Render ();
			return t;
		}

	}
}

