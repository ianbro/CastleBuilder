using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp.Frontend;
using AssemblyCSharp.Common;

namespace AssemblyCSharp.Backend
{
	/// <summary>
	/// A pure data representation of a tile on the game map. This only
	/// contains the backend of the tile. All the Frontend logic is Decoupled
	/// in the <see cref="Display"/> field.
	/// </summary>
	public class Tile {
		/// <summary>
		/// The displayed object on the map for the frontend.
		/// </summary>
		private TileObject display;
		public TileObject Display {
			get { return this.display; }
			set {
				if (this.display != null)
					Debug.LogWarning ("You are trying to set the display of a tile twice.");
				else
					this.display = value;
			}
		}

		/// <summary>
		/// The locations of this tile on the game map. This
		/// coordinate is in reference to the center of the
		/// tile.
		/// </summary>
		public float X, Y;

		/// <summary>
		/// The rotation of this tile.
		/// </summary>
		public Quaternion rotation;

		/// <summary>
		/// The object that is placed and installed on this tile.
		/// </summary>
		public TilePlacable InstalledObject;

		public void Render() {
			Vector3 tilePosition = GameSettings.CurrentSettings.TilePrefab.transform.position;
			tilePosition.x = this.X;
			tilePosition.y = this.Y;

			GameObject tileObject = GameObject.Instantiate(GameSettings.CurrentSettings.TilePrefab, tilePosition, rotation);
			TileObject tile = TileObject.For (tileObject);

			this.Display = tile;
			this.Display.Initialize (this);
		}
	}
}
