﻿using System.Numerics;
using System.Timers;
using BebooGarden.GameCore.Pet;
using BebooGarden.GameCore.World;
using BebooGarden.Interface;
using BebooGarden.Save;
namespace BebooGarden.GameCore;

internal class Game
{
  public SoundSystem SoundSystem { get; set; }
  private GlobalActions GlobalActions { get; set; }
  private DateTime LastPressedKeyTime { get; set; }
  static readonly System.Windows.Forms.Timer tickTimer = new();
  public Beboo beboo { get; set; }
  public BebooGarden.GameCore.World.Map Map { get; set; }
  public Game(Parameters parameters)
  {
    SoundSystem = new SoundSystem(parameters.Volume);
    GlobalActions = new GlobalActions(SoundSystem);
    SoundSystem.LoadMainScreen();
    LastPressedKeyTime = DateTime.Now;
    tickTimer.Tick += new EventHandler(Tick);
    Map = new(40, 40, [new TreeLine(new Vector2(19, 19), new Vector2(19, -19))]);
    beboo = new(this, parameters.BebooName, parameters.Age, parameters.LastPayed);
  }
  public void KeyDownMapper(object sender, KeyEventArgs e)
  {
    if ((DateTime.Now - LastPressedKeyTime).TotalMilliseconds < 200) return;
    else LastPressedKeyTime = DateTime.Now;
    switch (e.KeyCode)
    {
      case Keys.Left:
      case Keys.Q:
        SoundSystem.MovePlayerOf(new Vector3(-1, 0, 0));
        break;
      case Keys.Right:
      case Keys.D:
        SoundSystem.MovePlayerOf(new Vector3(1, 0, 0));
        break;
      case Keys.Up:
      case Keys.Z:
        SoundSystem.MovePlayerOf(new Vector3(0, 1, 0));
        break;
      case Keys.Down:
      case Keys.S:
        SoundSystem.MovePlayerOf(new Vector3(0, -1, 0));
        break;
      case Keys.Space:
        //ScreenReader.Output($"{channels} {virt}");
        SoundSystem.System.Get3DListenerAttributes(0, out Vector3 currentPosition, out _, out _, out _);
        SoundSystem.Whistle();
        beboo.WakeUp();
        beboo.GoalPosition = currentPosition;
        break;
      default:
        GlobalActions.CheckGlobalActions(e.KeyCode);
        break;
    }
  }

  public void Tick(object? _, EventArgs __)
  {
    SoundSystem.System.Update();
  }
}