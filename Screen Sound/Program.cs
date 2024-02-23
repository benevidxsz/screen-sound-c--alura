using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Screen_Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //camelCase = usado para variaveis (primeira letra da primeira palavra é minuscula ja a da segunda palavra é maiuscula


            string msgBoasVindas = "BOAS VINDAS AO SCREEN SOUND";

            //entre as < > é a chave, dps da , é o valor
            Dictionary<string, List<int>> artistasRegistrados = new Dictionary<string, List<int>>();
            artistasRegistrados.Add("Kanye West", new List<int> { 10, 9, 10 });
            artistasRegistrados.Add("Derek", new List<int>{9, 10, 1, 6});

            //PascalCase = usado para funções (primeira letra de cada palavra é maiuscula
            void ExibirLogo()
            {
                //@ mostra LITERALMENTE o que vai ser escrito
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(@"
█████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n{msgBoasVindas}");
                Console.BackgroundColor= ConsoleColor.Black;
                Console.ForegroundColor= ConsoleColor.White;
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                Console.WriteLine("\nDigite 1 para LISTAR UM ARTISTA");
                Console.WriteLine("Digite 2 para MOSTRAR TODAS OS ARTISTAS");
                Console.WriteLine("Digite 3 para AVALIAR UM ARTISTA");
                Console.WriteLine("Digite 4 para exibir a MÉDIA DE UM ARTISTA");
                Console.WriteLine("Digite -1 para sair");

                Console.Write("\nDigite a opção escolhida: ");
                int opcaoEscolha = int.Parse(Console.ReadLine());

                switch(opcaoEscolha)
                {
                    case 1: RegistrarArtista();
                        break;

                    case 2: MostrarArtistasRegistradas();
                        break;

                    case 3: AvaliarUmArtista();
                        break;

                    case 4: ExibirMediaDoArtista();
                        break;

                    case -1: Console.WriteLine("Você fecou o programa!");
                        break;

                    default: Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            void RegistrarArtista()
            {
                Console.Clear();

                ExibirTituloDaOpcao("Registro dos Artistas");

                Console.Write("Digite o nome do artista que deseja registrar: ");
                string nomeDoArtista = Console.ReadLine();
                //add serve para adicionar algo a uma lista
                artistasRegistrados.Add(nomeDoArtista, new List<int>());
                Console.WriteLine($"\nO artista {nomeDoArtista} foi registrada com sucesso!");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void MostrarArtistasRegistradas()
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                ExibirTituloDaOpcao("Exibindo todas os ARTISTAS registrados");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                /*
                for (int i = 0; i < listaDosArtistas.Count; i++) //.Count serve para "CONTAR ATE QUANTOS 'ARTISTAS' EU TIVER"
                {
                    Console.WriteLine($"Banda: {listaDosArtistas[i]}"); //colchete é o indice, praticamente a posição, qual artista nesse caso
                }
                */


                //SE FOR PARA MOSTRAR TODA A LISTA/MATRIZ/VETOR, mais facil um FOREACH
                //SE FOR PARA MOSTRAR ALGO ESPECIFICO NA LISTA/MATRIZ/VETOR, mais facil um FOR 
                foreach(string artista in artistasRegistrados.Keys)
                {
                    Console.WriteLine($"Artista: {artista}");
                }

                Console.WriteLine("\nDigite qlqr tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void ExibirTituloDaOpcao(string titulo)
            {
                int qtdLetras = titulo.Length;
                string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(asteriscos + "\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }

            void AvaliarUmArtista()
            {
                //digite qual artista deseja avaliar
                //se o artista exsitr no dicionario -> atribuir uma nota
                //senao, volta ao menu

                Console.Clear();
                ExibirTituloDaOpcao("Avaliar Artista");

                Console.Write("Digite o nome do artista que deseja avaliar: ");
                string nomeDoArtista = Console.ReadLine();

                //.ContainsKey se conter alguma chave nesse dicionario, com o mesmo valor/nome que essa variavel tem, entao algum valor vai ser atribuido
                if(artistasRegistrados.ContainsKey(nomeDoArtista))
                {
                    Console.Write($"Qual a nota que o artista {nomeDoArtista} merece: ");
                    int nota = int.Parse(Console.ReadLine());
                    //o colchete é para INDEXAR o dicionario usando a chave, para acessar os valores, com o .Add
                    artistasRegistrados[nomeDoArtista].Add(nota);
                    Console.WriteLine($"A nota {nota} foi registrada com sucesso!");
                    Console.Clear();
                    ExibirOpcoesDoMenu();

                }
                else 
                {
                    Console.WriteLine($"O artista {nomeDoArtista} não existe na base de dados");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
            }

            void ExibirMediaDoArtista()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibir média de um Artista");

                Console.WriteLine("Qual artista você deseja ver a média das avaliações?");
                string nomeDoArtista = Console.ReadLine();

                    if (artistasRegistrados.ContainsKey(nomeDoArtista))
                    {
                        List<int> media = artistasRegistrados[nomeDoArtista];
                        double conta = media.Average();

                        Console.WriteLine($"Essa é a média das avaliações do artista {nomeDoArtista}: *{conta}*! \nDeseja ver de outro artista? (S/N)");
                        char resp = char.Parse(Console.ReadLine());
                        if (resp == 'S')
                        {
                            Console.Clear();
                            ExibirMediaDoArtista();
                        }
                        else
                        {
                            Console.Clear();
                            ExibirOpcoesDoMenu();
                    }
                    }
                    else
                    {
                        Console.WriteLine($"O artista {nomeDoArtista} não existe na base de dados, deseja tentar novamente? (S/N)");
                        char tentativa = char.Parse(Console.ReadLine());
                        if (tentativa == 'S')
                        {
                            ExibirMediaDoArtista();
                        }
                        else
                        {
                            Console.Clear();
                            ExibirOpcoesDoMenu();
                    }
                    }
            }

            ExibirOpcoesDoMenu();

            Console.ReadKey();
        }
    }
}
