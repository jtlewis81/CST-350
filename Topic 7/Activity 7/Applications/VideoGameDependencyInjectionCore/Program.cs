using Microsoft.Extensions.DependencyInjection;

namespace VideoGameDependencyInjectionCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HeroThatOnlyUsesSwords hero1 = new HeroThatOnlyUsesSwords("Link");
            //hero1.Attack();
            //Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero2 = new HeroThatCanUseAnyWeapon("Bilbo", new Sword("Sting"));
            //hero2.Attack();
            //Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero3 = new HeroThatCanUseAnyWeapon("Bomberman", new Grenade("Holy Hand Grenade"));
            //hero3.Attack();
            //Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero4 = new HeroThatCanUseAnyWeapon("Duke", new Gun("JoeCannon", new List<Bullet> { new Bullet("Target Round", 5), new Bullet("FMJ", 10), new Bullet("Hot Load FMJ", 50), new Bullet("Hollow Point", 20) } ));
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();

            ServiceCollection services = new ServiceCollection();
            //services.AddTransient<IWeapon, Grenade>(grenade => new Grenade("Explosive Watch"));
            //services.AddTransient<IWeapon, Sword>(sword => new Sword("Luke Skywalker's Lightsaber"));
            services.AddTransient<IWeapon, Gun>(gun => new Gun("Hand Cannon", new List<Bullet> { new Bullet("Target Round", 5), new Bullet("FMJ", 10), new Bullet("Hot Load FMJ", 50), new Bullet("Hollow Point", 20) }));
            services.AddTransient<IHero, HeroThatCanUseAnyWeapon>(hero => new HeroThatCanUseAnyWeapon("007", hero.GetService<IWeapon>()));
            ServiceProvider provider = services.BuildServiceProvider();

            var hero5 = provider.GetService<IHero>();
            hero5.Attack();
            hero5.Attack();
            hero5.Attack();
            hero5.Attack();
            hero5.Attack();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
