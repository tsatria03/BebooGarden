﻿using BebooGarden.GameCore;

namespace BebooGarden.Interface.UI;

public partial class ChooseMenu<T> : Form
{
  public T? Result;

  public ChooseMenu(string title, Dictionary<string, T> choices, bool closeWhenSelect = false)
  {
    WindowState = FormWindowState.Maximized;
    Choices = choices;
    var lblTitle = new Label();
    Text = IGlobalActions.GetLocalizedString(title);
    lblTitle.Text = IGlobalActions.GetLocalizedString(title);
    lblTitle.AutoSize = true;
    Controls.Add(lblTitle);

    for (var i = 0; i < Choices.Keys.Count; i++)
    {
      var choiceText = Choices.Keys.ElementAt(i);
      var btnOption = new Button();
      btnOption.Text = choiceText;
      btnOption.AccessibleDescription = i + 1 + "/" + (Choices.Keys.Count + 1);
      btnOption.Click += btn_Click;
      btnOption.Enter += btn_enter;
      Controls.Add(btnOption);
    }
    var bcak = new Button();
    bcak.Text = IGlobalActions.GetLocalizedString("ui.back");
    bcak.AccessibleDescription = Choices.Keys.Count + 1 + "/" + (Choices.Keys.Count + 1);
    bcak.Click += Back;
    bcak.Enter += btn_enter;
    Controls.Add(bcak);
    Game.ResetKeyState();
  }

  protected virtual void Back(object? sender, EventArgs e)
  {
    Game.SoundSystem.System.PlaySound(Game.SoundSystem.MenuReturnSound);
    Close();
  }

  protected Dictionary<string, T> Choices { get; }
  public bool CloseWhenSelect { get; }

  private void btn_enter(object? sender, EventArgs e)
  {
    Game.SoundSystem.System.PlaySound(Game.SoundSystem.MenuBipSound);
  }

  protected virtual void btn_Click(object sender, EventArgs e)
  {
    Game.SoundSystem.System.PlaySound(Game.SoundSystem.MenuOkSound);
    var clickedButton = (Button)sender;
    Result = Choices[clickedButton.Text];
    Close();
  }
}