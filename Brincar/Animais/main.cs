namespace Brincar.Animais;

class Animal_Brincar
{
    private static List<Animal>? AnimaisCadastrados =
    [
        new Gato(
            1, "Peto", 5
        ),
        new Gato(
            2, "Gado", 0
        ),
    ];
    // private static List<Animal>? AnimaisCadastrados = [];

    static void Criar(bool isDog = true)
    {
        try
        {
            var nome = Input("Qual o nome: ");
            var idade = int.Parse(Input("Qual a idade: "));
            Animal.lastId += 1;

            if (isDog)
                AnimaisCadastrados.Add(new Cachorro(Animal.lastId, nome, idade));
            else
                AnimaisCadastrados.Add(new Gato(Animal.lastId, nome, idade));
            Console.WriteLine(nome + " adicionado com sucesso");
        }
        catch
        {
            Console.WriteLine("É idiota???????");
        }
    }

    static void LerTodos()
    {
        foreach (var animal in AnimaisCadastrados)
        {
            Console.WriteLine("------------");
            Console.WriteLine("ID   : " + animal.id);
            Console.WriteLine("Nome : " + animal.nome);
            Console.WriteLine("Idade: " + animal.anos);
            Console.WriteLine("------------\n");
        }
    }

    static void QueryOneActions()
    {
        var id = Input("Qual o Id do animal: ");
        var currentAnimal = GetAnimalById(int.Parse(id));
        if (currentAnimal == null)
            return;

        while (true)
        {
            Console.WriteLine("1 - Ver infos: ");
            Console.WriteLine("2 - Falar: ");
            Console.WriteLine("3 - Idade: ");
            Console.WriteLine("qq - Sair: ");
            var res = Input("O que vai ser?: ");

            if (res == "qq")
                break;
            else if (res == "1")
                Console.WriteLine(
                    $"\n-----------\nO nome é {currentAnimal.nome}, ele tem {currentAnimal.anos} anos\n-----------\n");
            else if (res == "2")
                currentAnimal.Falar();
            else if (res == "3")
                currentAnimal.Anos();
        }

        Console.WriteLine("Saindo da Query única");
    }

    static Animal? GetAnimalById(int id)
    {
        return AnimaisCadastrados?.Where(a => a.id == id).FirstOrDefault();
    }


    static void Exportar()
    {
        Console.WriteLine("[ ");
        foreach (var animal in AnimaisCadastrados)
        {
            if (animal.isDog)
                Console.WriteLine($"\tnew Dog(");
            else
                Console.WriteLine($"\tnew Gato(");

            Console.WriteLine($"\t\t{animal.id}, \"{animal.nome}\", {animal.anos}");
            Console.WriteLine("\t), ");
        }

        Console.WriteLine("]");
    }


    public static void VerAcoes()
    {
        while (true)
        {
            Console.WriteLine("1 - Ver todos");
            Console.WriteLine("2 - Mexer em 1");
            Console.WriteLine("3 - Criar Cachorro");
            Console.WriteLine("4 - Criar Gato");
            Console.WriteLine("5 - Exportar");
            Console.WriteLine("q - Sair");

            var res = Input("O que fazer: ").ToLower();
            if (res == "q")
                break;
            else if (res == "1")
                LerTodos();
            else if (res == "2")
                QueryOneActions();
            else if (res == "3")
                Criar();
            else if (res == "4")
                Criar(false);
            else if (res == "5")
                Exportar();
        }
    }


    public static void Rodar()
    {
        VerAcoes();

        Console.WriteLine("Até mais");
    }
}