using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class ChampionStats
{
    public int maxHealthPoints;
    public int currentHealthPoints;
    public int attackPoints;

    public void Init()
    {
        maxHealthPoints = 20;
        currentHealthPoints = maxHealthPoints;
    }
}
