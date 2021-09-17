# Character Stats

### **Health Points**
When a character's health points reach zero, the character is removed from the battle's turn order. If they are not restored by an item or resurrection spell by the end of a battle, they are then removed from the run permanently.  Maximum stat value is 99.

### **Stamina**
Stat governing the number of actions a player can take in a turn.  After use stamina is depleted until it is said character's turn again. Maximum stat value is 99.
| Stamina level | Number of actions|
| ------------- | ---------------- |
| 1             | 2                |
| 25            | 3                |
| 50            | 4                |
| 99            | 5                |

### **Speed**
Stat governing when a character will appear in the turn order.  Higher speed characters appear higher in the turn order and can, with certain abilities, gain additional points of stamina every turn. Maximum stat value is 99.

### **Strength**
Stat governing the damage a physical attack will do to an enemy character.  Maximum stat value is 99.

### **Defence**
Stat governing damage reduction of of incoming physical attacks.  Maximum stat value is 99.

### **Magic**
Stat governing the effectiveness of various magical spells.  Maximum stat value is 99.

### **Magic Defence**
Stat governing damage reduction of of incoming magical attacks.  Maximum stat value is 99.

### Level
Metric indicative of overall unit power.  A unit gains experience upon killing enemies.  All units gain experience upon winning a battle.  After an exponential threshold is crossed, the player's level increases by one.  The unit gains +2 levels in it's major stat (+4 Magic for Cleric) and 1 level in it's minor stats. 

| New Game Level  | Max Level |
| --------------- | --------- |
|        1        |    99     |
|        2        |    199    |
|        3        |    299    |
|        4        |    399    |
|        5        |    499    |
|        6        |    599    |
|        7        |    699    |
|        8        |    799    |
|        9        |    899    |
|        10       |    999    |

# Character Actions
## Move
  Moves a unit a number of spaces based on their speed stat.  The move action consumes 1 stamina.
 | Speed Stat | No. Of spaces |
 | ---------- | ------------- |
 |      1     |       2       |
 |      5     |       3       |
 |     10     |       4       |
 |     25     |       5       |
 |     40     |       6       |
 |     55     |       7       |
 |     70     |       8       | 
 |     85     |       9       |
 |     99     |      10       |
 
## Attack
  Uses Attack stat times weapon's multiplier to deal damage to an enemy unit.  The attack action consumes 1 stamina.
| Weapon Type | Attack action |                                         Effect                                            |
| ----------- | --------------| ----------------------------------------------------------------------------------------- |
| Sword       | Attack        | Damage the unit in the space infront of the user using strength stat causes 1 knock back. |
| Bow         | Shot          | Damage a unit in within a radius of 4 spaces of the user using strength stat.             |
| Staff       | Magic Burst   | Damage all units in within 2 spaces in front of the user using magic stat.                |

## Defend
  Uses Defence and Magic Defence stat to reduce the incoming damage.  The Defend action consumes 1 stamina.
## Skills
  Uses one of the skills posessed by the user.  Each skill action consumes a unqique quantity of stamina.  Skills are learned through weapon experience.  A unit can equip up to 4 skills at once.  Any unit can equip a mastered skill regardless of currently equipped class.  The currently equipped weapon's skill must be equipped 

# Character Classes
## **Fighter**
Class specializes in the Stength stat with light specialization in Health Points & Defence.
| Stat              | Possible L1 stats |
| ----------------- | ----------------- |
| **Health Points** | [10, 11, 11, 13]  |
| Stamina           | [7,  7,  9,  11]  |
| Speed             | [8,  8,  9,  11]  |
| ***Strength***    | [12, 15, 15, 18]  |
| **Defence**       | [10, 11, 11, 13]  |
| Magic             | [5,  5,  5,  7 ]  |
| Magic Defence     | [4,  4,  5,  6 ]  |

| Skills          | Effect                                                                      | Cost |
| --------------- | --------------------------------------------------------------------------- | ---- |
| Focus           | Next turn gain +1 action.                                                   |  1   |
| Wind Slash      | Hit the 2 tiles in front of the user.                                       |  1   |
| Whirlwind       | Hit all adjacent tiles. All targets recieve 1 knockback.                    |  2   |
| Berserk         | This turn, half your defence to double your strength.                       |  2   |
| Strength Within | Gain +5 strength this turn.  Lose 1 strength per turn indefinitely for the remainder of the battle.  Original stat is restored at the end of the battle.                                                                                     |  3   |

