﻿using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;

public class ExercisePointPanel : WorldPanel
{
	public float Opacity;
	public float FontSize;
	public Label l;
	public float TextScale;
	public TimeSince TimeSinceAlive;
	public float Life;
	public bool Fall;
	public Vector3 InitialPosition;
	public ExercisePointPanel( int points )
	{
		Opacity = 1f;
		Fall = false;
		Life = Rand.Float( 1, 2f );
		TimeSinceAlive = 0;

		float width = 200;
		float height = 200;
		PanelBounds = new Rect( -(width / 2), -height, width, height );
		TextScale = 1f;
		string sign = (points > 0) ? "+" : " - ";
		string s = $"{sign}{points}";

		l = Add.Label( s, "title" );

		InitialPosition = Position;

		StyleSheet.Load( "/ui/ExercisePointPanel.scss" );
	}

	public override void Tick()
	{
		base.Tick();
		Style.Opacity = Opacity;
		if(TimeSinceAlive > Life )
		{
			this.Delete(true);
			return;
		}

		Opacity = 1f -MathF.Pow( ((TimeSinceAlive - Life / 2f) / (Life / 2f)), 3f).Clamp( 0, 1f );

		if ( !Fall )
		{
			Position = InitialPosition + Vector3.Up * 20f * MathF.Pow(TimeSinceAlive / Life, 2.0f);
			TextScale = TextScale.LerpTo( 1f, Time.Delta * 4f );
		}


		Style.Dirty();
		l.Style.FontSize = Length.Pixels( FontSize * TextScale );
		FontSize = 75f;
		

		if(Local.Pawn is TSSPlayer player )
		{
			var cam = player.Camera as TSSCamera;
			Rotation = Rotation.LookAt((cam.Position - Position));
		}

	}
}
