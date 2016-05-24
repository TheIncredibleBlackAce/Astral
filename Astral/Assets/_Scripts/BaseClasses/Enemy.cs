using UnityEngine;
using System.Collections;

public class Enemy {

	private float health;
	private float movementSpeed;
	private float attackSpeed;
	private float attackDamage;
	private float defense;


	/*	Constructors	*/

	public Enemy()
	{
		this.setHealth(100.0f);
		this.setMovementSpeed(2.0f);
		this.setAttackSpeed(1.0f);
		this.setDamage(5.0f);
		this.setDefense(2.5f);
	}

	public Enemy(float aHealth, float moveSpeed, float attSpeed, float attDamage, float aDef)
	{
		this.setHealth(aHealth);
		this.setMovementSpeed(moveSpeed);
		this.setAttackSpeed(attSpeed);
		this.setDamage(attDamage);
		this.setDefense(aDef);
	}

	// Don't Know If This Will Be Used - Length of 5 For Array
	public Enemy(float[] stats)
	{
		this.setHealth(stats[0]);
		this.setMovementSpeed(stats[1]);
		this.setAttackSpeed(stats[2]);
		this.setDamage(stats[3]);
		this.setDefense(stats[4]);
	}

	/*	Mutators	*/

	public void setHealth(float aHealth)
	{
		health = aHealth;
	}
	public void setMovementSpeed(float moveSpeed)
	{
		movementSpeed = moveSpeed;
	}
	public void setAttackSpeed(float attSpeed)
	{
		attackSpeed = attSpeed;
	}
	public void setDamage(float attDamage)
	{
		attackDamage = attDamage;
	}
	public void setDefense(float aDef)
	{
		defense = aDef;
	}

	/*	Accessors	*/

	public float getHealth()
	{
		return health;
	}
	public float getMovementSpeed()
	{
		return movementSpeed;
	}
	public float getAttackSpeed()
	{
		return attackSpeed;
	}
	public float getDamage()
	{
		return attackDamage;
	}
	public float getDefense()
	{
		return defense;
	}
}