## **Rogue / Archer**
Class specializes in the Speed stat with light specialization in Magic & Stamina.
| Stat          | Possible L1 stats|
| ------------- | ---------------- |
| Health Points | [8,  8,  9,  10] |
| **Stamina**   | [20, 24, 25, 25] |
| ***Speed***   | [12, 12, 15, 18] |
| Strength      | [6,  6,  7,  8 ] |
| Defence       | [6,  6,  7,  9 ] |
| **Magic**     | [10, 11, 11, 13] |
| Magic Defence | [5,  5,  5, 7  ] |

| Skills        | Effect                                                                      | Cost |
| ------------- | --------------------------------------------------------------------------- | ---- |
| Magical Shot  | Fire magic arrow.                                                           |  1   |
| Focus         | Next turn gain +1 action.                                                   |  1   |
| Double shot   | This turn this unit's next bow attack happens twice.                        |  1   |
| Scope         | This turn this unit's bow attacks have double range.                        |  2   |
| Kneecap       | Half the defence of an enemy unit for the rest of their turn.               |  3   |

## **Mage**
Class specializes in the Magic Defence stat with light specialization in Health Points & Magic.
| Stat                | Possible L1 stats |
| ------------------- | ----------------  |
| **Health Points**   | [9,  9,  10, 12]  |
| Stamina             | [7,  8,  9, 11 ]  |
| Speed               | [6,  7,  8,  10]  |
| Strength            | [5,  5,  5,  7 ]  |
| Defence             | [4,  5,  5,  6 ]  |
| **Magic**           | [12, 12, 13, 14]  |
| ***Magic Defence*** | [13, 14, 14, 18]  |

| Skills        | Effect                                                                      | Cost |
| ------------- | --------------------------------------------------------------------------- | ---- |
| Heal          | Heal an adjacent unit for ~30% of their maximum health.                     |  1   |
| Magical Sword | Hit the 3 perpendicular tiles in front of user.                             |  1   |
| Magical Shot  | Fire magic arrow.                                                           |  1   |
| Rock Body     | Gain +2 Defence for each spell this unit has cast this battle & prevents knockback for the rest of the battle Can only be cast once per battle.                                                                                                 |  2   |
| Mutation      | Gain +10 Magic this turn.  Lose 2 magic per turnindefinitely for the remainder of the battle.  Original stat is restored at the end of the battle.                                                                                       |  3   |

## **Cleric**
Class heavy specialization in the Magic stat.
| Stat              | Possible L1 stats|
| ----------------- | ---------------- |
| Health Points     | [8,  9, 10, 12 ] |
| Stamina           | [4,  4,  6,  8 ] |
| Speed             | [6,  7,  8,  10] |
| Strength          | [3,  4,  4,  6 ] |
| Defence           | [4,  5,  6,  7 ] |
| ***Magic***       | [13, 13, 14, 19] |
| Magic Defence     | [7,  7,  8,  10] |

| Skills        | Effect                                                                      | Cost |
| ------------- | --------------------------------------------------------------------------- | ---- |
| Heal          | Heal an adjacent unit for ~30% of their maximum health.                     |  1   |
| Swap          | Swap the positions of one friendly and one enemy unit.                      |  2   |
| Great Heal    | Heal units up to 2 tiles away for ~60% of their maximum health.             |  2   |
| Double cast   | Activate ability that makes the first spell cast each turn is casted twice for the rest of the battle.                                                                                                                                         |  3   |
| Magic Armor   | Gain +7 Defence and +7 Magic Defence  this turn.  Lose 2 Defence & Magic Defence per turn indefinitely for the remainder of the battle.  Original stats are restored at the end of the battle.                                                  |  3   |



### **Future Classes template**
Class specializes in the  &  stats with light specialization in .
| Stat          | Possible L1 stats|
| ------------- | ---------------- |
| Health Points | [,,,,]       |
| Stamina       | [,,,,]       |
| Speed         | [,,,,]       |
| Strength      | [,,,,]       |
| Defence       | [,,,,]       |
| Magic         | [,,,,]       |
| Magic Defence | [,,,,]       |

| Skills        | Effect                                                  | Cost |
| ------------- | ------------------------------------------------------- | ---- |
|               |  |     |
