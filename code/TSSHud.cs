﻿using Sandbox.UI;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//

/// <summary>
/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
/// via RootPanel on this entity, or Local.Hud.
/// </summary>
public partial class TSSHud : Sandbox.HudEntity<RootPanel>
{
	public static TSSHud Instance;

	public TSSHud()
	{
		if ( IsClient )
		{
			Instance = this;
		}
	}
}


