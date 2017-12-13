using System;

namespace AssemblyCSharp.Backend
{
	/// <summary>
	/// The interface used to allow object to be placed on a <see cref="Tile"/>.
	/// </summary>
	public interface TilePlacable
	{
		/// <summary>
		/// The <see cref="Tile"/> that this object is placed on.
		/// </summary>
		/// <value>The location.</value>
		Tile Location { get; set; }

		/// <summary>
		/// The number of tiles that this object takes up via width.
		/// </summary>
		/// <value>The width.</value>
		int Width { get; set; }

		/// <summary>
		/// The number of tiles that this object takes up via height.
		/// </summary>
		/// <value>The height.</value>
		int Height { get; set; }
	}
}

