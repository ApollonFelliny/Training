// Часть 1 и 4:
interface IDamageable {
    void TakeDamage(int damage);
}

abstract class Character : IDamageable {
    private string name;
    private double health;

    public string Name { get { return name; } set { name = value; } }
    public double Health { get { return health; } set { health = value; } }

    public abstract void Attack();

    public virtual void Move() {
        Console.WriteLine($"{name} идет");
    }
    public void TakeDamage(int damage) {
        health -= damage;
        Console.WriteLine($"{name} получил {damage} урона. Осталось: {health}");
        if (health <= 0){
            Console.WriteLine($"{name} ликвидирован");
        }
    }
}

// Часть 2:
class Warrior : Character {
    public override void Attack() {
        Console.WriteLine($"{Name} атакует мечом!");
    }
}
class Mage : Character {
    public override void Attack() {
        Console.WriteLine($"{Name} атакует магией!");
    }
}

// Часть 3:
class Program {
    static void Main() {
        Character[] mass = new Character[2];
        mass[0] = new Warrior { Name = "Воин", Health = 100.0 };
        mass[1] = new Mage { Name = "Маг", Health = 67.5 };
        foreach (Character i in mass) {
            i.Attack();
        }
    }
}
