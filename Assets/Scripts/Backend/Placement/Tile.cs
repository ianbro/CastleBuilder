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
		public float X, Z;

		/// <summary>
		/// The Euler of this tile around the Y axis.
		/// </summary>
		public float rotationY;

		/// <summary>
		/// The object that is placed and installed on this tile.
		/// </summary>
		public TilePlacable InstalledObject;

		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyCSharp.Backend.Tile"/> class
		/// with the given coordinates.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="z">The z coordinate.</param>
		public Tile(float x, float z) {
			this.X = x;
			this.Z = z;
			this.rotationY = 0;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyCSharp.Backend.Tile"/> class
		/// with the given coordinates and rotation around the Y axis.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="z">The z coordinate.</param>
		/// <param name="rotation">Rotation.</param>
		public Tile(float x, float z, float rotationY) {
			this.X = x;
			this.Z = z;
			this.rotationY = rotationY;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyCSharp.Backend.Tile"/> class
		/// with the given position.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="z">The z coordinate.</param>
		public Tile(Vector3 position) {
			this.X = position.x;
			this.Z = position.z;
			this.rotationY = 0;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyCSharp.Backend.Tile"/> class
		/// with the given position and rotation around the y axis.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="z">The z coordinate.</param>
		/// <param name="rotation">Rotation.</param>
		public Tile(Vector3 position, float rotationY) {
			this.X = position.x;
			this.Z = position.z;
			this.rotationY = rotationY;
		}

		/// <summary>
		/// Renders this tile on the game map using the prefab stored in
		/// <see cref="GameSettings.CurrentSettings.TilePrefab"/>.
		/// </summary>
		public void Render() {
			Vector3 tilePosition = GameSettings.CurrentSettings.TilePrefab.transform.position;
			tilePosition.x = this.X;
			tilePosition.z = this.Z;

			GameObject tileObject = GameObject.Instantiate(GameSettings.CurrentSettings.TilePrefab);
			tileObject.transform.rotation = Quaternion.Euler (90f, this.rotationY, 0f);
			tileObject.transform.position = tilePosition;
			tileObject.transform.localScale.Set (1000f, 1000f, 1000f);

			TileObject tile = TileObject.For (tileObject);

			this.Display = tile;
			this.Display.Initialize (this);
		}
	}
}
