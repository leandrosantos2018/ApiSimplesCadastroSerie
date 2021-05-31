using Dio.Series.Enum;
using Dio.Series.Interfaces;
using System;


namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            String opcaoUsuario = ObterOpcaousuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaousuario();
            }

            Console.WriteLine("Obrigado por ultilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada.");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(excluido != true) {
                   Console.WriteLine($"Id :{serie.retornoId()} - {serie.retornoTitulo()}");
                }
                
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir uma Nova Séries");
            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.Genero.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            String entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            String entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i ,Enum.Genero.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            String entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite Descrição da Serie: ");
            String entradaDescricao = Console.ReadLine();

            Serie AtualizaSerie = new Serie(id: indiceSerie,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie,AtualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da Serie: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indeceSerie);
            Console.WriteLine("Serie Excluida com Sucesso!!!!");
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie : ");
            int indeceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornoPorID(indeceSerie);
            var excluido = serie.retornaExcluido();
            
            if (excluido != true)
            {
                Console.WriteLine(serie);
            }
            
        }


        private static String ObterOpcaousuario()
        {
            Console.WriteLine();

            Console.WriteLine("Dio Serie a Seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Lista Série");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X-  Sair");
            Console.WriteLine();

            String opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
