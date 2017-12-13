using UnityEngine;
using System.Collections;
using AssemblyCSharp.Backend;

namespace AssemblyCSharp.Frontend
{
	/// <summary>
	/// A frontend representation of this tile. This class contains the logic for
	/// placing this tile's graphics on the screen and meneuvering it's children
	/// graphically on the map. The backend for this tile is found on the backendInfo
	/// field in this class.
	/// </summary>
	public class TileObject : MonoBehaviour
	{
		/// <summary>
		/// The backend representation of this tile. This object contains most of
		/// the gameplay logic for this tile.
		/// </summary>
		private Tile backendInfo;

		/// <summary>
		/// Returns the TileObject script on a given tile prefab.
		/// </summary>
		/// <param name="tilePrefab">Tile prefab.</param>
		public static TileObject For(GameObject tilePrefab) {
			return tilePrefab.GetComponent<TileObject>();
		}

		/// <summary>
		/// Initialize this tile. This method serves the purpose as a constructor
		/// because it is advised to implement an actual constructor on
		/// MonoBehavior scripts. This should be called as soon as this scripts
		/// game object is placed on the map.
		/// </summary>
		/// <param name="backendInfo">Backend info.</param>
		public void Initialize(Tile backendInfo) {
			this.backendInfo = backendInfo;
		}

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}