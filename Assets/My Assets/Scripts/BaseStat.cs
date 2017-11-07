using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat {

	public enum BaseStatType { Power, Defence, Health }

	public List<StatBonus> BaseAdditives { get; set; }
	[JsonConverter(typeof(StringEnumConverter))]
	public BaseStatType StatType { get; set; }
	public int BaseValue { get; set; }
	public string StatName { get; set; }
	public string StatDescription { get; set; }
	public int FinalValue { get; set; }

	// public BaseStat(int baseValue, string statName, string statDescription){
	// 	BaseAdditives = new List<StatBonus>();
	// 	BaseValue = baseValue;
	// 	StatName = statName;
	// 	StatDescription = statDescription;
	// }

	[Newtonsoft.Json.JsonConstructor]
	public BaseStat(BaseStatType statType, int baseValue, string statName){
		StatType = statType;
		BaseAdditives = new List<StatBonus>();
		BaseValue = baseValue;
		StatName = statName;
	}

	public void AddStatBonus(StatBonus statBonus){
		BaseAdditives.Add(statBonus);
	}

	public void RemoveStatBonus(StatBonus statBonus){
		BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
	}

	public int GetCalculatedStatValue(){
		FinalValue = 0;
		BaseAdditives.ForEach(x => FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}
}
