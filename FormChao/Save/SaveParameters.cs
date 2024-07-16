﻿
using BebooGarden.GameCore.Pet;
using BebooGarden.GameCore.World;

namespace BebooGarden.Save;

public class SaveParameters
{
  public float Volume { get; set; }
  public string? Language { get; set; }
  public string BebooName { get; set; }
  public int Age { get; set; }
  public DateTime LastPlayed { get; set; }
  public float Energy { get; set; }
  public int Happiness { get; set; }
  public Flags Flags { get; set; }
  public string PlayerName { get; set; }
  public string FavoredColor { get; internal set; }
  public SortedDictionary<FruitSpecies, int> FruitsBasket { get; set; }
  public int RemainingFruits {  get; set; }
  public SaveParameters(string? language, float volume, string bebooName, int age, float energy, int happiness, DateTime lastPayed, Flags flags, string playerName, SortedDictionary<FruitSpecies,int> fruitsBasket, int remainingFruits)
  {
    Volume = volume;
    Language = language;
    Energy = energy;
    Happiness = happiness;
    BebooName = (bebooName ?? "");
    Age = age;
    LastPlayed = lastPayed;
    Flags = flags;
    PlayerName = playerName;
    FruitsBasket = fruitsBasket;
    RemainingFruits = remainingFruits;
  }

  public SaveParameters()
  {
    Volume = 0.5f;
    Language = "en";
    BebooName = string.Empty;
    Age = 0;
    LastPlayed = default(DateTime);
    Energy = 5;
    Flags = new();
    PlayerName = string.Empty;
    FavoredColor = "none";
    FruitsBasket = [];
  }
}
