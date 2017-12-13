using System;
using UnityEngine;

namespace AssemblyCSharp.Common
{
	public class GameSettings
	{
		/// <summary>
		/// Returns the object for the current game that contains the settings for that game.
		/// </summary>
		/// <value>The current games settings.</value>
		public static GameSettings CurrentSettings {
			get {
				return Game.CurrentGame.Settings;
			}
		}

		/// <summary>
		/// The tile prefab used to create the game object for a tile.
		/// </summary>
		public GameObject TilePrefab {
			get {
				GameObject tilePrefab = Resources.Load ("Prefab/Placement/TileObject");
				return tilePrefab;
			}
		}

		/// <summary>
		/// The size of each tile (x and y).
		/// </summary>
		private float tileSize = -1;
		/// <summary>
		/// The size of each tile (x and y).
		/// </summary>
		public float TileSize {
			get { return this.tileSize; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyCSharp.GameSettings"/> class.
		/// </summary>
		public GameSettings (float tileSize)
		{
			this.tileSize = tileSize;
		}
	}
}

