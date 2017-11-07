using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour {

	[SerializeField] private Text health, level;
	[SerializeField] private Image healthFill, levelFill;
	[SerializeField] private Player player;

	// //Stats
	// private List<Text> playerStatTexts = new List<Text>();
	// [SerializeField] private Text playerStatPrefab;
	// [SerializeField] private Transform playerStatPanel;

	// //Equipped Weapon
	// [SerializeField] private Sprite defaultWeaponSprite;
	// [SerializeField] private PlayerWeaponController playerWeaponController;
	// [SerializeField] private Text weaponStatPrefab;
	// [SerializeField] private Transform weaponStatsPanel;
	// [SerializeField] private Text weaponNameText;
	// [SerializeField] private Image weaponIcon;
	// private List<Text> weaponStatTexts = new List<Text>();

	void Start() {
		//playerWeaponController = player.GetComponent<PlayerWeaponController>();
		player = GetComponent<Player>();
		UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
		// UIEventHandler.OnStatsChanged += UpdateStats;
		// UIEventHandler.OnItemEquipped += UpdateEquippedWeapon;
		// InitializeStats();
	}
	
	void UpdateHealth(int currentHealth, int maxHealth){
		this.health.text = currentHealth.ToString();
		this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
	}

	// void InitializeStats(){
	// 	for(int i = 0; i < player.characterStats.stats.Count; i++){
	// 		playerStatTexts.Add(Instantiate(playerStatPrefab));
	// 		playerStatTexts[i].transform.SetParent(playerStatPanel);
	// 	}
	// 	UpdateStats();
	// }

	// void UpdateStats(){
	// 	for(int i = 0; i < player.characterStats.stats.Count; i++){
	// 		playerStatTexts[i].text = player.characterStats.stats[i].StatName + ": " + player.characterStats.stats[i].GetCalculatedStatValue().ToString();
	// 	}
	// }

	// void UpdateEquippedWeapon(Item item){
	// 	weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.WeaponType + item.Rarity + item.ObjectSlug);
	// 	weaponNameText.text = item.ItemName;
	// }
}
