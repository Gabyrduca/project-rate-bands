
// Personal Project to learn C# - Application to evaluate bands and rate each one of them at the command prompt
// Projeto pessoal para aprender C# -  Aplicação para avaliar bandas e dar notas a cada uma delas no prompt de comando

string mensagemDeBoasVindas = "Boas Vindas ao Screen Sound";
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();


void ExibirMensagemdeBoasVindas()
{
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");
    
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesdeMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 paara mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para Sair");
    Console.Write("\nDigite a sua opção: ");  
    string opcaoEscolhida = Console.ReadLine()!;
    //variavel para armazenar a opção de escolha - coloca o ! para a marcação do verdinho sumir porque vamos trabalhar com string 
    //Entrar com a condição - se digitar 1 acontece algo

    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); //função int.Parse pega o texto e passa para o valor inteiro
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("Tchau tchau :) ");
            break;
        default: Console.WriteLine("Opção invalida");
            break;

    }

}


void RegistrarBandas()
{
    Console.Clear();  
    ExibirTituloDaOpcao("\nRegistro das Bandas\n");
    Console.WriteLine("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;  //! para endicar que não queremos trabalhar com valor nulo
    bandasRegistradas.Add(nomeDaBanda,new List<int>()); //variavel.Add = método do dicionario + chave - nomeDaBanda e lista vazia de nota
    Console.WriteLine($"A banda foi {nomeDaBanda} registrada com sucesso");  // interpolação de string para referenciar a variável
    Thread.Sleep(2000); 
    Console.Clear();
    ExibirOpcoesdeMenu(); 

}

void MostrarBandasRegistradas()
{
        Console.Clear();
        ExibirTituloDaOpcao("\nExibindo titulo das bandas registradas: \n");
       // for (int i = 0; i < listaDasBandas.Count; i++)  // declarar uma variavel e percorrer toda a lista, enquanto tiver banda continua a executar 
        //{
          //  Console.WriteLine($"Banda: {listaDasBandas[i]}");

        //}

        // Outra maneira de fazer o loop de repetição:

        foreach (string banda in bandasRegistradas.Keys) //para cada banda na lista de banda
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao Menu Principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdeMenu();

}

void ExibirTituloDaOpcao(string titulo) //dentro do parenteses vai receber um parametro que é o título na string
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.Write(asterisco);
    Console.Write(titulo);
    Console.Write(asterisco + "\n"); //concatenar a quebra de linha
}

void AvaliarUmaBanda()
{
    //digitar qual banda deseja avaliar 
    //se a banda existir no dicionário >> atribuir uma nota
    //senão volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaiar: ");
    string nomeDaBanda = Console.ReadLine()!; //! queremos de fato uma string e não um valor nullo
    if(bandasRegistradas.ContainsKey(nomeDaBanda)) 
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!); //temos a nota > registrar na lista das bandas registradas
        bandasRegistradas[nomeDaBanda].Add(nota); //uso de [] para indexar o dicionário usando a chave e acesso os valores na lista
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda: {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesdeMenu();
    } else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdeMenu();

    }


}

void ExibirMedia() 
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey (nomeDaBanda))
    {
        List<int> notasDaBnada = bandasRegistradas[nomeDaBanda]; //pegou toda a lista de notas e attribui na variábel motasDaBanda
        Console.WriteLine($"\nA média da banda é{nomeDaBanda} é {notasDaBnada.Average()}."); //calculo da média
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdeMenu();

    } else 
    
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesdeMenu();
    }
}


ExibirMensagemdeBoasVindas();
ExibirOpcoesdeMenu();

Console.ReadKey();


